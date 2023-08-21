using FluentAssertions;
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
    public class DownloadPagedListTest
    {
        public const int PageSize = 5;

        public static IEnumerable<object[]> ListItemsInFileAfterLoading() => new List<object[]>
        {
            new object[]
            {
                new List<WatchItem>()
                {
                    new WatchItem("Тор", 1, StatusCinema.Viewed, TypeCinema.Cartoon, Guid.Parse("18d4a732-ca7a-4b24-a78a-65733ba419a7"), new DateTime(2013, 05, 11, 00, 00, 00), 8),
                },
                new List<WatchItem>()
                {
                    new WatchItem("Трал", 1, StatusCinema.Viewed, TypeCinema.Cartoon, Guid.Parse("18d5a733-ca7a-4b24-a78a-65733ba419a7"), new DateTime(2012, 05, 11, 00, 00, 00), 7),
                    new WatchItem("Хэнкок", 2, StatusCinema.Look, TypeCinema.Movie, Guid.Parse("28d4a999-ca7a-4b24-a78a-65733ba419a7"), new DateTime(2015, 04, 12, 00, 00, 00), 9),
                    new WatchItem("Человек-паук", 2, StatusCinema.Planned, TypeCinema.Series, Guid.Parse("38d4a999-ca7a-4b24-a78a-65733ba419a7")),
                    new WatchItem("Драйв", 2, StatusCinema.Planned, TypeCinema.Movie, Guid.Parse("48d4a999-ca7a-4b24-a78a-65733ba419a7")),
                    new WatchItem("Твое имя", 2, StatusCinema.Thrown, TypeCinema.Anime, Guid.Parse("58d4a999-ca7a-4b24-a78a-65733ba419a7")),
                    new WatchItem("Я - Легенда", 1, StatusCinema.Viewed, TypeCinema.Movie, Guid.Parse("58d4a229-ca7a-4b24-a78a-65733ba419a7")),
                },
                new List<WatchItem>()
                {
                    new WatchItem("Тор", 1, StatusCinema.Viewed, TypeCinema.Cartoon, Guid.Parse("18d4a732-ca7a-4b24-a78a-65733ba419a7"), new DateTime(2013, 05, 11, 00, 00, 00), 8),
                    new WatchItem("Драйв", 2, StatusCinema.Planned, TypeCinema.Movie, Guid.Parse("48d4a999-ca7a-4b24-a78a-65733ba419a7")),
                    new WatchItem("Твое имя", 2, StatusCinema.Thrown, TypeCinema.Anime, Guid.Parse("58d4a999-ca7a-4b24-a78a-65733ba419a7")),
                    new WatchItem("Трал", 1, StatusCinema.Viewed, TypeCinema.Cartoon, Guid.Parse("18d5a733-ca7a-4b24-a78a-65733ba419a7"), new DateTime(2012, 05, 11, 00, 00, 00), 7),
                    new WatchItem("Хэнкок", 2, StatusCinema.Look, TypeCinema.Movie, Guid.Parse("28d4a999-ca7a-4b24-a78a-65733ba419a7"), new DateTime(2015, 04, 12, 00, 00, 00), 9),
                    new WatchItem("Человек-паук", 2, StatusCinema.Planned, TypeCinema.Series, Guid.Parse("38d4a999-ca7a-4b24-a78a-65733ba419a7")),
                    new WatchItem("Я - Легенда", 1, StatusCinema.Viewed, TypeCinema.Movie, Guid.Parse("58d4a229-ca7a-4b24-a78a-65733ba419a7")),
                },
            },
        };

        [Theory]
        [MemberData(nameof(ListItemsInFileAfterLoading))]
        public void Add_Data_File(List<WatchItem> items, List<WatchItem> addDownloadItem, List<WatchItem> expectItems)
        {
            // Arrange
            var dbContext = new TestAppDbContextFactory().Create();
            var itemRepository = new WatchItemRepository(dbContext);
            var dbContextDownloadItem = new TestAppDbContextFactory().Create();
            var watchItemRepository = new WatchItemRepository(dbContext);

            var messageBox = new Mock<IMessageBox>();
            messageBox.Setup(foo => foo.ShowDataReplaceQuestion(It.IsAny<string>())).Returns(DialogReplaceItemQuestion.AllYes);

            var service = new DownloadDataService(watchItemRepository, messageBox.Object) { NumberOfItemPerPage = PageSize };
            var loadRuleConfig = new TestLoadRuleConfig();
            var loadRule = new TestAggregateLoadRule(itemRepository, loadRuleConfig);
            var repositoryDataDownload = new WatchItemRepository(dbContextDownloadItem);

            dbContext.AddRange(items);
            dbContextDownloadItem.AddRange(addDownloadItem);
            dbContext.SaveChanges();
            dbContextDownloadItem.SaveChanges();

            // Act
            service.Download(repositoryDataDownload, loadRule);
            var actualItems = dbContext.WatchItem.ToList();

            // Assert
            actualItems.Should().Equal(expectItems);
        }

        [Theory]
        [MemberData(nameof(ListItemsInFileAfterLoading))]
        public async Task Add_Data_FileAsync(List<WatchItem> items, List<WatchItem> addDownloadItem, List<WatchItem> expectItems)
        {
            // Arrange
            var dbContext = new TestAppDbContextFactory().Create();
            var itemRepository = new WatchItemRepository(dbContext);
            var dbContextDownloadItem = new TestAppDbContextFactory().Create();
            var watchItemRepository = new WatchItemRepository(dbContext);

            var messageBox = new Mock<IMessageBox>();
            messageBox.Setup(foo => foo.ShowDataReplaceQuestion(It.IsAny<string>())).Returns(DialogReplaceItemQuestion.AllYes);

            var service = new DownloadDataService(watchItemRepository, messageBox.Object) { NumberOfItemPerPage = PageSize };
            var loadRuleConfig = new TestLoadRuleConfig();
            var loadRule = new TestAggregateLoadRule(itemRepository, loadRuleConfig);
            var repositoryDataDownload = new WatchItemRepository(dbContextDownloadItem);

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
