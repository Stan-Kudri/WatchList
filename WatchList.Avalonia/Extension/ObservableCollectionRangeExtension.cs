using System.Collections.Generic;
using System.Collections.ObjectModel;
using WatchList.Core.Model.ItemCinema;

namespace WatchList.Avalonia.Extension
{
    public static class ObservableCollectionRangeExtension
    {
        public static ObservableCollection<WatchItem> UppdataItems(this ObservableCollection<WatchItem> collection, List<WatchItem> values)
        {
            collection.Clear();
            return AddRange(collection, values);
        }

        public static ObservableCollection<WatchItem> AddRange(this ObservableCollection<WatchItem> collection, List<WatchItem> values)
        {
            foreach (var item in values)
            {
                collection.Add(item);
            }

            return collection;
        }
    }
}
