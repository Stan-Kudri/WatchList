using Core.Model.Item;
using ListWatchedMoviesAndSeries.Models;

namespace Core.Model
{
    public class SortItem
    {
        public SortCinema SortCinema { get; set; }

        public SortItem() : this(SortCinema.Title)
        {
        }

        public SortItem(SortCinema sortCinema)
        {
            SortCinema = sortCinema;
        }

        public IQueryable<WatchItem> Apply(IQueryable<WatchItem> items)
        {
            var typeSort = SortCinema.Value;
            if (typeSort == SortCinema.Title)
            {
                items = items.OrderBy(x => x.Name);
            }
            else if (typeSort == SortCinema.Type)
            {
                items = items.OrderBy(x => x.Type);
            }
            else if (typeSort == SortCinema.Status)
            {
                items = items.OrderBy(x => x.Status);
            }
            else if (typeSort == SortCinema.Data)
            {
                items = items.OrderByDescending(x => x.Date.ToString());
            }
            else if (typeSort == SortCinema.Sequel)
            {
                items = items.OrderBy(x => x.NumberSequel.ToString());
            }
            else if (typeSort == SortCinema.Grade)
            {
                items = items.OrderByDescending(x => x.Grade);
            }

            return items;
        }

        public override int GetHashCode()
        {
            return SortCinema;
        }
        public override bool Equals(object? obj)
        {
            return Equals(obj as SortCinema);
        }

        public bool Equals(SortCinema? other)
        {
            if (other == null)
                return false;

            return SortCinema == other;
        }
    }
}
