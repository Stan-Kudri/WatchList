using WatchList.Core.PageItem;

namespace WatchList.MudBlazors.Model
{
    public class PageModel : Page
    {
        private const int FirstSizePage = 20;

        public int[] Items { get; set; } = new int[] { FirstSizePage, 40, 60 };

        public PageModel() : base(NumberStartPage, FirstSizePage)
        {
        }
    }
}
