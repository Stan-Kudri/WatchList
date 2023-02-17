using Core.Model.Item;
using Core.Model.ItemCinema;

namespace Core.Model.Sorting
{
    public class SortItem : IEquatable<SortField>
    {
        public SortField SortCinema { get; set; }

        public SortItem() : this(SortField.Name)
        {
        }

        public SortItem(SortField sortCinema)
        {
            SortCinema = sortCinema;
        }

        public IQueryable<WatchItem> Apply(IQueryable<WatchItem> items)
        {
            var typeSort = SortCinema.Value;

            if (typeSort == SortField.Name)
            {
                items = items.OrderBy(x => x.Name);
            }
            else if (typeSort == SortField.Type)
            {
                items = items.OrderBy(x => x.Type);
            }
            else if (typeSort == SortField.Status)
            {
                items = items.OrderBy(x => x.Status);
            }
            else if (typeSort == SortField.Data)
            {
                items = items.OrderByDescending(x => x.Date);
            }
            else if (typeSort == SortField.Sequel)
            {
                items = items.OrderBy(x => x.Sequel);
            }
            else if (typeSort == SortField.Grade)
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
            return Equals(obj as SortField);
        }

        public bool Equals(SortField? other)
        {
            if (other == null)
                return false;

            return SortCinema == other;
        }
    }
}
