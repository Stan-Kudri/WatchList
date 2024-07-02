using System.Collections.ObjectModel;

namespace WatchList.Core.Model
{
    public class SmartEnumBaseWrapper<T> : Wrapper<T>
        where T : class
    {
        protected static ObservableCollection<TWrapper> GetItems<TWrapper>(IEnumerable<T> items, Func<T?, TWrapper> factory)
            where TWrapper : Wrapper<T>
        {
            var itemsCollection = new ObservableCollection<TWrapper>();
            itemsCollection.Add(factory(null));
            foreach (var item in items)
            {
                itemsCollection.Add(factory(item));
            }

            return itemsCollection;
        }
    }
}
