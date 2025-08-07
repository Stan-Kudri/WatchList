using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using WatchList.Core.Model.Filter;
using WatchList.Core.Model.ItemCinema.Components;

namespace WatchList.Avalonia.Models.Filter
{
    public partial class FilterItemModel : ObservableObject, IFilterItem
    {
        [ObservableProperty] private List<SelectFilterTypeField> _selectFilterTypeField = [.. TypeCinema.List.Select(item => new SelectFilterTypeField(item))];
        [ObservableProperty] private List<SelectFilterStatusField> _selectFilterStatusFields = [.. StatusCinema.List.Select(item => new SelectFilterStatusField(item))];

        private IEnumerable<TypeCinema> _filterTypeField = new ObservableCollection<TypeCinema>(TypeCinema.List);
        private IEnumerable<StatusCinema> _filterStatusField = new ObservableCollection<StatusCinema>(StatusCinema.List);

        public FilterItemModel()
        {
        }

        public IEnumerable<TypeCinema> FilterTypeField
        {
            get => _filterTypeField;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("The result is not null.", nameof(value));
                }

                if (_filterTypeField == value)
                {
                    return;
                }

                SetProperty(ref _filterTypeField, value);
            }
        }

        public IEnumerable<StatusCinema> FilterStatusField
        {
            get => _filterStatusField;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("The result is not null.", nameof(value));
                }

                if (_filterStatusField == value)
                {
                    return;
                }

                SetProperty(ref _filterStatusField, value);
            }
        }

        public List<TypeCinema> TypeItems { get; set; } = [.. TypeCinema.List];

        public List<StatusCinema> StatusItems { get; set; } = [.. StatusCinema.List];

        public FilterWatchItem GetFilter() => new FilterWatchItem(FilterTypeField, FilterStatusField);

        public void Clear()
        {
            SelectFilterTypeField = [.. TypeCinema.List.Select(item => new SelectFilterTypeField(item))];
            SelectFilterStatusFields = [.. StatusCinema.List.Select(item => new SelectFilterStatusField(item))];
            FilterTypeField = new ObservableCollection<TypeCinema>(SelectFilterTypeField.Where(e => e.IsSelected).Select(e => e.TypeField));
            FilterStatusField = new ObservableCollection<StatusCinema>(SelectFilterStatusFields.Where(e => e.IsSelected).Select(e => e.StatusField));
        }

        public void SetFilter()
        {
            FilterTypeField = new ObservableCollection<TypeCinema>(SelectFilterTypeField.Where(e => e.IsSelected).Select(e => e.TypeField));
            FilterStatusField = new ObservableCollection<StatusCinema>(SelectFilterStatusFields.Where(e => e.IsSelected).Select(e => e.StatusField));
        }

        public string GetSelectTypeFilter => (SelectFilterTypeField.Any(e => e.IsSelected) && SelectFilterTypeField.Count(e => e.IsSelected) != TypeCinema.List.Count)
                                              || (SelectFilterTypeField.Count(e => e.IsSelected) < TypeCinema.List.Count && SelectFilterTypeField.Any(e => e.IsSelected))
                                             ? string.Join(", ", SelectFilterTypeField.Where(e => e.IsSelected).Select(e => e.TypeField.Name))
                                             : SelectFilterTypeField.Any(e => e.IsSelected) == false
                                                ? "No items selected"
                                                : "All Type Cinema";

        public string GetSelectStatusFilter => (SelectFilterStatusFields.Any(e => e.IsSelected) && SelectFilterStatusFields.Count(e => e.IsSelected) != StatusCinema.List.Count)
                                                || (SelectFilterStatusFields.Count(e => e.IsSelected) < StatusCinema.List.Count && SelectFilterStatusFields.Any(e => e.IsSelected))
                                               ? string.Join(", ", SelectFilterStatusFields.Where(e => e.IsSelected).Select(e => e.StatusField.Name))
                                               : SelectFilterStatusFields.Any(e => e.IsSelected) == false
                                                    ? "No items selected"
                                                    : "All Status Cinema";
    }
}
