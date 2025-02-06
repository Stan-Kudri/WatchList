using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ReactiveUI;
using WatchList.Avalonia.Extension;
using WatchList.Avalonia.Models;
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
        private readonly WatchItemService _itemService;
        private readonly IMessageBox _messageBox;

        private readonly ItemSearchRequest _searchRequests;

        private PagedList<WatchItem> _pagedList;

        [ObservableProperty] private DisplayPagination _displayPagination = new DisplayPagination();
        [ObservableProperty] private PageModel _page;

        public ObservableCollection<WatchItem> WatchItems { get; }

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
                            PageModel pageModel)
        {
            _messageBox = messageBox;
            _itemService = watchItemService;
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

            WatchItems = new ObservableCollection<WatchItem>(PagedList.Items);
        }

        public ReactiveCommand<Unit, Unit> MoveToPreviousPageCommand { get; }
        public ReactiveCommand<Unit, Unit> MoveToFirstPageCommand { get; }
        public ReactiveCommand<Unit, Unit> MoveToNextPageCommand { get; }
        public ReactiveCommand<Unit, Unit> MoveToLastPageCommand { get; }

        [RelayCommand]
        private async Task AddData() => await LoadDataAsync();

        /// <summary>
        /// Load data in table.
        /// </summary>
        private async Task LoadDataAsync()
        {
            try
            {
                _searchRequests.Page = Page.GetPage();
                PagedList = _itemService.GetPage(_searchRequests);
                WatchItems.UppdataItems(PagedList.Items);
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
