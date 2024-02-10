using WatchList.Core.PageItem;

namespace WatchList.MudBlazors.Model
{
    public class PageModel : Page
    {
        public PageModel()
            : base()
        {
        }

        public PageModel(int pageNumber, int pageSize)
            : base(pageNumber, pageSize)
        {
        }

        public int[] Items { get; set; } = new int[] { 20, 40, 60 };

        public Page GetPage() => new Page(_number, _size);

        public bool ChangedPage(int pageSize) => pageSize != _size;
    }
}
