using System.Collections.ObjectModel;
using Core.Repository;

namespace ListWatchedMoviesAndSeries.BindingItem.Model
{
    public class PageModel : ModelBase
    {
        private int _size;

        private int _number;

        public PageModel()
            : this(1, 5)
        {
        }

        public PageModel(int pageNumber, int pageSize)
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

        public Page GetPage() => new Page(Number, Size);
    }
}
