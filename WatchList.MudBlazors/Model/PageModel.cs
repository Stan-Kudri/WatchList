using WatchList.Core.PageItem;

namespace WatchList.MudBlazors.Model
{
    public class PageModel : Page
    {
        private const int FirstSizePage = 15;

        public int[] Items { get; set; } = [FirstSizePage, 30, 60];

        public PageModel() : base(NumberStartPage, FirstSizePage)
        {
        }
    }
}
