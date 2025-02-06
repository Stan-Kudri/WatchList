using CommunityToolkit.Mvvm.ComponentModel;
using WatchList.Core.Model.ItemCinema;
using WatchList.Core.PageItem;

namespace WatchList.Avalonia.Models
{
    public partial class DisplayPagination : ObservableObject
    {
        private PagedList<WatchItem> _pagedList;

        [ObservableProperty] private string _pageDisplayText = string.Empty;

        public PagedList<WatchItem> PagedList
        {
            get => _pagedList;
            set
            {
                if (_pagedList != value)
                {
                    SetProperty(ref _pagedList, value);
                    PageDisplayText = _pagedList.HasEmptyPage
                                       ? string.Empty
                                       : $"Page {_pagedList.PageNumber} of {_pagedList.Count}";
                }
            }
        }

        public void Update(PagedList<WatchItem> pagedList) => PagedList = pagedList;
    }
}
