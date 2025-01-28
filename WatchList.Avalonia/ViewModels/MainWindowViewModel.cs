using System;
using System.Collections.ObjectModel;
using System.Reactive;
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

        [ObservableProperty] private string _pageDisplayText = string.Empty;
        [ObservableProperty] private PageModel _page;

        [ObservableProperty] private ObservableCollection<WatchItem> _watchItems = new ObservableCollection<WatchItem>();

        public MainWindowViewModel(IMessageBox messageBox,
                            WatchItemService watchItemService,
                            PageModel pageModel)
        {
            _messageBox = messageBox;
            _itemService = watchItemService;
            Page = pageModel;

            _searchRequests = new ItemSearchRequest(new FilterWatchItem(), new SortWatchItem(), Page.GetPage(), true);

            _ = LoadDataAsync();

            //MoveToFirstPageCommand = ReactiveCommand.CreateFromTask(async () => { await LoadDataAsyncPage(1); }, this.WhenAnyValue(x => x._pagedList, x => x != null && x.HasPreviousPage));
            //MoveToPreviousPageCommand = ReactiveCommand.CreateFromTask(async () => { await LoadDataAsyncPage(--Page.Number); }, this.WhenAnyValue(x => x._pagedList, x => x != null && x.HasPreviousPage));
            //MoveToNextPageCommand = ReactiveCommand.CreateFromTask(async () => { await LoadDataAsyncPage(++Page.Number); }, this.WhenAnyValue(x => x._pagedList, x => x != null && x.HasNextPage));
            //MoveToLastPageCommand = ReactiveCommand.CreateFromTask(async () => { await LoadDataAsyncPage(_pagedList.PageCount); }, this.WhenAnyValue(x => x._pagedList, x => x != null && x.HasNextPage));
            MoveToFirstPageCommand = ReactiveCommand.CreateFromTask(async () => { if (_pagedList != null && _pagedList.HasPreviousPage) { await LoadDataAsyncPage(1); } });
            MoveToPreviousPageCommand = ReactiveCommand.CreateFromTask(async () => { if (_pagedList != null && _pagedList.HasPreviousPage) { await LoadDataAsyncPage(--_page.Number); } });
            MoveToNextPageCommand = ReactiveCommand.CreateFromTask(async () => { if (_pagedList != null && _pagedList.HasNextPage) { await LoadDataAsyncPage(++Page.Number); } });
            MoveToLastPageCommand = ReactiveCommand.CreateFromTask(async () => { if (_pagedList != null && _pagedList.HasNextPage) { await LoadDataAsyncPage(_pagedList.PageCount); } });
        }

        public ReactiveCommand<Unit, Unit> MoveToFirstPageCommand { get; }
        public ReactiveCommand<Unit, Unit> MoveToPreviousPageCommand { get; }
        public ReactiveCommand<Unit, Unit> MoveToNextPageCommand { get; }
        public ReactiveCommand<Unit, Unit> MoveToLastPageCommand { get; }

        [RelayCommand]
        private async Task AddData()
            => await LoadDataAsync();

        /// <summary>
        /// Load data in table.
        /// </summary>
        private async Task LoadDataAsync()
        {
            try
            {
                UpdataPagedList();
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

        private void UpdataPagedList()
        {
            UpdataSearchRequests();
            _pagedList = _itemService.GetPage(_searchRequests);
        }

        /// <summary>
        /// Updating table data.
        /// </summary>
        private void UpdataSearchRequests()
        {
            _searchRequests.Page = Page.GetPage();
        }
    }
}
