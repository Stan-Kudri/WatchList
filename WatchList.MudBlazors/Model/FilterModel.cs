using System.Collections.ObjectModel;
using Microsoft.AspNetCore.Components;
using WatchList.Core.Model.Filter;
using WatchList.Core.Model.Filter.Components;

namespace WatchList.MudBlazors.Model
{
    public class FilterModel
    {
        public ObservableCollection<TypeFilter> TypeItem { get; set; } = new ObservableCollection<TypeFilter>(TypeFilter.List);

        public ObservableCollection<StatusFilter> StatusItem { get; set; } = new ObservableCollection<StatusFilter>(StatusFilter.List);

        [Parameter]
        public TypeFilter Type { get; set; } = TypeFilter.AllCinema;

        [Parameter]
        public StatusFilter Status { get; set; } = StatusFilter.AllCinema;

        public FilterItem GetFilter() => new FilterItem(Type, Status);

        public void Clear()
        {
            Type = TypeFilter.AllCinema;
            Status = StatusFilter.AllCinema;
        }
    }
}
