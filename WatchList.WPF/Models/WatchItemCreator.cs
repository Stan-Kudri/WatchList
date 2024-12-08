using WatchList.Core.Model.ItemCinema;
using WatchList.Core.Model.ItemCinema.Components;

namespace WatchList.WPF.Models
{
    public class WatchItemCreator
    {
        public WatchItemCreator()
        {
        }

        public WatchItem CreateNonPlanned(
                                        string title,
                                        int sequel,
                                        StatusCinema status,
                                        TypeCinema type,
                                        DateTime? date = null,
                                        int? grade = null,
                                        Guid? id = null)
            => new WatchItem(title, sequel, status, type, id, date, grade);

        public WatchItem CreatePlanned(
                                    string title,
                                    int sequel,
                                    StatusCinema status,
                                    TypeCinema type,
                                    Guid? id)
            => new WatchItem(title, sequel, status, type, id, null, null);
    }
}
