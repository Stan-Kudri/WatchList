using System.Collections.ObjectModel;
using ListWatchedMoviesAndSeries.Models.Item;

namespace ListWatchedMoviesAndSeries.BindingItem.ModelAddAndEditForm
{
    public class TypeModel : ModelBase
    {
        private TypeCinema _type = TypeCinema.Movie;

        public ObservableCollection<TypeCinema> TypesCinema { get; set; } = new ObservableCollection<TypeCinema>()
        {
            TypeCinema.Movie,
            TypeCinema.Series,
            TypeCinema.Anime,
            TypeCinema.Cartoon,
        };

        public TypeCinema Type
        {
            get => _type;
            set => SetField(ref _type, value);
        }
    }
}
