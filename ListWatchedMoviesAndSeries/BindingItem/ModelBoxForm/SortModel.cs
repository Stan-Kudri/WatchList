using System.Collections.ObjectModel;
using Core.Model.Item;
using Core.Model.Sorting;

namespace ListWatchedMoviesAndSeries.BindingItem.Model
{
    public class SortModel : ModelBase
    {
        private TypesSort _type = TypesSort.Title;

        public ObservableCollection<TypesSort> Items { get; set; } = new ObservableCollection<TypesSort>(TypesSort.List);

        public TypesSort Type
        {
            get => _type;
            set => SetField(ref _type, value);
        }

        public SortItem GetSortItem() => new SortItem(Type);
    }
}
