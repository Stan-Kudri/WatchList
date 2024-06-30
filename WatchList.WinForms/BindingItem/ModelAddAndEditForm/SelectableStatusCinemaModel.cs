using System.Collections.ObjectModel;
using WatchList.Core.Model.ItemCinema.Components;

namespace WatchList.WinForms.BindingItem.ModelAddAndEditForm
{
    public class SelectableStatusCinemaModel : ModelBase
    {
        private StatusCinema _status = StatusCinema.Planned;

        public SelectableStatusCinemaModel()
        {
        }

        public SelectableStatusCinemaModel(StatusCinema status) => ValueStatus = status;

        public ObservableCollection<StatusCinema> Items { get; set; } =
            new ObservableCollection<StatusCinema>(StatusCinema.List);

        public StatusCinema ValueStatus
        {
            get => _status;
            set => SetField(ref _status, value);
        }
    }
}
