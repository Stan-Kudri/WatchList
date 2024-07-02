using FluentAssertions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using WatchList.Core.Model.ItemCinema;
using WatchList.Core.Model.ItemCinema.Components;
using WatchList.Core.Model.QuestionResult;
using WatchList.Core.Repository;
using WatchList.Core.Service.Component;
using WatchList.Core.Service.DataLoading;
using WatchList.Test.Components;

namespace WatchList.Test.CoreTest.WatchItemServiceTest.DataLoadingTest
{
    public class DownloadDataByRuleTypeCinemaTest
    {
        public static IEnumerable<object[]> ListsAddOneItemByTypeCinema() => new List<object[]>
        {
            new object[]
            {
                new List<WatchItem>()
                {
                    new WatchItem("Человек-паук", 2, StatusCinema.Planned, TypeCinema.Series, Guid.Parse("38d4a999-ca7a-4b24-a78a-65733ba419a7")),
                    new WatchItem("Драйв", 2, StatusCinema.Planned, TypeCinema.Movie, Guid.Parse("48d4a999-ca7a-4b24-a78a-65733ba419a7")),
                    new WatchItem("Твое имя", 2, StatusCinema.Thrown, TypeCinema.Anime, Guid.Parse("58d4a999-ca7a-4b24-a78a-65733ba419a7")),
                },
                new List<WatchItem>()
                {
                    new WatchItem("Тор", 1, StatusCinema.Viewed, TypeCinema.Cartoon, Guid.Parse("18d4a732-ca7a-4b24-a78a-65733b2319a7"), new DateTime(2013, 05, 11, 00, 00, 00), 7),
                    new WatchItem("Хэнкок", 2, StatusCinema.Look, TypeCinema.Movie, Guid.Parse("28d4a999-ca7a-4b24-a78a-65733ba419a7"), new DateTime(2010, 04, 12, 00, 00, 00), 6),
                },
                TypeCinema.Cartoon,
                new List<WatchItem>()
                {
                    new WatchItem("Человек-паук", 2, StatusCinema.Planned, TypeCinema.Series, Guid.Parse("38d4a999-ca7a-4b24-a78a-65733ba419a7")),
                    new WatchItem("Драйв", 2, StatusCinema.Planned, TypeCinema.Movie, Guid.Parse("48d4a999-ca7a-4b24-a78a-65733ba419a7")),
                    new WatchItem("Твое имя", 2, StatusCinema.Thrown, TypeCinema.Anime, Guid.Parse("58d4a999-ca7a-4b24-a78a-65733ba419a7")),
                    new WatchItem("Тор", 1, StatusCinema.Viewed, TypeCinema.Cartoon, Guid.Parse("18d4a732-ca7a-4b24-a78a-65733b2319a7"), new DateTime(2013, 05, 11, 00, 00, 00), 7),
                },
            },
        };

        public static IEnumerable<object[]> ListsAddItemsByAllTypeCinema() => new List<object[]>
        {
            new object[]
            {
                new List<WatchItem>()
                {
                    new WatchItem("Драйв", 2, StatusCinema.Planned, TypeCinema.Movie, Guid.Parse("48d4a999-ca7a-4b24-a78a-65733ba419a7")),
                    new WatchItem("Твое имя", 2, StatusCinema.Thrown, TypeCinema.Anime, Guid.Parse("58d4a999-ca7a-4b24-a78a-65733ba419a7")),
                },
                new List<WatchItem>()
                {
                    new WatchItem("Тор", 1, StatusCinema.Viewed, TypeCinema.Cartoon, Guid.Parse("18d4a732-ca7a-4b24-a78a-65733ba419a7"), new DateTime(2013, 05, 11, 00, 00, 00), 7),
                    new WatchItem("Хэнкок", 2, StatusCinema.Look, TypeCinema.Movie, Guid.Parse("28d4a999-ca7a-4b24-a78a-65733ba419a7"), new DateTime(2010, 04, 12, 00, 00, 00), 6),
                    new WatchItem("Человек-паук", 2, StatusCinema.Planned, TypeCinema.Series, Guid.Parse("38d4a999-ca7a-4b24-a78a-65733ba419a7")),
                },
                null,
                new List<WatchItem>()
                {
                    new WatchItem("Драйв", 2, StatusCinema.Planned, TypeCinema.Movie, Guid.Parse("48d4a999-ca7a-4b24-a78a-65733ba419a7")),
                    new WatchItem("Твое имя", 2, StatusCinema.Thrown, TypeCinema.Anime, Guid.Parse("58d4a999-ca7a-4b24-a78a-65733ba419a7")),
                    new WatchItem("Тор", 1, StatusCinema.Viewed, TypeCinema.Cartoon, Guid.Parse("18d4a732-ca7a-4b24-a78a-65733ba419a7"), new DateTime(2013, 05, 11, 00, 00, 00), 7),
                    new WatchItem("Хэнкок", 2, StatusCinema.Look, TypeCinema.Movie, Guid.Parse("28d4a999-ca7a-4b24-a78a-65733ba419a7"), new DateTime(2010, 04, 12, 00, 00, 00), 6),
                    new WatchItem("Человек-паук", 2, StatusCinema.Planned, TypeCinema.Series, Guid.Parse("38d4a999-ca7a-4b24-a78a-65733ba419a7")),
                },
            },
        };

