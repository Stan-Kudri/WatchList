using System.Collections.ObjectModel;
using WatchList.Core.PageItem;

namespace WatchList.WinForms.BindingItem.ModelBoxForm
{
    public class PageModel : ModelBase
    {
        private const int StartPageSize = 5;
        private const int NumberStartPage = 1;

        private int _size;

        private int _number;

        public PageModel(int pageNumber = StartPageSize, int pageSize = NumberStartPage)
        {
            Number = pageNumber;
            Size = pageSize;
        }

        public ObservableCollection<int> Items { get; set; } = new ObservableCollection<int> { 5, 10, 20 };

        public int Number
        {
            get => _number;
            set => SetField(ref _number, value);
        }

        public int Size
        {
            get => _size;
            set => SetField(ref _size, value);
        }

        public Page GetPage() => new Page(_number, _size);

        public bool ChangedPage(int pageSize) => pageSize != _size;
    }
}
