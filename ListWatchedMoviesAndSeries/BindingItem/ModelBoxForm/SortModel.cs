using System.Collections.ObjectModel;
using Core.Model.Item;
using Core.Model.Sorting;

namespace ListWatchedMoviesAndSeries.BindingItem.Model
{
    public class SortModel : ModelBase
    {
        private SortField _type = SortField.Title;

        public ObservableCollection<SortField> Items { get; set; } = new ObservableCollection<SortField>(SortField.List);

        public SortField Type
        {
            get => _type;
            set => SetField(ref _type, value);
        }

        public SortItem GetSortItem() => new SortItem(Type);
    }
}
