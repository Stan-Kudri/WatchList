using FluentAssertions;
using WatchList.Core.Model.Filter;
using WatchList.Core.Model.ItemCinema;
using WatchList.Core.Model.ItemCinema.Components;
using WatchList.Core.Model.Sorting;
using WatchList.Core.PageItem;
using WatchList.Core.Repository;

namespace WatchList.Test.CoreTest
{
    public class SortFieldTest
    {
        public static IEnumerable<object[]> TitleOrderWatchListItem() => new List<object[]>
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
                SortField.Title,
                new List<WatchItem>()
                {
                    new WatchItem("Джокер", 2, StatusCinema.Viewed, TypeCinema.Movie, Guid.Parse("68d4a999-ca7a-4b24-a78a-65733ba419a7"), new DateTime(2020, 12, 10, 00, 00, 00), 10),
                    new WatchItem("Драйв", 2, StatusCinema.Planned, TypeCinema.Movie, Guid.Parse("48d4a999-ca7a-4b24-a78a-65733ba419a7")),
                    new WatchItem("Залечь на дно в Брюгге", 2, StatusCinema.Viewed, TypeCinema.Movie, Guid.Parse("58d4a999-ca7a-4b24-a78a-65733ba419a7"), new DateTime(2022, 09, 10, 00, 00, 00), 10),
                    new WatchItem("Тор", 1, StatusCinema.Viewed, TypeCinema.Movie, Guid.Parse("18d4a732-ca7a-4b24-a78a-65733ba419a7"), new DateTime(2013, 05, 11, 00, 00, 00), 8),
                    new WatchItem("Хэнкок", 2, StatusCinema.Look, TypeCinema.Movie, Guid.Parse("28d4a999-ca7a-4b24-a78a-65733ba419a7"), new DateTime(2015, 04, 12, 00, 00, 00), 9),
                    new WatchItem("Человек-паук", 2, StatusCinema.Planned, TypeCinema.Series, Guid.Parse("38d4a999-ca7a-4b24-a78a-65733ba419a7")),
                },
            },
        };

        public static IEnumerable<object[]> SequelOrderWatchListItem() => new List<object[]>
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
                SortField.Sequel,
                new List<WatchItem>()
                {
                    new WatchItem("Тор", 1, StatusCinema.Viewed, TypeCinema.Movie, Guid.Parse("18d4a732-ca7a-4b24-a78a-65733ba419a7"), new DateTime(2013, 05, 11, 00, 00, 00), 8),
                    new WatchItem("Хэнкок", 2, StatusCinema.Look, TypeCinema.Movie, Guid.Parse("28d4a999-ca7a-4b24-a78a-65733ba419a7"), new DateTime(2015, 04, 12, 00, 00, 00), 9),
                    new WatchItem("Человек-паук", 2, StatusCinema.Planned, TypeCinema.Series, Guid.Parse("38d4a999-ca7a-4b24-a78a-65733ba419a7")),
                    new WatchItem("Драйв", 2, StatusCinema.Planned, TypeCinema.Movie, Guid.Parse("48d4a999-ca7a-4b24-a78a-65733ba419a7")),
                    new WatchItem("Залечь на дно в Брюгге", 2, StatusCinema.Viewed, TypeCinema.Movie, Guid.Parse("58d4a999-ca7a-4b24-a78a-65733ba419a7"), new DateTime(2022, 09, 10, 00, 00, 00), 10),
                    new WatchItem("Джокер", 2, StatusCinema.Viewed, TypeCinema.Movie, Guid.Parse("68d4a999-ca7a-4b24-a78a-65733ba419a7"), new DateTime(2020, 12, 10, 00, 00, 00), 10),
                },
            },
        };

        public static IEnumerable<object[]> StatusOrderWatchListItem() => new List<object[]>
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
                SortField.Status,
                new List<WatchItem>()
                {
                    new WatchItem("Хэнкок", 2, StatusCinema.Look, TypeCinema.Movie, Guid.Parse("28d4a999-ca7a-4b24-a78a-65733ba419a7"), new DateTime(2015, 04, 12, 00, 00, 00), 9),
                    new WatchItem("Человек-паук", 2, StatusCinema.Planned, TypeCinema.Series, Guid.Parse("38d4a999-ca7a-4b24-a78a-65733ba419a7")),
                    new WatchItem("Драйв", 2, StatusCinema.Planned, TypeCinema.Movie, Guid.Parse("48d4a999-ca7a-4b24-a78a-65733ba419a7")),
                    new WatchItem("Тор", 1, StatusCinema.Viewed, TypeCinema.Movie, Guid.Parse("18d4a732-ca7a-4b24-a78a-65733ba419a7"), new DateTime(2013, 05, 11, 00, 00, 00), 8),
                    new WatchItem("Залечь на дно в Брюгге", 2, StatusCinema.Viewed, TypeCinema.Movie, Guid.Parse("58d4a999-ca7a-4b24-a78a-65733ba419a7"), new DateTime(2022, 09, 10, 00, 00, 00), 10),
                    new WatchItem("Джокер", 2, StatusCinema.Viewed, TypeCinema.Movie, Guid.Parse("68d4a999-ca7a-4b24-a78a-65733ba419a7"), new DateTime(2020, 12, 10, 00, 00, 00), 10),
                },
            },
        };

        public static IEnumerable<object[]> DataOrderWatchListItem() => new List<object[]>
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
                SortField.Data,
                new List<WatchItem>()
                {
                    new WatchItem("Залечь на дно в Брюгге", 2, StatusCinema.Viewed, TypeCinema.Movie, Guid.Parse("58d4a999-ca7a-4b24-a78a-65733ba419a7"), new DateTime(2022, 09, 10, 00, 00, 00), 10),
                    new WatchItem("Джокер", 2, StatusCinema.Viewed, TypeCinema.Movie, Guid.Parse("68d4a999-ca7a-4b24-a78a-65733ba419a7"), new DateTime(2020, 12, 10, 00, 00, 00), 10),
                    new WatchItem("Хэнкок", 2, StatusCinema.Look, TypeCinema.Movie, Guid.Parse("28d4a999-ca7a-4b24-a78a-65733ba419a7"), new DateTime(2015, 04, 12, 00, 00, 00), 9),
                    new WatchItem("Тор", 1, StatusCinema.Viewed, TypeCinema.Movie, Guid.Parse("18d4a732-ca7a-4b24-a78a-65733ba419a7"), new DateTime(2013, 05, 11, 00, 00, 00), 8),
                    new WatchItem("Человек-паук", 2, StatusCinema.Planned, TypeCinema.Series, Guid.Parse("38d4a999-ca7a-4b24-a78a-65733ba419a7")),
                    new WatchItem("Драйв", 2, StatusCinema.Planned, TypeCinema.Movie, Guid.Parse("48d4a999-ca7a-4b24-a78a-65733ba419a7")),
                },
            },
        };

        public static IEnumerable<object[]> GradeOrderWatchListItem() => new List<object[]>
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
                SortField.Grade,
                new List<WatchItem>()
                {
                    new WatchItem("Залечь на дно в Брюгге", 2, StatusCinema.Viewed, TypeCinema.Movie, Guid.Parse("58d4a999-ca7a-4b24-a78a-65733ba419a7"), new DateTime(2022, 09, 10, 00, 00, 00), 10),
                    new WatchItem("Джокер", 2, StatusCinema.Viewed, TypeCinema.Movie, Guid.Parse("68d4a999-ca7a-4b24-a78a-65733ba419a7"), new DateTime(2020, 12, 10, 00, 00, 00), 10),
                    new WatchItem("Хэнкок", 2, StatusCinema.Look, TypeCinema.Movie, Guid.Parse("28d4a999-ca7a-4b24-a78a-65733ba419a7"), new DateTime(2015, 04, 12, 00, 00, 00), 9),
                    new WatchItem("Тор", 1, StatusCinema.Viewed, TypeCinema.Movie, Guid.Parse("18d4a732-ca7a-4b24-a78a-65733ba419a7"), new DateTime(2013, 05, 11, 00, 00, 00), 8),
                    new WatchItem("Человек-паук", 2, StatusCinema.Planned, TypeCinema.Series, Guid.Parse("38d4a999-ca7a-4b24-a78a-65733ba419a7")),
                    new WatchItem("Драйв", 2, StatusCinema.Planned, TypeCinema.Movie, Guid.Parse("48d4a999-ca7a-4b24-a78a-65733ba419a7")),
                },
            },
        };

        public static IEnumerable<object[]> TypeOrderWatchListItem() => new List<object[]>
        {
            new object[]
            {
                new List<WatchItem>()
                {
                    new WatchItem("Тор", 1, StatusCinema.Viewed, TypeCinema.Movie, Guid.Parse("18d4a732-ca7a-4b24-a78a-65733ba419a7"), new DateTime(2013, 05, 11, 00, 00, 00), 8),
                    new WatchItem("Хэнкок", 2, StatusCinema.Look, TypeCinema.Movie, Guid.Parse("28d4a999-ca7a-4b24-a78a-65733ba419a7"), new DateTime(2015, 04, 12, 00, 00, 00), 9),
                    new WatchItem("Человек-паук", 2, StatusCinema.Planned, TypeCinema.Series, Guid.Parse("38d4a999-ca7a-4b24-a78a-65733ba419a7")),
                    new WatchItem("Драйв", 2, StatusCinema.Planned, TypeCinema.Movie, Guid.Parse("48d4a999-ca7a-4b24-a78a-65733ba419a7")),
                    new WatchItem("Твое имя", 2, StatusCinema.Viewed, TypeCinema.Anime, Guid.Parse("58d4a999-ca7a-4b24-a78a-65733ba419a7"), new DateTime(2022, 09, 10, 00, 00, 00), 10),
                    new WatchItem("Джокер", 2, StatusCinema.Viewed, TypeCinema.Movie, Guid.Parse("68d4a999-ca7a-4b24-a78a-65733ba419a7"), new DateTime(2020, 12, 10, 00, 00, 00), 10),
                },
                SortField.Type,
                new List<WatchItem>()
                {
                    new WatchItem("Твое имя", 2, StatusCinema.Viewed, TypeCinema.Anime, Guid.Parse("58d4a999-ca7a-4b24-a78a-65733ba419a7"), new DateTime(2022, 09, 10, 00, 00, 00), 10),
                    new WatchItem("Тор", 1, StatusCinema.Viewed, TypeCinema.Movie, Guid.Parse("18d4a732-ca7a-4b24-a78a-65733ba419a7"), new DateTime(2013, 05, 11, 00, 00, 00), 8),
                    new WatchItem("Хэнкок", 2, StatusCinema.Look, TypeCinema.Movie, Guid.Parse("28d4a999-ca7a-4b24-a78a-65733ba419a7"), new DateTime(2015, 04, 12, 00, 00, 00), 9),
                    new WatchItem("Драйв", 2, StatusCinema.Planned, TypeCinema.Movie, Guid.Parse("48d4a999-ca7a-4b24-a78a-65733ba419a7")),
                    new WatchItem("Джокер", 2, StatusCinema.Viewed, TypeCinema.Movie, Guid.Parse("68d4a999-ca7a-4b24-a78a-65733ba419a7"), new DateTime(2020, 12, 10, 00, 00, 00), 10),
                    new WatchItem("Человек-паук", 2, StatusCinema.Planned, TypeCinema.Series, Guid.Parse("38d4a999-ca7a-4b24-a78a-65733ba419a7")),
                },
            },
        };

        [Theory]
        [MemberData(nameof(TitleOrderWatchListItem))]
        [MemberData(nameof(SequelOrderWatchListItem))]
        [MemberData(nameof(StatusOrderWatchListItem))]
        [MemberData(nameof(DataOrderWatchListItem))]
        [MemberData(nameof(GradeOrderWatchListItem))]
        [MemberData(nameof(TypeOrderWatchListItem))]
        public void Order_List_Items_By_Title(List<WatchItem> watchItems, SortField sortField, List<WatchItem> expectWatchItem)
        {
            // Arrange
            var appDbContext = new TestAppDbContextFactory().Create();
            var itemRepository = new WatchItemRepository(appDbContext);
            var watchItemSearchRequest = new WatchItemSearchRequest(new FilterItem(), sortField, new Page(1, 6));

            // Act
            itemRepository.Add(watchItems);
            var pageItem = itemRepository.GetPageCinema(watchItemSearchRequest);
            var actualItemPage = pageItem.Items;

            // Assert
            actualItemPage.Should().Equal(expectWatchItem);
        }
    }
}