        public static IEnumerable<object[]> ListsReplaceItemsByTypeCinema() => new List<object[]>
        {
            new object[]
            {
                new List<WatchItem>()
                {
                    new WatchItem("Тор", 1, StatusCinema.Viewed, TypeCinema.Cartoon, Guid.Parse("18d4a732-ca7a-4b24-a78a-65733ba419a7"), new DateTime(2013, 05, 11, 00, 00, 00), 8),
                    new WatchItem("Человек-паук", 2, StatusCinema.Planned, TypeCinema.Series, Guid.Parse("38d4a999-ca7a-4b24-a78a-65733ba419a7")),
                    new WatchItem("Драйв", 2, StatusCinema.Planned, TypeCinema.Movie, Guid.Parse("48d4a999-ca7a-4b24-a78a-65733ba419a7")),
                    new WatchItem("Твое имя", 2, StatusCinema.Thrown, TypeCinema.Anime, Guid.Parse("58d4a999-ca7a-4b24-a78a-65733ba419a7")),
                },
                new List<WatchItem>()
                {
                    new WatchItem("Тор", 1, StatusCinema.Viewed, TypeCinema.Cartoon, Guid.Parse("18d4a732-ca7a-4b24-a78a-65733b2319a7"), new DateTime(2013, 05, 11, 00, 00, 00), 7),
                    new WatchItem("Хэнкок", 2, StatusCinema.Look, TypeCinema.Movie, Guid.Parse("28d4a999-ca7a-4b24-a78a-65733ba419a7"), new DateTime(2010, 04, 12, 00, 00, 00), 6),
                },
                TypeCinema.Cartoon,
                new List<WatchItem>()
                {
                    new WatchItem("Тор", 1, StatusCinema.Viewed, TypeCinema.Cartoon, Guid.Parse("18d4a732-ca7a-4b24-a78a-65733ba419a7"), new DateTime(2013, 05, 11, 00, 00, 00), 7),
                    new WatchItem("Человек-паук", 2, StatusCinema.Planned, TypeCinema.Series, Guid.Parse("38d4a999-ca7a-4b24-a78a-65733ba419a7")),
                    new WatchItem("Драйв", 2, StatusCinema.Planned, TypeCinema.Movie, Guid.Parse("48d4a999-ca7a-4b24-a78a-65733ba419a7")),
                    new WatchItem("Твое имя", 2, StatusCinema.Thrown, TypeCinema.Anime, Guid.Parse("58d4a999-ca7a-4b24-a78a-65733ba419a7")),
                },
            },
        };

        public static IEnumerable<object[]> ListsNotAddItemsByTypeCinema() => new List<object[]>
        {
            new object[]
            {
                new List<WatchItem>()
                {
                    new WatchItem("Тор", 1, StatusCinema.Viewed, TypeCinema.Cartoon, Guid.Parse("18d4a732-ca7a-4b24-a78a-65733ba419a7"), new DateTime(2013, 05, 11, 00, 00, 00), 8),
                    new WatchItem("Человек-паук", 2, StatusCinema.Planned, TypeCinema.Series, Guid.Parse("38d4a999-ca7a-4b24-a78a-65733ba419a7")),
                    new WatchItem("Драйв", 2, StatusCinema.Planned, TypeCinema.Movie, Guid.Parse("48d4a999-ca7a-4b24-a78a-65733ba419a7")),
                    new WatchItem("Твое имя", 2, StatusCinema.Thrown, TypeCinema.Anime, Guid.Parse("58d4a999-ca7a-4b24-a78a-65733ba419a7")),
                },
                new List<WatchItem>()
                {
                    new WatchItem("Тор", 1, StatusCinema.Viewed, TypeCinema.Cartoon, Guid.Parse("18d4a732-ca7a-4b24-a78a-65733b2319a7"), new DateTime(2013, 05, 11, 00, 00, 00), 7),
                    new WatchItem("Хэнкок", 2, StatusCinema.Look, TypeCinema.Movie, Guid.Parse("28d4a999-ca7a-4b24-a78a-65733ba419a7"), new DateTime(2010, 04, 12, 00, 00, 00), 6),
                },
                TypeCinema.Anime,
                new List<WatchItem>()
                {
                    new WatchItem("Тор", 1, StatusCinema.Viewed, TypeCinema.Cartoon, Guid.Parse("18d4a732-ca7a-4b24-a78a-65733ba419a7"), new DateTime(2013, 05, 11, 00, 00, 00), 8),
                    new WatchItem("Человек-паук", 2, StatusCinema.Planned, TypeCinema.Series, Guid.Parse("38d4a999-ca7a-4b24-a78a-65733ba419a7")),
                    new WatchItem("Драйв", 2, StatusCinema.Planned, TypeCinema.Movie, Guid.Parse("48d4a999-ca7a-4b24-a78a-65733ba419a7")),
                    new WatchItem("Твое имя", 2, StatusCinema.Thrown, TypeCinema.Anime, Guid.Parse("58d4a999-ca7a-4b24-a78a-65733ba419a7")),
                },
            },
        };

