using FluentAssertions;
using WatchList.Core.Model.Filter;
using WatchList.Core.Model.Filter.Components;
using WatchList.Core.Model.ItemCinema;
using WatchList.Core.Model.ItemCinema.Components;
using WatchList.Core.Model.Sorting;
using WatchList.Core.PageItem;
using WatchList.Core.Repository;

namespace WatchList.Test.CoreTest
{
    public class WatchItemRepositoryTest
    {
        public static IEnumerable<object[]> WatchListItemPage() => new List<object[]>
        {
            new object[]
            {
                new List<WatchItem>()
                {
                    new WatchItem("Тор", 1, StatusCinema.Viewed, TypeCinema.Movie, Guid.Parse("18d4a732-ca7a-4b24-a78a-65733ba419a7"), new DateTime(2013, 05, 11, 00, 00, 00), 8),
                    new WatchItem("Хэнкок", 2, StatusCinema.Look, TypeCinema.Movie, Guid.Parse("28d4a999-ca7a-4b24-a78a-65733ba419a7"), new DateTime(2015, 04, 12, 00, 00, 00), 9),
                    new WatchItem("Человек-паук", 2, StatusCinema.Planned, TypeCinema.Series, Guid.Parse("38d4a999-ca7a-4b24-a78a-65733ba419a7")),
                    new WatchItem("Драйв", 2, StatusCinema.Planned, TypeCinema.Movie, Guid.Parse("48d4a999-ca7a-4b24-a78a-65733ba419a7")),
                    new WatchItem("Залечь на дно в Брюгге", 2, StatusCinema.Viewed, TypeCinema.Movie, Guid.Parse("58d4a999-ca7a-4b24-a78a-65733ba419a7"), new DateTime(2022, 09, 10, 00, 00, 00), 10),
                    new WatchItem("Джокер", 2, StatusCinema.Viewed, TypeCinema.Movie, Guid.Parse("68d4a999-ca7a-4b24-a78a-65733ba419a7"), new DateTime(2020, 12, 10, 00, 00, 00), 10),
                },

                new WatchItemSearchRequest(
                    new FilterItem(TypeFilter.Movie, StatusFilter.ViewedCinema),
                    SortField.Grade,
                    new Page(1, 5)),

                new List<WatchItem>()
                {
                    new WatchItem("Залечь на дно в Брюгге", 2, StatusCinema.Viewed, TypeCinema.Movie, Guid.Parse("58d4a999-ca7a-4b24-a78a-65733ba419a7"), new DateTime(2022, 09, 10, 00, 00, 00), 10),
                    new WatchItem("Джокер", 2, StatusCinema.Viewed, TypeCinema.Movie, Guid.Parse("68d4a999-ca7a-4b24-a78a-65733ba419a7"), new DateTime(2020, 12, 10, 00, 00, 00), 10),
                    new WatchItem("Тор", 1, StatusCinema.Viewed, TypeCinema.Movie, Guid.Parse("18d4a732-ca7a-4b24-a78a-65733ba419a7"), new DateTime(2013, 05, 11, 00, 00, 00), 8),
                },
            },
        };

        public static IEnumerable<object[]> WatchListItemUpdate() => new List<object[]>
        {
            new object[]
            {
                new List<WatchItem>()
                {
                    new WatchItem("Залечь на дно в Брюгге", 2, StatusCinema.Viewed, TypeCinema.Movie, Guid.Parse("58d4a999-ca7a-4b24-a78a-65733ba419a7"), new DateTime(2022, 09, 10, 00, 00, 00), 10),
                    new WatchItem("Джокер", 2, StatusCinema.Viewed, TypeCinema.Movie, Guid.Parse("68d4a999-ca7a-4b24-a78a-65733ba419a7"), new DateTime(2020, 12, 10, 00, 00, 00), 10),
                    new WatchItem("Тор", 1, StatusCinema.Viewed, TypeCinema.Movie, Guid.Parse("18d4a732-ca7a-4b24-a78a-65733ba419a7"), new DateTime(2013, 05, 11, 00, 00, 00), 8),
                },

                new WatchItem("Престиж", 2, StatusCinema.Viewed, TypeCinema.Movie, Guid.Parse("58d4a999-ca7a-4b24-a78a-65733ba419a7"), new DateTime(2022, 06, 10, 00, 00, 00), 10),

                new List<WatchItem>()
                {
                    new WatchItem("Джокер", 2, StatusCinema.Viewed, TypeCinema.Movie, Guid.Parse("68d4a999-ca7a-4b24-a78a-65733ba419a7"), new DateTime(2020, 12, 10, 00, 00, 00), 10),
                    new WatchItem("Престиж", 2, StatusCinema.Viewed, TypeCinema.Movie, Guid.Parse("58d4a999-ca7a-4b24-a78a-65733ba419a7"), new DateTime(2022, 06, 10, 00, 00, 00), 10),
                    new WatchItem("Тор", 1, StatusCinema.Viewed, TypeCinema.Movie, Guid.Parse("18d4a732-ca7a-4b24-a78a-65733ba419a7"), new DateTime(2013, 05, 11, 00, 00, 00), 8),
                },
            },
        };

        [Theory]
        [MemberData(nameof(WatchListItemPage))]
        public void Verifying_The_Use_Of_The_Database_Page_Get_Method(
            List<WatchItem> watchItems,
            WatchItemSearchRequest searchRequest,
            List<WatchItem> expectWatchItems)
        {
            // Arrange
            var appDbContext = new TestAppDbContextFactory().Create();
            var itemRepository = new WatchItemRepository(appDbContext);

            // Act
            itemRepository.Add(watchItems);
            var pageItem = itemRepository.GetPageCinema(searchRequest);
            var actualItemPage = pageItem.Items;

            actualItemPage.Should().Equal(expectWatchItems);
        }

        [Theory]
        [MemberData(nameof(WatchListItemUpdate))]
        public void Verifying_The_Use_Of_The_Update_Item_Method(
            List<WatchItem> watchItems,
            WatchItem updateItem,
            List<WatchItem> expectWatchItems)
        {
            // Arrange
            var appDbContext = new TestAppDbContextFactory().Create();
            var itemRepository = new WatchItemRepository(appDbContext);
            var searchRequest = new WatchItemSearchRequest();

            // Act
            itemRepository.Add(watchItems);
            itemRepository.Update(updateItem);
            var actualItemPage = itemRepository.GetPageCinema(searchRequest).Items;

            actualItemPage.Should().Equal(expectWatchItems);
        }
    }
}
