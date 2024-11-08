using System.Collections.ObjectModel;
using WatchList.Core.PageItem;

namespace WatchList.WPF.Models
{
    public class PageModel : BindingBaseModel
    {
        private const int StartPageSize = 10;
        private const int NumberStartPage = 1;

        private int _size;
        private int _number;

        public PageModel(int pageNumber = NumberStartPage, int pageSize = StartPageSize)
        {
            Number = pageNumber;
            Size = pageSize;
        }

        public ObservableCollection<int> Items { get; set; } = new ObservableCollection<int> { 10, 25, 50 };

        public int Number
        {
            get => _number;
            set
            {
                _number = value;
                OnPropertyChanged("Number");
            }
        }

        public int Size
        {
            get => _size;
            set
            {
                _size = value;
                OnPropertyChanged("Size");
            }
        }

        public Page GetPage() => new Page(_number, _size);

        public bool ChangedPage(int pageSize) => pageSize != _size;
    }
}
