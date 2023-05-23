using WatchList.Core.Model.ItemCinema;
using WatchList.Core.Model.ItemCinema.Components;
using WatchList.Core.PageItem;

namespace WatchList.Test.CoreTest
{
    public class PagedListTest
    {
        private const int StartPageSize = 5;
        private const int NumberStartPage = 1;

        public static IEnumerable<object[]> WatchListItem() => new List<object[]>
        {
            new object[]
            {
                new List<WatchItem>()
                {
                    new WatchItem("Тор", 1, StatusCinema.Viewed, TypeCinema.Movie, Guid.Parse("18d4a732-ca7a-4b24-a78a-65733ba419a7"), new DateTime(2013, 05, 11, 00, 00, 00), 8),
                    new WatchItem("Хэнкок", 2, StatusCinema.Look, TypeCinema.Movie, Guid.Parse("18d4a999-ca7a-4b24-a78a-65733ba419a7"), new DateTime(2015, 04, 12, 00, 00, 00), 9),
                    new WatchItem("Человек-паук", 2, StatusCinema.Planned, TypeCinema.Movie, Guid.Parse("18d4a999-ca7a-4b24-a78a-65733ba419a7")),
                    new WatchItem("Драйв", 2, StatusCinema.Planned, TypeCinema.Movie, Guid.Parse("18d4a999-ca7a-4b24-a78a-65733ba419a7")),
                    new WatchItem("Залечь на дно в Брюгге", 2, StatusCinema.Viewed, TypeCinema.Movie, Guid.Parse("18d4a999-ca7a-4b24-a78a-65733ba419a7"), new DateTime(2022, 09, 10, 00, 00, 00), 10),
                    new WatchItem("Джокер", 2, StatusCinema.Viewed, TypeCinema.Movie, Guid.Parse("18d4a999-ca7a-4b24-a78a-65733ba419a7"), new DateTime(2020, 12, 10, 00, 00, 00), 10),
                },
            },
        };

        [Theory]
        [InlineData(null, 5, 1, 0)]
        public void Exception_By_Null_List(List<WatchItem> watchItems, int pageSize, int numberPage, int totalItem)
        {
            // Assert
            Assert.Throws<ArgumentNullException>(() =>
                {
                    new PagedList<WatchItem>(watchItems, numberPage, pageSize, totalItem);
                });
        }

        [Theory]
        [MemberData(nameof(WatchListItem))]
        public void Invalid_Page_Number_Exception(List<WatchItem> watchItems)
        {
            // Arrange
            var pageNumber = -2;
            var pageSize = StartPageSize;
            var totalItem = watchItems.Count;

            // Assert
            Assert.Throws<ArgumentException>(() => { new PagedList<WatchItem>(watchItems, pageNumber, pageSize, totalItem); });
        }

        [Theory]
        [MemberData(nameof(WatchListItem))]
        public void Invalid_Size_Page_Exception(List<WatchItem> watchItems)
        {
            // Arrange
            var pageNumber = NumberStartPage;
            var pageSize = 0;
            var totalItem = watchItems.Count;

            // Assert
            Assert.Throws<ArgumentException>(() => { new PagedList<WatchItem>(watchItems, pageNumber, pageSize, totalItem); });
        }

        [Theory]
        [MemberData(nameof(WatchListItem))]
        public void Invalid_Total_Item_Exception(List<WatchItem> watchItems)
        {
            // Arrange
            var pageNumber = NumberStartPage;
            var pageSize = StartPageSize;
            var totalItem = -2;

            // Assert
            Assert.Throws<ArgumentException>(() => { new PagedList<WatchItem>(watchItems, pageNumber, pageSize, totalItem); });
        }
    }
}
