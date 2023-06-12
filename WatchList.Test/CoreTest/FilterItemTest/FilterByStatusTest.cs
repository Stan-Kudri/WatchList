using FluentAssertions;
using WatchList.Core.Model.Filter;
using WatchList.Core.Model.Filter.Components;
using WatchList.Core.Model.ItemCinema;
using WatchList.Core.Model.ItemCinema.Components;
using WatchList.Core.Model.Sorting;
using WatchList.Core.PageItem;

namespace WatchList.Test.CoreTest.FilterItemTest
{
    public class FilterByStatusTest
    {
        public static IEnumerable<object[]> ItemsToCheckFilterByStatusViewed() => new List<object[]>
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
                },
                new List<WatchItem>()
                {
                    new WatchItem("Тор", 1, StatusCinema.Viewed, TypeCinema.Cartoon, Guid.Parse("18d4a732-ca7a-4b24-a78a-65733ba419a7"), new DateTime(2013, 05, 11, 00, 00, 00), 8),
                },
            },
        };

        public static IEnumerable<object[]> ItemsToCheckFilterByStatusPlanned() => new List<object[]>
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
                },
                new List<WatchItem>()
                {
                    new WatchItem("Человек-паук", 2, StatusCinema.Planned, TypeCinema.Series, Guid.Parse("38d4a999-ca7a-4b24-a78a-65733ba419a7")),
                    new WatchItem("Драйв", 2, StatusCinema.Planned, TypeCinema.Movie, Guid.Parse("48d4a999-ca7a-4b24-a78a-65733ba419a7")),
                },
            },
        };

        public static IEnumerable<object[]> ItemsToCheckFilterByStatusThrown() => new List<object[]>
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
                },
                new List<WatchItem>()
                {
                    new WatchItem("Твое имя", 2, StatusCinema.Thrown, TypeCinema.Anime, Guid.Parse("58d4a999-ca7a-4b24-a78a-65733ba419a7")),
                },
            },
        };

        public static IEnumerable<object[]> ItemsToCheckFilterByStatusLook() => new List<object[]>
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
                },
                new List<WatchItem>()
                {
                    new WatchItem("Хэнкок", 2, StatusCinema.Look, TypeCinema.Movie, Guid.Parse("28d4a999-ca7a-4b24-a78a-65733ba419a7"), new DateTime(2015, 04, 12, 00, 00, 00), 9),
                },
            },
        };

        [Theory]
        [MemberData(nameof(ItemsToCheckFilterByStatusViewed))]
        public void List_0f_Filter_Items_By_Status_Viewed(List<WatchItem> watchItems, List<WatchItem> expectWatchItems)
        {
            // Assert
            CheckListEqualAfterApplyFilter(watchItems, StatusFilter.ViewedCinema, expectWatchItems);
        }

        [Theory]
        [MemberData(nameof(ItemsToCheckFilterByStatusPlanned))]
        public void List_0f_Filter_Items_By_Status_Planned_Watch(List<WatchItem> watchItems, List<WatchItem> expectWatchItems)
        {
            // Assert
            CheckListEqualAfterApplyFilter(watchItems, StatusFilter.PlannedWatchCinema, expectWatchItems);
        }

        [Theory]
        [MemberData(nameof(ItemsToCheckFilterByStatusThrown))]
        public void List_0f_Filter_Items_By_Status_Thrown(List<WatchItem> watchItems, List<WatchItem> expectWatchItems)
        {
            // Assert
            CheckListEqualAfterApplyFilter(watchItems, StatusFilter.ThrownCinema, expectWatchItems);
        }

        [Theory]
        [MemberData(nameof(ItemsToCheckFilterByStatusLook))]
        public void List_0f_Filter_Items_By_Status_Look(List<WatchItem> watchItems, List<WatchItem> expectWatchItems)
        {
            // Assert
            CheckListEqualAfterApplyFilter(watchItems, StatusFilter.LookCinema, expectWatchItems);
        }

        private void CheckListEqualAfterApplyFilter(List<WatchItem> watchItems, StatusFilter statusFilter, List<WatchItem> expectWatchItems)
        {
            // Arrange
            var dbContext = new TestAppDbContextFactory().Create();
            var watchItemSearchRequest = new WatchItemSearchRequest(new FilterItem(TypeFilter.AllCinema, statusFilter), SortField.Title, new Page());

            // Act
            dbContext.AddRange(watchItems);
            dbContext.SaveChanges();
            var actualWatchItem = watchItemSearchRequest.ApplyFilter(dbContext.WatchItem).ToList();

            // Assert
            actualWatchItem.Should().Equal(expectWatchItems);
        }
    }
}
