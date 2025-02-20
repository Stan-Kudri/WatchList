using System;
using System.Collections;
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

        [ObservableProperty] private WatchItem _selectItem;

        [ObservableProperty] private DisplayPagination _displayPagination = new DisplayPagination();
        [ObservableProperty] private PageModel _page;
        [ObservableProperty] private ObservableCollection<WatchItem> _watchItems = new ObservableCollection<WatchItem>();

        public PagedList<WatchItem> PagedList
        {
            get => _pagedList;
            set
            {
                SetProperty(ref _pagedList, value);
                DisplayPagination.Update(PagedList);
            }
        }

        public MainWindowViewModel(IMessageBox messageBox,
                            WatchItemService watchItemService,
                            PageModel pageModel,
                            IServiceProvider serviceProvider)
        {
            _messageBox = messageBox;
            _itemService = watchItemService;
            _serviceProvider = serviceProvider;
            Page = pageModel;
            _searchRequests = new ItemSearchRequest(new FilterWatchItem(), new SortWatchItem(), Page.GetPage(), true);
            PagedList = _itemService.GetPage(_searchRequests);

            var canExecuteMoveToPrevPage = Page.WhenAnyValue(x => x.Number).Select(number => number > 1);
            MoveToPreviousPageCommand = ReactiveCommand.CreateFromTask(() => LoadDataAsyncPage(Page.Number - 1), canExecuteMoveToPrevPage);
            MoveToFirstPageCommand = ReactiveCommand.CreateFromTask(() => LoadDataAsyncPage(1), canExecuteMoveToPrevPage);

            var canExecuteMoveToNextPage = Page.WhenAnyValue(x => x.Number).Select(number => number < PagedList.Count);
            MoveToNextPageCommand = ReactiveCommand.CreateFromTask(() => LoadDataAsyncPage(Page.Number + 1), canExecuteMoveToNextPage);
            MoveToLastPageCommand = ReactiveCommand.CreateFromTask(() => LoadDataAsyncPage(PagedList.Count), canExecuteMoveToNextPage);

            var canExecuteChangePage = Page.WhenAnyValue(x => x.Number).Select(number => number != PagedList.Count);

            WatchItems.UppdataItems(PagedList.Items);
        }

        public Interaction<AddCinemaViewModel?, bool> ShowAddCinemaDialog { get; } = new Interaction<AddCinemaViewModel?, bool>();
        public Interaction<EditCinemaViewModel?, bool> ShowEditCinemaDialog { get; } = new Interaction<EditCinemaViewModel?, bool>();

        public ReactiveCommand<Unit, Unit> MoveToPreviousPageCommand { get; }
        public ReactiveCommand<Unit, Unit> MoveToFirstPageCommand { get; }
        public ReactiveCommand<Unit, Unit> MoveToNextPageCommand { get; }
        public ReactiveCommand<Unit, Unit> MoveToLastPageCommand { get; }

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

            await LoadDataAsync();
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

            await LoadDataAsync();
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

            await LoadDataAsync();
        }

        [RelayCommand]
        private async Task AddData(Window currentWindow)
        {
            var viewModel = _serviceProvider.GetRequiredService<MergeDatabaseViewModel>();
            var window = new MergeDatabaseWindow(viewModel);
            await window.ShowDialog(currentWindow);
            await LoadDataAsync();
        }

        /// <summary>
        /// Load data in table.
        /// </summary>
        private async Task LoadDataAsync()
        {
            try
            {
                _searchRequests.Page = Page.GetPage();
                PagedList = _itemService.GetPage(_searchRequests);
                WatchItems = new ObservableCollection<WatchItem>(PagedList.Items);
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
            Page.Number = pageNumber;
            await LoadDataAsync();
        }
    }
}
