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

        private PagedList<WatchItem>? _pagedList;

        [ObservableProperty] private string _pageDisplayText = string.Empty;
        [ObservableProperty] private PageModel _page;

        //[ObservableProperty] private ObservableCollection<WatchItem> _watchItems = new ObservableCollection<WatchItem>();
        public ObservableCollection<WatchItem> WatchItems { get; }

        public MainWindowViewModel(IMessageBox messageBox,
                            WatchItemService watchItemService,
                            PageModel pageModel)
        {
            _messageBox = messageBox;
            _itemService = watchItemService;
            Page = pageModel;
            _searchRequests = new ItemSearchRequest(new FilterWatchItem(), new SortWatchItem(), Page.GetPage(), true);
            _pagedList = _itemService.GetPage(_searchRequests);

            var canExecuteMoveToPrevPage = Page.WhenAnyValue(x => x.Number).Select(number => number > 1);
            MoveToPreviousPageCommand = ReactiveCommand.CreateFromTask(() => LoadDataAsyncPage(Page.Number - 1), canExecuteMoveToPrevPage);
            MoveToFirstPageCommand = ReactiveCommand.CreateFromTask(() => LoadDataAsyncPage(1), canExecuteMoveToPrevPage);

            var canExecuteMoveToNextPage = Page.WhenAnyValue(x => x.Number).Select(number => number < _pagedList.PageCount);
            MoveToNextPageCommand = ReactiveCommand.CreateFromTask(() => LoadDataAsyncPage(Page.Number + 1), canExecuteMoveToNextPage);
            MoveToLastPageCommand = ReactiveCommand.CreateFromTask(() => LoadDataAsyncPage(_pagedList.PageCount), canExecuteMoveToNextPage);

            WatchItems = new ObservableCollection<WatchItem>(_pagedList.Items);
            //WatchItems.UppdataItems(_pagedList.Items);
            PageDisplayText = _pagedList.HasEmptyPage
                            ? string.Empty
                            : $"Page {_pagedList.PageNumber} of {_pagedList.PageCount}";
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
                _pagedList = _itemService.GetPage(_searchRequests);
                WatchItems.UppdataItems(_pagedList.Items);
                PageDisplayText = _pagedList.HasEmptyPage
                                ? string.Empty
                                : $"Page {_pagedList.PageNumber} of {_pagedList.PageCount}";
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
