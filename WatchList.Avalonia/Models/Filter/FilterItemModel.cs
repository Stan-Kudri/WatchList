using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using WatchList.Core.Model.Filter;
using WatchList.Core.Model.ItemCinema.Components;

namespace WatchList.Avalonia.Models.Filter
{
    public class FilterItemModel : ObservableObject, IFilterItem
    {
        private IEnumerable<TypeCinema> _filterTypeField = new ObservableCollection<TypeCinema>(TypeCinema.List);
        private IEnumerable<StatusCinema> _filterStatusField = new ObservableCollection<StatusCinema>(StatusCinema.List);

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

        public FilterWatchItem GetFilter() => new FilterWatchItem(_filterTypeField, _filterStatusField);

        public void Clear()
        {
            FilterTypeField = new ObservableCollection<TypeCinema>(TypeCinema.List);
            FilterStatusField = new ObservableCollection<StatusCinema>(StatusCinema.List);
        }
    }
}
