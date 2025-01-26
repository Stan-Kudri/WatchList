using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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
        }

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
                _pagedList = _itemService.GetPage(_searchRequests);
                WatchItems = new ObservableCollection<WatchItem>(_pagedList.Items);
            }
            catch (Exception error)
            {
                await _messageBox.ShowError(error.Message);
            }
        }
    }
}
