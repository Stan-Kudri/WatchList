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
using DynamicData.Binding;
using Microsoft.Extensions.DependencyInjection;
using ReactiveUI;
using WatchList.Avalonia.Extension;
using WatchList.Avalonia.Models;
using WatchList.Avalonia.Models.Filter;
using WatchList.Avalonia.Models.Sorter;
using WatchList.Avalonia.ViewModel;
using WatchList.Avalonia.ViewModels.ItemsView;
using WatchList.Core.Model.Filter;
using WatchList.Core.Model.ItemCinema;
using WatchList.Core.Model.Sortable;
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

        private readonly ItemSearchRequest _searchRequests;

        private PagedList<WatchItem> _pagedList;

        [ObservableProperty] private FilterItemModel _filterItem;
        [ObservableProperty] private List<SelectFilterTypeFieldWatchItem> _filterTypeFieldWatchItems;

        [ObservableProperty] private SortWatchItemModel _sortField;
        [ObservableProperty] private TypeSortFields _typeSortFields;

        [ObservableProperty] private WatchItem _selectItem;
        [ObservableProperty] private ObservableCollection<WatchItem> _watchItems = new ObservableCollection<WatchItem>();

        [ObservableProperty] private DisplayPagination _displayPagination = new DisplayPagination();
        [ObservableProperty] private PageModel _page;

        public PagedList<WatchItem> PagedList
        {
            get => _pagedList;
            set
            {
                SetProperty(ref _pagedList, value);
                DisplayPagination.Update(PagedList);
            }
        }

        public DropDownManager<SortWatchItemModel> SortDropDown { get; }
        public DropDownManager<FilterItemModel> FilterDropDown { get; }

        public MainWindowViewModel(IMessageBox messageBox,
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
            _searchRequests = new ItemSearchRequest(new FilterWatchItem(), new SortWatchItem(), Page.GetPage(), true);
            PagedList = _itemService.GetPage(_searchRequests);

            var numberObservable = Page.WhenAnyValue(x => x.Number, x => x.Size).Select(tuple => tuple.Item1);
            var watchItemListObservable = WatchItems.ObserveCollectionChanges().Select(e => Page.Number);

            SortDropDown = new DropDownManager<SortWatchItemModel>(() => SortField.GetSelectItems);
            FilterDropDown = new DropDownManager<FilterItemModel>(() => FilterItem.GetSelectTypeFilter);

            var canExecuteMoveToPrevPage = numberObservable.Merge(watchItemListObservable).Select(number => number > 1);
            MoveToPreviousPageCommand = ReactiveCommand.CreateFromTask(() => LoadDataAsyncPage(Page.Number - 1), canExecuteMoveToPrevPage);
            MoveToFirstPageCommand = ReactiveCommand.CreateFromTask(() => LoadDataAsyncPage(1), canExecuteMoveToPrevPage);

            var canExecuteMoveToNextPage = numberObservable.Merge(watchItemListObservable).Select(number => number < PagedList.PageCount);
            MoveToNextPageCommand = ReactiveCommand.CreateFromTask(() => LoadDataAsyncPage(Page.Number + 1), canExecuteMoveToNextPage);
            MoveToLastPageCommand = ReactiveCommand.CreateFromTask(() => LoadDataAsyncPage(PagedList.PageCount), canExecuteMoveToNextPage);

            var canExecuteChangePage = Page.WhenAnyValue(x => x.Number).Select(number => number != PagedList.PageCount);

            WatchItems.UppdataItems(PagedList.Items);
        }

        public Interaction<AddCinemaViewModel?, bool> ShowAddCinemaDialog { get; } = new Interaction<AddCinemaViewModel?, bool>();
        public Interaction<EditCinemaViewModel?, bool> ShowEditCinemaDialog { get; } = new Interaction<EditCinemaViewModel?, bool>();

        public ReactiveCommand<Unit, Unit> MoveToPreviousPageCommand { get; }
        public ReactiveCommand<Unit, Unit> MoveToFirstPageCommand { get; }
        public ReactiveCommand<Unit, Unit> MoveToNextPageCommand { get; }
        public ReactiveCommand<Unit, Unit> MoveToLastPageCommand { get; }

        [RelayCommand]
        private async Task UseFilter()
        {
            var searchRequests = _searchRequests;
            searchRequests.Page = Page.GetPage();
            var pagedList = _itemService.GetPage(searchRequests);
            var pageNumber = pagedList.Count == 0 ? pagedList.PageCount : searchRequests.Page.Number;
            await LoadDataAsync(pageNumber, searchRequests.Page.Size);
            FilterDropDown.UpdateDisplay();
        }

        [RelayCommand]
        private async Task UseSort(object sorter)
        {
            FilterItem.SetTypeFilter();
            SortField.SetSortFields();
            SortDropDown.UpdateDisplay();
            await UseFilter();
        }

        [RelayCommand]
        private async Task MoveAddItem()
        {
            var viewModel = _serviceProvider.GetRequiredService<AddCinemaViewModel>();
            viewModel.InitializeDefaultValue();
            var result = await ShowAddCinemaDialog.Handle(viewModel);

            if (!result)
            {
                return;
            }

            await LoadDataAsync(Page.Number, Page.Size);
        }

        [RelayCommand]
        private async Task MoveEditItem(IList selectedItems)
        {
            if (selectedItems.Count != 1)
            {
                await _messageBox.ShowInfo(NotSelectSingleItemLine);
                return;
            }

            var viewModel = _serviceProvider.GetRequiredService<EditCinemaViewModel>();
            viewModel.InitializeDefaultValue(SelectItem);
            var result = await ShowEditCinemaDialog.Handle(viewModel);

            if (!result)
            {
                return;
            }

            await LoadDataAsync(Page.Number, Page.Size);
        }

        [RelayCommand]
        private async Task DeleteItem(IList selectedItems)
        {
            switch (selectedItems.Count)
            {
                case 0:
                    await _messageBox.ShowInfo(HighlightTheDesiredLine);
                    return;
                case > 1 when await _messageBox.ShowQuestion(MessageDeleteItems):
                    _itemService.RemoveRangeWatchItem(selectedItems);
                    break;
                case 1 when await _messageBox.ShowQuestion(MessageDeleteItem):
                    _itemService.Remove(SelectItem.Id);
                    break;
                default:
                    return;
            }

            await LoadDataAsync(Page.Number, Page.Size);
        }

        [RelayCommand]
        private async Task AddData(Window currentWindow)
        {
            var viewModel = _serviceProvider.GetRequiredService<MergeDatabaseViewModel>();
            var window = new MergeDatabaseWindow(viewModel);
            await window.ShowDialog(currentWindow);
            await LoadDataAsync(Page.Number, Page.Size);
        }

        /// <summary>
        /// Load data in table.
        /// </summary>
        private async Task LoadDataAsync(int pageNumber, int pageSize)
        {
            try
            {
                _searchRequests.Sort = SortField.SortItem;
                _searchRequests.Filter = FilterItem.GetFilter();
                _searchRequests.Page = new Page(pageNumber, pageSize);
                PagedList = _itemService.GetPage(_searchRequests);
                WatchItems = WatchItems.UppdataItems(PagedList.Items);
                Page.Number = pageNumber;
                Page.Size = pageSize;
            }
            catch (Exception error)
            {
                await _messageBox.ShowError(error.Message);
            }
        }

        /// <summary>
        /// Load data in table.
        /// </summary>
        private async Task LoadDataAsyncPage(int pageNumber)
        {
            await LoadDataAsync(pageNumber, Page.Size);
        }
    }
}
