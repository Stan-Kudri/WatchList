using FluentAssertions;
using WatchList.Core.Model.Filter;
using WatchList.Core.Model.ItemCinema;
using WatchList.Core.Model.ItemCinema.Components;
using WatchList.Core.Model.Sortable;
using WatchList.Core.PageItem;
using WatchList.Test.Components;

namespace WatchList.Test.CoreTest.FilterItemTest
{
    public class FilterByTypeTest
    {
        public static IEnumerable<object[]> ItemsToCheckFilterByTypeMovie() => new List<object[]>
        {
            new object[]
            {
                new List<WatchItem>()
                {
                    new WatchItem("Тор", 1, StatusCinema.Viewed, TypeCinema.Cartoon, Guid.Parse("18d4a732-ca7a-4b24-a78a-65733ba419a7"), new DateTime(2013, 05, 11, 00, 00, 00), 8),
                    new WatchItem("Хэнкок", 2, StatusCinema.Look, TypeCinema.Movie, Guid.Parse("28d4a999-ca7a-4b24-a78a-65733ba419a7"), new DateTime(2015, 04, 12, 00, 00, 00), 9),
                    new WatchItem("Человек-паук", 2, StatusCinema.Planned, TypeCinema.Series, Guid.Parse("38d4a999-ca7a-4b24-a78a-65733ba419a7")),
                    new WatchItem("Драйв", 2, StatusCinema.Planned, TypeCinema.Movie, Guid.Parse("48d4a999-ca7a-4b24-a78a-65733ba419a7")),
                    new WatchItem("Твое имя", 2, StatusCinema.Viewed, TypeCinema.Anime, Guid.Parse("58d4a999-ca7a-4b24-a78a-65733ba419a7"), new DateTime(2022, 09, 10, 00, 00, 00), 10),
                },
                new List<WatchItem>()
                {
                    new WatchItem("Хэнкок", 2, StatusCinema.Look, TypeCinema.Movie, Guid.Parse("28d4a999-ca7a-4b24-a78a-65733ba419a7"), new DateTime(2015, 04, 12, 00, 00, 00), 9),
                    new WatchItem("Драйв", 2, StatusCinema.Planned, TypeCinema.Movie, Guid.Parse("48d4a999-ca7a-4b24-a78a-65733ba419a7")),
                },
            },
        };

        public static IEnumerable<object[]> ItemsToCheckFilterByTypeCartoon() => new List<object[]>
        {
            new object[]
            {
                new List<WatchItem>()
                {
                    new WatchItem("Тор", 1, StatusCinema.Viewed, TypeCinema.Cartoon, Guid.Parse("18d4a732-ca7a-4b24-a78a-65733ba419a7"), new DateTime(2013, 05, 11, 00, 00, 00), 8),
                    new WatchItem("Хэнкок", 2, StatusCinema.Look, TypeCinema.Movie, Guid.Parse("28d4a999-ca7a-4b24-a78a-65733ba419a7"), new DateTime(2015, 04, 12, 00, 00, 00), 9),
                    new WatchItem("Человек-паук", 2, StatusCinema.Planned, TypeCinema.Series, Guid.Parse("38d4a999-ca7a-4b24-a78a-65733ba419a7")),
                    new WatchItem("Драйв", 2, StatusCinema.Planned, TypeCinema.Movie, Guid.Parse("48d4a999-ca7a-4b24-a78a-65733ba419a7")),
                    new WatchItem("Твое имя", 2, StatusCinema.Viewed, TypeCinema.Anime, Guid.Parse("58d4a999-ca7a-4b24-a78a-65733ba419a7"), new DateTime(2022, 09, 10, 00, 00, 00), 10),
                },
                new List<WatchItem>()
                {
                    new WatchItem("Тор", 1, StatusCinema.Viewed, TypeCinema.Cartoon, Guid.Parse("18d4a732-ca7a-4b24-a78a-65733ba419a7"), new DateTime(2013, 05, 11, 00, 00, 00), 8),
                },
            },
        };

        public static IEnumerable<object[]> ItemsToCheckFilterByTypeSeries() => new List<object[]>
        {
            new object[]
            {
                new List<WatchItem>()
                {
                    new WatchItem("Тор", 1, StatusCinema.Viewed, TypeCinema.Cartoon, Guid.Parse("18d4a732-ca7a-4b24-a78a-65733ba419a7"), new DateTime(2013, 05, 11, 00, 00, 00), 8),
                    new WatchItem("Хэнкок", 2, StatusCinema.Look, TypeCinema.Movie, Guid.Parse("28d4a999-ca7a-4b24-a78a-65733ba419a7"), new DateTime(2015, 04, 12, 00, 00, 00), 9),
                    new WatchItem("Человек-паук", 2, StatusCinema.Planned, TypeCinema.Series, Guid.Parse("38d4a999-ca7a-4b24-a78a-65733ba419a7")),
                    new WatchItem("Драйв", 2, StatusCinema.Planned, TypeCinema.Movie, Guid.Parse("48d4a999-ca7a-4b24-a78a-65733ba419a7")),
                    new WatchItem("Твое имя", 2, StatusCinema.Viewed, TypeCinema.Anime, Guid.Parse("58d4a999-ca7a-4b24-a78a-65733ba419a7"), new DateTime(2022, 09, 10, 00, 00, 00), 10),
                },
                new List<WatchItem>()
                {
                    new WatchItem("Человек-паук", 2, StatusCinema.Planned, TypeCinema.Series, Guid.Parse("38d4a999-ca7a-4b24-a78a-65733ba419a7")),
                },
            },
        };