        [Theory]
        [MemberData(nameof(ListsAddOneItemByTypeCinema))]
        [MemberData(nameof(ListsAddItemsByAllTypeCinema))]
        [MemberData(nameof(ListsNotAddItemsByTypeCinema))]
        public async Task Load_Data_File_By_Rule_Type_Cinema(List<WatchItem> items, List<WatchItem> addDownloadItem, TypeCinema? typeCinema, List<WatchItem> expectItems)
        {
            // Arrange
            var nullLog = new NullLoggerFactory();
            ILogger<WatchItemRepository> loggerRepository = new Logger<WatchItemRepository>(nullLog);
            ILogger<DownloadDataService> loggerDownload = new Logger<DownloadDataService>(nullLog);
            var dbContext = new TestAppDbContextFactory().Create();
            var itemRepository = new WatchItemRepository(dbContext, loggerRepository);
            var dbContextDownloadItem = new TestAppDbContextFactory().Create();
            var watchItemRepository = new WatchItemRepository(dbContext, loggerRepository);

            var messageBox = new Mock<IMessageBox>();
            messageBox.Setup(foo => foo.ShowDataReplaceQuestion(It.IsAny<string>())).ReturnsAsync(DialogReplaceItemQuestion.AllYes);

            var service = new DownloadDataService(watchItemRepository, messageBox.Object, loggerDownload);
            var loadRuleConfig = new TestLoadRuleConfig() { TypeCinemaLoad = typeCinema };
            var loadRule = new TestAggregateLoadRule(itemRepository, loadRuleConfig);
            var repositoryDataDownload = new WatchItemRepository(dbContextDownloadItem, loggerRepository);

            dbContext.AddRange(items);
            dbContextDownloadItem.AddRange(addDownloadItem);
            dbContext.SaveChanges();
            dbContextDownloadItem.SaveChanges();

            // Act
            await service.Download(repositoryDataDownload, loadRule);
            var actualItems = dbContext.WatchItem.ToList();

            // Assert
            actualItems.Should().Equal(expectItems);
        }

        [Theory]
        [MemberData(nameof(ListsAddOneItemByTypeCinema))]
        [MemberData(nameof(ListsAddItemsByAllTypeCinema))]
        [MemberData(nameof(ListsNotAddItemsByTypeCinema))]
        public async Task Load_Data_File_By_Rule_Type_CinemaAsync(List<WatchItem> items, List<WatchItem> addDownloadItem, TypeCinema? typeCinema, List<WatchItem> expectItems)
        {
            // Arrange
            var nullLog = new NullLoggerFactory();
            ILogger<WatchItemRepository> loggerRepository = new Logger<WatchItemRepository>(nullLog);
            ILogger<DownloadDataService> loggerDownload = new Logger<DownloadDataService>(nullLog);
            var dbContext = new TestAppDbContextFactory().Create();
            var itemRepository = new WatchItemRepository(dbContext, loggerRepository);
            var dbContextDownloadItem = new TestAppDbContextFactory().Create();
            var watchItemRepository = new WatchItemRepository(dbContext, loggerRepository);

            var messageBox = new Mock<IMessageBox>();
            messageBox.Setup(foo => foo.ShowDataReplaceQuestion(It.IsAny<string>())).ReturnsAsync(DialogReplaceItemQuestion.AllYes);

            var service = new DownloadDataService(watchItemRepository, messageBox.Object, loggerDownload);
            var loadRuleConfig = new TestLoadRuleConfig() { TypeCinemaLoad = typeCinema };
            var loadRule = new TestAggregateLoadRule(itemRepository, loadRuleConfig);
            var repositoryDataDownload = new WatchItemRepository(dbContextDownloadItem, loggerRepository);

            dbContext.AddRange(items);
            dbContextDownloadItem.AddRange(addDownloadItem);
            await dbContext.SaveChangesAsync();
            await dbContextDownloadItem.SaveChangesAsync();

            // Act
            service.Download(repositoryDataDownload, loadRule);
            var actualItems = dbContext.WatchItem.ToList();

            // Assert
            actualItems.Should().Equal(expectItems);
        }
    }
}
