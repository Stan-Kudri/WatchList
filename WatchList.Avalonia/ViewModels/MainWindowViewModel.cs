using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using ReactiveUI;
using WatchList.Avalonia.Extension;
using WatchList.Avalonia.Models;
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

        private readonly WatchItemService _itemService;
        private readonly IMessageBox _messageBox;
        private readonly IServiceProvider _serviceProvider;

        private readonly ItemSearchRequest _searchRequests;

        private PagedList<WatchItem> _pagedList;

        [ObservableProperty] private WatchItem _selectItem;
        [ObservableProperty] private IList _selectItems = new ArrayList();

        [ObservableProperty] private DisplayPagination _displayPagination = new DisplayPagination();
        [ObservableProperty] private PageModel _page;

        public ObservableCollection<WatchItem> WatchItems { get; private set; } = new ObservableCollection<WatchItem>();

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
        private async Task MoveEditItem()
        {
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
        private async Task DeleteItem()
        {
            if (SelectItem == null)
            {
                await _messageBox.ShowInfo(HighlightTheDesiredLine);
                return;
            }

            if (!await _messageBox.ShowQuestion("Delete select items?"))
            {
                return;
            }

            _itemService.Remove(SelectItem.Id);

            await LoadDataAsync();
        }

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
