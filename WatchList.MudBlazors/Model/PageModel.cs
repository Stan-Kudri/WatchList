using WatchList.Core.PageItem;

namespace WatchList.MudBlazors.Model
{
    public class PageModel : Page
    {
        private const int FirstSizePage = 20;

        public static int[] Items { get; set; } = new int[] { FirstSizePage, 40, 60 };

        public PageModel()
            : base(NumberStartPage, FirstSizePage)
        {
        }

        public PageModel(int pageNumber = 1, int pageSize = FirstSizePage)
            : base(pageNumber, pageSize)
        {
        }

        public Page GetPage() => new Page(_number, _size);

        public bool ChangedPage(int pageSize) => pageSize != _size;
    }
}
