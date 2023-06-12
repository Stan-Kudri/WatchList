using FluentAssertions;
using WatchList.Core.Model.ItemCinema;
using WatchList.Core.Model.ItemCinema.Components;
using WatchList.Core.Repository;
using WatchList.Core.Service;
using WatchList.Test.CoreTest.WatchItemServiceTest.Component;

namespace WatchList.Test.CoreTest.WatchItemServiceTest
{
    public class AddDuplicateItemTest
    {
        public static IEnumerable<object[]> ListWithTwoSameElements() => new List<object[]>
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
                new WatchItem("Хэнкок", 2, StatusCinema.Planned, TypeCinema.Movie, Guid.Parse("58d4ad99-ca7a-4b24-a78a-65733ba419a7")),
            },
        };

        public static IEnumerable<object[]> ListOfElementsWithDuplicateElement() => new List<object[]>
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
                new WatchItem("Хэнкок", 2, StatusCinema.Planned, TypeCinema.Movie, Guid.Parse("5823ad99-ca7a-4b24-a78a-65733ba419a7")),
                new List<WatchItem>()
                {
                    new WatchItem("Тор", 1, StatusCinema.Viewed, TypeCinema.Cartoon, Guid.Parse("18d4a732-ca7a-4b24-a78a-65733ba419a7"), new DateTime(2013, 05, 11, 00, 00, 00), 8),
                    new WatchItem("Хэнкок", 2, StatusCinema.Planned, TypeCinema.Movie, Guid.Parse("28d4a999-ca7a-4b24-a78a-65733ba419a7")),
                    new WatchItem("Человек-паук", 2, StatusCinema.Planned, TypeCinema.Series, Guid.Parse("38d4a999-ca7a-4b24-a78a-65733ba419a7")),
                    new WatchItem("Драйв", 2, StatusCinema.Planned, TypeCinema.Movie, Guid.Parse("48d4a999-ca7a-4b24-a78a-65733ba419a7")),
                    new WatchItem("Твое имя", 2, StatusCinema.Thrown, TypeCinema.Anime, Guid.Parse("58d4a999-ca7a-4b24-a78a-65733ba419a7")),
                },
            },
        };

        [Theory]
        [MemberData(nameof(ListWithTwoSameElements))]
        public void Duplicate_Element_In_Database(List<WatchItem> watchItems, WatchItem duplicateItem)
        {
            // Arrange
            var dbContext = new TestAppDbContextFactory().Create();
            var repository = new WatchItemRepository(dbContext);
            var messageBox = new FakeMessageBox(true);
            var service = new WatchItemService(dbContext, messageBox);

            // Act
            repository.AddRange(watchItems);

            // Assert
            Assert.Throws<ArgumentException>(() => service.Add(duplicateItem));
        }

        [Theory]
        [MemberData(nameof(ListOfElementsWithDuplicateElement))]
        public void Add_With_Replace_Duplicate_Element(List<WatchItem> items, WatchItem addItem, List<WatchItem> expectItems)
        {
            // Arrange
            var dbContext = new TestAppDbContextFactory().Create();
            var repository = new WatchItemRepository(dbContext);
            var messageBox = new FakeMessageBox(true);
            var service = new WatchItemService(dbContext, messageBox);

            // Act
            repository.AddRange(items);
            service.Add(addItem);
            var actualItems = service.GetAll();

            // Assert
            actualItems.Should().Equal(expectItems);
        }
    }
}
