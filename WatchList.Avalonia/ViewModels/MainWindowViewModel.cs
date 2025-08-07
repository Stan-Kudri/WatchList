using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using ReactiveUI;
using WatchList.Avalonia.Extension;
using WatchList.Avalonia.Models;
using WatchList.Avalonia.Models.Filter;
using WatchList.Avalonia.Models.Sorter;
using WatchList.Avalonia.ViewModel;
using WatchList.Avalonia.ViewModels.ItemsView;
using WatchList.Core.Model.ItemCinema;
using WatchList.Core.PageItem;
using WatchList.Core.Service;
using WatchList.Core.Service.Component;

namespace WatchList.Avalonia.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        private const string HighlightTheDesiredLine = "No items selected.";
        private const string NotSelectSingleItemLine = "Select one item.";
        private const string MessageDeleteItems = "Delete select items?";
        private const string MessageDeleteItem = "Delete item?";

        private readonly WatchItemService _itemService;
        private readonly IMessageBox _messageBox;
        private readonly IServiceProvider _serviceProvider;

        private PagedList<WatchItem> _pagedList;

        [ObservableProperty] private FilterItemModel _filterItem;
        [ObservableProperty] private List<SelectFilterTypeField> _filterTypeFieldWatchItems;
        [ObservableProperty] private List<SelectFilterStatusField> _filterStatusField;

        [ObservableProperty] private SortWatchItemModel _sortField;
        [ObservableProperty] private TypeSortFields _typeSortFields;

        [ObservableProperty] private WatchItem _selectItem;
        [ObservableProperty] private ObservableCollection<WatchItem> _watchItems = new();

        [ObservableProperty] private DisplayPagination _displayPagination = new();
        [ObservableProperty] private PageModel _page;

        public PagedList<WatchItem> PagedList
        {
            get => _pagedList;
            private set
            {
                SetProperty(ref _pagedList, value);
                DisplayPagination.Update(PagedList);
            }
        }

        public DropDownManager<SortWatchItemModel> SortDropDown { get; }
        public DropDownManager<FilterItemModel> FilterTypeDropDown { get; }
        public DropDownManager<FilterItemModel> FilterStatusDropDown { get; }

        public Interaction<AddCinemaViewModel?, bool> ShowAddCinemaDialog { get; } = new();
        public Interaction<EditCinemaViewModel?, bool> ShowEditCinemaDialog { get; } = new();

        public ReactiveCommand<Unit, Unit> MoveToPreviousPageCommand { get; }
        public ReactiveCommand<Unit, Unit> MoveToFirstPageCommand { get; }
        public ReactiveCommand<Unit, Unit> MoveToNextPageCommand { get; }
        public ReactiveCommand<Unit, Unit> MoveToLastPageCommand { get; }

        public MainWindowViewModel(
                                   IMessageBox messageBox,
                                   WatchItemService watchItemService,
                                   PageModel pageModel,
                                   IServiceProvider serviceProvider,
                                   FilterItemModel filterItem,
                                   SortWatchItemModel sortField,
                                   TypeSortFields typeSortFields)
        {
            _messageBox = messageBox;
            _itemService = watchItemService;
            _serviceProvider = serviceProvider;

            FilterItem = filterItem;
            SortField = sortField;
            TypeSortFields = typeSortFields;
            Page = pageModel;

            SortDropDown = new DropDownManager<SortWatchItemModel>(() => SortField.GetSelectItems);
            FilterTypeDropDown = new DropDownManager<FilterItemModel>(() => FilterItem.GetSelectTypeFilter);
            FilterStatusDropDown = new DropDownManager<FilterItemModel>(() => FilterItem.GetSelectStatusFilter);

            // First load page
            PagedList = _itemService.GetPage(BuildSearchRequest(Page.Number, Page.Size));
            WatchItems.UppdataItems(PagedList.Items);

            // canExecute for pagination
            var canGoPrev = this.WhenAnyValue(viewModel => viewModel.Page.Number).Select(n => n > 1);
            var canGoNext = this.WhenAnyValue(viewModel => viewModel.Page.Number, vm => vm.PagedList.PageCount, (n, count) => n < Math.Max(1, count));

            MoveToPreviousPageCommand = ReactiveCommand.CreateFromTask(() => GoToPageAsync(Page.Number - 1), canGoPrev);
            MoveToFirstPageCommand = ReactiveCommand.CreateFromTask(() => GoToPageAsync(1), canGoPrev);
            MoveToNextPageCommand = ReactiveCommand.CreateFromTask(() => GoToPageAsync(Page.Number + 1), canGoNext);
            MoveToLastPageCommand = ReactiveCommand.CreateFromTask(() => GoToPageAsync(PagedList.PageCount), canGoNext);
        }

        [RelayCommand]
        private async Task UseSort() => await LoadDataAsync(resetToFirstPage: false);

        [RelayCommand]
        private async Task ClearFilter()
        {
            FilterItem.Clear();
            SortField.Clear();
            await LoadDataAsync(resetToFirstPage: true);
        }

        [RelayCommand]
        private async Task UseFilter() => await LoadDataAsync(resetToFirstPage: false);

        [RelayCommand]
        private async Task MoveAddItem()
        {
            var viewModel = _serviceProvider.GetRequiredService<AddCinemaViewModel>();
            viewModel.InitializeDefaultValue();

            var result = await ShowAddCinemaDialog.Handle(viewModel);

            if (result)
            {
                await RefreshAsync(Page.Number, Page.Size);
            }
        }

        [RelayCommand]
        private async Task MoveEditItem(IList selectedItems)
        {
            if (selectedItems?.Count != 1)
            {
                await _messageBox.ShowInfo(NotSelectSingleItemLine);
                return;
            }

            var viewModel = _serviceProvider.GetRequiredService<EditCinemaViewModel>();
            viewModel.InitializeDefaultValue(SelectItem);

            var result = await ShowEditCinemaDialog.Handle(viewModel);

            if (result)
            {
                await RefreshAsync(Page.Number, Page.Size);
            }
        }

        [RelayCommand]
        private async Task DeleteItem(IList selectedItems)
        {
            if (selectedItems is null || selectedItems.Count == 0)
            {
                await _messageBox.ShowInfo(HighlightTheDesiredLine);
                return;
            }

            if (selectedItems.Count > 1)
            {
                if (await _messageBox.ShowQuestion(MessageDeleteItems))
                {
                    _itemService.RemoveRangeWatchItem(selectedItems);
                    await RefreshAsync(Page.Number, Page.Size);
                }
                return;
            }

            if (await _messageBox.ShowQuestion(MessageDeleteItem))
            {
                _itemService.Remove(SelectItem.Id);
                await RefreshAsync(Page.Number, Page.Size);
            }
        }

        [RelayCommand]
        private async Task AddData(Window currentWindow)
        {
            var viewModel = _serviceProvider.GetRequiredService<MergeDatabaseViewModel>();
            var window = new MergeDatabaseWindow(viewModel);
            await window.ShowDialog(currentWindow);
            await RefreshAsync(Page.Number, Page.Size);
        }

        private ItemSearchRequest BuildSearchRequest(int pageNumber, int pageSize)
            => new ItemSearchRequest(FilterItem.GetFilter(), SortField.GetSortItem(), new Page(pageNumber, pageSize), TypeSortFields.IsAscending);

        private async Task GoToPageAsync(int pageNumber) => await RefreshAsync(pageNumber, Page.Size);

        private async Task LoadDataAsync(bool resetToFirstPage)
        {
            try
            {
                // Update filter and sort states
                FilterItem.SetFilter();
                SortField.SetSortFields();

                SortDropDown.UpdateDisplay();
                FilterTypeDropDown.UpdateDisplay();
                FilterStatusDropDown.UpdateDisplay();

                var targetPage = resetToFirstPage ? 1 : Page.Number;

                // Pre-query to adjust page number if current page is out of range after filtering
                var preview = _itemService.GetPage(BuildSearchRequest(targetPage, Page.Size));
                var pageNumber = preview.Count == 0 ? Math.Max(1, preview.PageCount) : targetPage;

                await RefreshAsync(pageNumber, Page.Size);
            }
            catch (Exception ex)
            {
                await _messageBox.ShowError(ex.Message);
            }
        }

        private async Task RefreshAsync(int pageNumber, int pageSize)
        {
            try
            {
                var request = BuildSearchRequest(pageNumber, pageSize);
                var page = _itemService.GetPage(request);

                PagedList = page;
                WatchItems = WatchItems.UppdataItems(page.Items);

                Page.Number = pageNumber;
                Page.Size = pageSize;
            }
            catch (Exception ex)
            {
                await _messageBox.ShowError(ex.Message);
            }
        }
    }
}