        public static IEnumerable<object[]> ItemsToCheckFilterByTypeAnime() => new List<object[]>
        {
            new object[]
            {
                new List<WatchItem>()
                {
                    new WatchItem("Тор", 1, StatusCinema.Viewed, TypeCinema.Cartoon, Guid.Parse("18d4a732-ca7a-4b24-a78a-65733ba419a7"), new DateTime(2013, 05, 11, 00, 00, 00), 8),
                    new WatchItem("Хэнкок", 2, StatusCinema.Look, TypeCinema.Movie, Guid.Parse("28d4a999-ca7a-4b24-a78a-65733ba419a7"), new DateTime(2015, 04, 12, 00, 00, 00), 9),
                    new WatchItem("Человек-паук", 2, StatusCinema.Planned, TypeCinema.Series, Guid.Parse("38d4a999-ca7a-4b24-a78a-65733ba419a7")),
                    new WatchItem("Драйв", 2, StatusCinema.Planned, TypeCinema.Movie, Guid.Parse("48d4a999-ca7a-4b24-a78a-65733ba419a7")),
                    new WatchItem("Твое имя", 2, StatusCinema.Viewed, TypeCinema.Anime, Guid.Parse("58d4a999-ca7a-4b24-a78a-65733ba419a7"), new DateTime(2022, 09, 10, 00, 00, 00), 10),
                },
                new List<WatchItem>()
                {
                    new WatchItem("Твое имя", 2, StatusCinema.Viewed, TypeCinema.Anime, Guid.Parse("58d4a999-ca7a-4b24-a78a-65733ba419a7"), new DateTime(2022, 09, 10, 00, 00, 00), 10),
                },
            },
        };

        [Theory]
        [MemberData(nameof(ItemsToCheckFilterByTypeMovie))]
        public void List_0f_Filter_Items_By_Movies(List<WatchItem> watchItems, List<WatchItem> expectWatchItems)
        {
            // Assert
            CheckListEqualAfterApplyFilter(watchItems, TypeCinema.Movie, expectWatchItems);
        }

        [Theory]
        [MemberData(nameof(ItemsToCheckFilterByTypeCartoon))]
        public void List_0f_Filter_Items_By_Cartoon(List<WatchItem> watchItems, List<WatchItem> expectWatchItems)
        {
            // Assert
            CheckListEqualAfterApplyFilter(watchItems, TypeCinema.Cartoon, expectWatchItems);
        }

        [Theory]
        [MemberData(nameof(ItemsToCheckFilterByTypeSeries))]
        public void List_0f_Filter_Items_By_Series(List<WatchItem> watchItems, List<WatchItem> expectWatchItems)
        {
            // Assert
            CheckListEqualAfterApplyFilter(watchItems, TypeCinema.Series, expectWatchItems);
        }

        [Theory]
        [MemberData(nameof(ItemsToCheckFilterByTypeAnime))]
        public void List_0f_Filter_Items_By_Anime(List<WatchItem> watchItems, List<WatchItem> expectWatchItems)
        {
            // Assert
            CheckListEqualAfterApplyFilter(watchItems, TypeCinema.Anime, expectWatchItems);
        }

        private void CheckListEqualAfterApplyFilter(List<WatchItem> watchItems, TypeCinema typeCinema, List<WatchItem> expectWatchItems)
        {
            // Arrange
            var dbContext = new TestAppDbContextFactory().Create();
            var itemSearchRequest = new ItemSearchRequest(
                    new FilterWatchItem()
                    {
                        FilterTypeField = TypeCinema.List.Where(e => e == typeCinema),
                        FilterStatusField = StatusCinema.List,
                    },
                    new SortWatchItem() { SortFields = SortFieldWatchItem.List.Where(e => e == SortFieldWatchItem.Title) },
                    new Page());
            dbContext.AddRange(watchItems);
            dbContext.SaveChanges();

            // Act
            var actualWatchItem = itemSearchRequest.ApplyFilter(dbContext.WatchItem).ToList();

            // Assert
            actualWatchItem.Should().Equal(expectWatchItems);
        }
    }
}
