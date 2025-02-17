using FluentAssertions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using WatchList.Core.Model.ItemCinema;
using WatchList.Core.Model.ItemCinema.Components;
using WatchList.Core.Repository;
using WatchList.Core.Service;
using WatchList.Core.Service.Component;
using WatchList.Test.Components;

namespace WatchList.Test.CoreTest.WatchItemServiceTest
{
    public class NonDuplicateElementsTest
    {
        public static IEnumerable<object[]> ListWithNewItemAdded() => new List<object[]>
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
                new WatchItem("Я - Легенда", 1, StatusCinema.Viewed, TypeCinema.Movie, Guid.Parse("58d4a229-ca7a-4b24-a78a-65733ba419a7")),
                new List<WatchItem>()
                {
                    new WatchItem("Тор", 1, StatusCinema.Viewed, TypeCinema.Cartoon, Guid.Parse("18d4a732-ca7a-4b24-a78a-65733ba419a7"), new DateTime(2013, 05, 11, 00, 00, 00), 8),
                    new WatchItem("Хэнкок", 2, StatusCinema.Look, TypeCinema.Movie, Guid.Parse("28d4a999-ca7a-4b24-a78a-65733ba419a7"), new DateTime(2015, 04, 12, 00, 00, 00), 9),
                    new WatchItem("Человек-паук", 2, StatusCinema.Planned, TypeCinema.Series, Guid.Parse("38d4a999-ca7a-4b24-a78a-65733ba419a7")),
                    new WatchItem("Драйв", 2, StatusCinema.Planned, TypeCinema.Movie, Guid.Parse("48d4a999-ca7a-4b24-a78a-65733ba419a7")),
                    new WatchItem("Твое имя", 2, StatusCinema.Thrown, TypeCinema.Anime, Guid.Parse("58d4a999-ca7a-4b24-a78a-65733ba419a7")),
                    new WatchItem("Я - Легенда", 1, StatusCinema.Viewed, TypeCinema.Movie, Guid.Parse("58d4a229-ca7a-4b24-a78a-65733ba419a7")),
                },
            },
        };

        public static IEnumerable<object[]> ListWithUpdatedItem() => new List<object[]>
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
                new WatchItem("Драйв", 2, StatusCinema.Planned, TypeCinema.Movie, Guid.Parse("48d4a999-ca7a-4b24-a78a-65733ba419a7")),
                new WatchItem("Я - Легенда", 1, StatusCinema.Viewed, TypeCinema.Movie, Guid.Parse("48d4a999-ca7a-4b24-a78a-65733ba419a7")),
                new List<WatchItem>()
                {
                    new WatchItem("Тор", 1, StatusCinema.Viewed, TypeCinema.Cartoon, Guid.Parse("18d4a732-ca7a-4b24-a78a-65733ba419a7"), new DateTime(2013, 05, 11, 00, 00, 00), 8),
                    new WatchItem("Хэнкок", 2, StatusCinema.Look, TypeCinema.Movie, Guid.Parse("28d4a999-ca7a-4b24-a78a-65733ba419a7"), new DateTime(2015, 04, 12, 00, 00, 00), 9),
                    new WatchItem("Человек-паук", 2, StatusCinema.Planned, TypeCinema.Series, Guid.Parse("38d4a999-ca7a-4b24-a78a-65733ba419a7")),
                    new WatchItem("Я - Легенда", 1, StatusCinema.Viewed, TypeCinema.Movie, Guid.Parse("48d4a999-ca7a-4b24-a78a-65733ba419a7")),
                    new WatchItem("Твое имя", 2, StatusCinema.Thrown, TypeCinema.Anime, Guid.Parse("58d4a999-ca7a-4b24-a78a-65733ba419a7")),
                },
            },
        };

        [Theory]
        [MemberData(nameof(ListWithNewItemAdded))]
        public async Task Add_New_Item_In_Database(List<WatchItem> items, WatchItem addItem, List<WatchItem> expectItems)
        {
            // Arrange
            var nullLog = new NullLoggerFactory();
            ILogger<WatchItemRepository> loggerRepository = new Logger<WatchItemRepository>(nullLog);
            var dbContext = new TestAppDbContextFactory().Create();
            var itemRepository = new WatchItemRepository(dbContext, loggerRepository);
            var messageBox = new Mock<IMessageBox>();
            messageBox.Setup(foo => foo.ShowQuestionSaveItem(WatchItemService.DuplicateReplaceMessage)).ReturnsAsync(true);
            var service = new WatchItemService(itemRepository, messageBox.Object, loggerRepository);
            dbContext.AddRange(items);
            dbContext.SaveChanges();

            // Act
            service.AddAsync(addItem);
            var actualItems = dbContext.WatchItem.ToList();

            // Assert
            actualItems.Should().Equal(expectItems);
        }

        [Theory]
        [MemberData(nameof(ListWithUpdatedItem))]
        public async Task Update_Item_In_DatabaseAsync(List<WatchItem> items, WatchItem oldItem, WatchItem updateItem, List<WatchItem> expectItems)
        {
            // Arrange
            var nullLog = new NullLoggerFactory();
            ILogger<WatchItemRepository> loggerRepository = new Logger<WatchItemRepository>(nullLog);
            var dbContext = new TestAppDbContextFactory().Create();
            var itemRepository = new WatchItemRepository(dbContext, loggerRepository);
            var messageBox = new Mock<IMessageBox>();
            messageBox.Setup(foo => foo.ShowQuestionSaveItem(WatchItemService.DuplicateReplaceMessage)).ReturnsAsync(true);
            var service = new WatchItemService(itemRepository, messageBox.Object, loggerRepository);
            dbContext.AddRange(items);
            dbContext.SaveChanges();

            // Act
            await service.UpdateAsync(oldItem, updateItem);
            var actualItems = dbContext.WatchItem.ToList();

            // Assert
            actualItems.Should().Equal(expectItems);
        }
    }
}
