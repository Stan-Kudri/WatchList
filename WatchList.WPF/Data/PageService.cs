using System.Windows.Controls;

namespace WatchList.WPF.Data
{
    public class PageService
    {
        public event Action<object, Page>? PageChanged;

        public void Open(object sender, Page page) => PageChanged?.Invoke(sender, page);
    }
}
