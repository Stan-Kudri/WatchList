using System.Collections.Generic;
using CommunityToolkit.Mvvm.ComponentModel;
using WatchList.Core.PageItem;

namespace WatchList.Avalonia.Models
{
    public partial class PageModel : ObservableObject
    {
        private const int StartPageSize = 10;
        private const int NumberStartPage = 1;

        [ObservableProperty] private int _size;

        [ObservableProperty] private int _number;

        public PageModel(int pageNumber = NumberStartPage, int pageSize = StartPageSize)
        {
            _number = pageNumber;
            _size = pageSize;
        }

        public List<int> Items { get; set; } = new List<int> { 10, 25, 50 };

        public Page GetPage() => new(_number, _size);

        public bool ChangedPage(int pageSize) => pageSize != _size;
    }
}
