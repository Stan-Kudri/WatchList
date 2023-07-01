using FluentAssertions;
using Moq;
using WatchList.Core.Model.ItemCinema;
using WatchList.Core.Model.ItemCinema.Components;
using WatchList.Core.Model.QuestionResult;
using WatchList.Core.Repository;
using WatchList.Core.Service.Component;
using WatchList.Core.Service.DataLoading;
using WatchList.Core.Service.DataLoading.Rules;

namespace WatchList.Test.CoreTest.WatchItemServiceTest
{
    public class DownloadDataTest
    {
        public static IEnumerable<object[]> ListsWithTwoSameElements() => new List<object[]>
        {
            new object[]
            {
                new List<WatchItem>()
                {
                    new WatchItem("Тор", 1, StatusCinema.Viewed, TypeCinema.Cartoon, Guid.Parse("18d4a732-ca7a-4b24-a78a-65733ba419a7"), new DateTime(2013, 05, 11, 00, 00, 00), 8),
                    new WatchItem("Хэнкок", 2, StatusCinema.Look, TypeCinema.Movie, Guid.Parse("28d4a999-ca7a-4b24-a78a-65733ba419a7"), new DateTime(2015, 04, 12, 00, 00, 00), 9),
                    new WatchItem("Хэнкок", 2, StatusCinema.Look, TypeCinema.Movie, Guid.Parse("28dfa929-ca7a-4b24-a78a-65733ba419a7"), new DateTime(2012, 04, 12, 00, 00, 00), 3),
                    new WatchItem("Человек-паук", 2, StatusCinema.Planned, TypeCinema.Series, Guid.Parse("38d4a999-ca7a-4b24-a78a-65733ba419a7")),
                    new WatchItem("Драйв", 2, StatusCinema.Planned, TypeCinema.Movie, Guid.Parse("48d4a999-ca7a-4b24-a78a-65733ba419a7")),
                    new WatchItem("Твое имя", 2, StatusCinema.Thrown, TypeCinema.Anime, Guid.Parse("58d4a999-ca7a-4b24-a78a-65733ba419a7")),
                },
                new List<WatchItem>()
                {
                    new WatchItem("Тор", 1, StatusCinema.Viewed, TypeCinema.Cartoon, Guid.Parse("18d4a732-ca7a-4b24-a78a-65733b2319a7"), new DateTime(2013, 05, 11, 00, 00, 00), 7),
                    new WatchItem("Хэнкок", 2, StatusCinema.Planned, TypeCinema.Movie, Guid.Parse("28d4a999-ca7a-4b24-a78a-65733bff19a7")),
                },
                new List<WatchItem>()
                {
                    new WatchItem("Тор", 1, StatusCinema.Viewed, TypeCinema.Cartoon, Guid.Parse("18d4a732-ca7a-4b24-a78a-65733ba419a7"), new DateTime(2013, 05, 11, 00, 00, 00), 7),
                    new WatchItem("Хэнкок", 2, StatusCinema.Planned, TypeCinema.Movie, Guid.Parse("28d4a999-ca7a-4b24-a78a-65733ba419a7")),
                    new WatchItem("Хэнкок", 2, StatusCinema.Look, TypeCinema.Movie, Guid.Parse("28dfa929-ca7a-4b24-a78a-65733ba419a7"), new DateTime(2012, 04, 12, 00, 00, 00), 3),
                    new WatchItem("Человек-паук", 2, StatusCinema.Planned, TypeCinema.Series, Guid.Parse("38d4a999-ca7a-4b24-a78a-65733ba419a7")),
                    new WatchItem("Драйв", 2, StatusCinema.Planned, TypeCinema.Movie, Guid.Parse("48d4a999-ca7a-4b24-a78a-65733ba419a7")),
                    new WatchItem("Твое имя", 2, StatusCinema.Thrown, TypeCinema.Anime, Guid.Parse("58d4a999-ca7a-4b24-a78a-65733ba419a7")),
                },
            },
        };

        [Theory]
        [MemberData(nameof(ListsWithTwoSameElements))]
        public void Add_Data_File_And_Replace_Duplicate_Element(List<WatchItem> items, List<WatchItem> addDownloadItem, List<WatchItem> expectItems)
        {
            // Arrange
            var dbContext = new TestAppDbContextFactory().Create();
            var dbContextDownloadItem = new TestAppDbContextFactory().Create();

            var dialogResultReplaceItem = DialogReplaceItemQuestion.AllYes;
            var messageBox = new Mock<IMessageBox>();
            messageBox.Setup(foo => foo.ShowDataReplaceQuestion(It.IsAny<string>())).Returns(dialogResultReplaceItem);

            var service = new DownloadDataService(dbContext, messageBox.Object);
            var loadRule = new DeleteGradeRule(false);
            var repositoryDataDownload = new WatchItemRepository(dbContextDownloadItem);

            dbContext.AddRange(items);
            dbContextDownloadItem.AddRange(addDownloadItem);
            dbContext.SaveChanges();
            dbContextDownloadItem.SaveChanges();

            service.Download(repositoryDataDownload, loadRule);

            // Act
            var actualItems = dbContext.WatchItem.ToList();

            // Assert
            actualItems.Should().Equal(expectItems);
        }
    }
}
