using System.Collections.ObjectModel;
using Core.Model.Item;

namespace ListWatchedMoviesAndSeries.BindingItem.ModelAddAndEditForm
{
    public class SelectableStatusCinemaModel : ModelBase
    {
        private StatusCinema _status = StatusCinema.Planned;

        public SelectableStatusCinemaModel()
        {
        }

        public SelectableStatusCinemaModel(StatusCinema status) => ValueStatus = status;

        public ObservableCollection<StatusCinema> Items { get; set; } =
            new ObservableCollection<StatusCinema>(StatusCinema.List.Where(x => x != StatusCinema.AllStatus));

        public StatusCinema ValueStatus
        {
            get => _status;
            set => SetField(ref _status, value);
        }
    }
}
