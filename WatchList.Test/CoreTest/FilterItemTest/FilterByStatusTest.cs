using FluentAssertions;
using WatchList.Core.Model.Filter;
using WatchList.Core.Model.Filter.Components;
using WatchList.Core.Model.ItemCinema;
using WatchList.Core.Model.ItemCinema.Components;
using WatchList.Core.Model.Sorting;
using WatchList.Core.PageItem;
using WatchList.Core.Repository;

namespace WatchList.Test.CoreTest.FilterItemTest
{
    public class FilterByStatusTest
    {
        public static IEnumerable<object[]> WatchListItemAndFilter() => new List<object[]>
        {
            new object[]
            {
                new List<WatchItem>()
                {
                    new WatchItem("Тор", 1, StatusCinema.Viewed, TypeCinema.Cartoon, Guid.Parse("18d4a732-ca7a-4b24-a78a-65733ba419a7"), new DateTime(2013, 05, 11, 00, 00, 00), 8),
                    new WatchItem("Хэнкок", 2, StatusCinema.Look, TypeCinema.Movie, Guid.Parse("28d4a999-ca7a-4b24-a78a-65733ba419a7"), new DateTime(2015, 04, 12, 00, 00, 00), 9),
                    new WatchItem("Человек-паук", 2, StatusCinema.Planned, TypeCinema.Series, Guid.Parse("38d4a999-ca7a-4b24-a78a-65733ba419a7")),
                    new WatchItem("Драйв", 2, StatusCinema.Planned, TypeCinema.Movie, Guid.Parse("48d4a999-ca7a-4b24-a78a-65733ba419a7")),
                    new WatchItem("Твое имя", 2, StatusCinema.Thrown, TypeCinema.Anime, Guid.Parse("58d4a999-ca7a-4b24-a78a-65733ba419a7")),
                    new WatchItem("Джокер", 2, StatusCinema.Viewed, TypeCinema.Movie, Guid.Parse("68d4a999-ca7a-4b24-a78a-65733ba419a7"), new DateTime(2020, 12, 10, 00, 00, 00), 10),
                },
            },
        };

        [Theory]
        [MemberData(nameof(WatchListItemAndFilter))]
        public void List_0f_Filter_Items_By_Status_Look(List<WatchItem> watchItems)
        {
            // Arrange
            var statusFilter = StatusFilter.LookCinema;

            // Act
            var items = TwoListsToCheckTheFilter(watchItems, statusFilter);

            // Assert
            items.actual.Should().Equal(items.expect);
        }

        [Theory]
        [MemberData(nameof(WatchListItemAndFilter))]
        public void List_0f_Filter_Items_By_Status_Planned_Watch(List<WatchItem> watchItems)
        {
            // Arrange
            var statusFilter = StatusFilter.PlannedWatchCinema;

            // Act
            var items = TwoListsToCheckTheFilter(watchItems, statusFilter);

            // Assert
            items.actual.Should().Equal(items.expect);
        }

        [Theory]
        [MemberData(nameof(WatchListItemAndFilter))]
        public void List_0f_Filter_Items_By_Status_Thrown(List<WatchItem> watchItems)
        {
            // Arrange
            var statusFilter = StatusFilter.ThrownCinema;

            // Act
            var items = TwoListsToCheckTheFilter(watchItems, statusFilter);

            // Assert
            items.actual.Should().Equal(items.expect);
        }

        [Theory]
        [MemberData(nameof(WatchListItemAndFilter))]
        public void List_0f_Filter_Items_By_Status_Viewed(List<WatchItem> watchItems)
        {
            // Arrange
            var statusFilter = StatusFilter.ViewedCinema;

            // Act
            var items = TwoListsToCheckTheFilter(watchItems, statusFilter);

            // Assert
            items.actual.Should().Equal(items.expect);
        }

        private (List<WatchItem> actual, List<WatchItem> expect) TwoListsToCheckTheFilter(List<WatchItem> watchItems, StatusFilter statusFilter)
        {
            var dbContext = new TestAppDbContextFactory().Create();
            var itemRepository = new WatchItemRepository(dbContext);
            var watchItemSearchRequest = new WatchItemSearchRequest(new FilterItem(TypeFilter.AllCinema, statusFilter), SortField.Title, new Page(1, 6));

            var expectWatchItems = watchItems.Where(x => x.Status == statusFilter).ToList();
            itemRepository.Add(watchItems);
            var actualWatchItem = watchItemSearchRequest.ApplyFilter(dbContext.WatchItem).ToList();

            return (actualWatchItem, expectWatchItems);
        }
    }
}
