using Core.Model.Item;
using Core.Model.ItemCinema;

namespace Core.Model.Sorting
{
    public class SortItem : IEquatable<TypesSort>
    {
        public TypesSort SortCinema { get; set; }

        public SortItem() : this(TypesSort.Title)
        {
        }

        public SortItem(TypesSort sortCinema)
        {
            SortCinema = sortCinema;
        }

        public IQueryable<WatchItem> Apply(IQueryable<WatchItem> items)
        {
            var typeSort = SortCinema.Value;

            if (typeSort == TypesSort.Title)
            {
                items = items.OrderBy(x => x.Name);
            }
            else if (typeSort == TypesSort.Type)
            {
                items = items.OrderBy(x => x.Type);
            }
            else if (typeSort == TypesSort.Status)
            {
                items = items.OrderBy(x => x.Status);
            }
            else if (typeSort == TypesSort.Data)
            {
                items = items.OrderByDescending(x => x.Date);
            }
            else if (typeSort == TypesSort.Sequel)
            {
                items = items.OrderBy(x => x.NumberSequel);
            }
            else if (typeSort == TypesSort.Grade)
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
            return Equals(obj as TypesSort);
        }

        public bool Equals(TypesSort? other)
        {
            if (other == null)
                return false;

            return SortCinema == other;
        }
    }
}
