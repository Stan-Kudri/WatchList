using System.Collections.ObjectModel;

namespace WatchList.Core.Extension
{
    public static class EnumerableExtensions
    {
        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> source)
            => new ObservableCollection<T>(source);

        public static List<T> ToListCollection<T>(this IEnumerable<T> source) => [.. source];
    }
}
