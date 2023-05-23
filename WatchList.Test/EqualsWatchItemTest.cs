using WatchList.Core.Model.ItemCinema;
using WatchList.Core.Model.ItemCinema.Components;

namespace WatchList.Test
{
    public class EqualsWatchItemTest
    {
        public static IEnumerable<object[]> TwoNotEqualItem() => new List<object[]>
        {
            new object[]
            {
                new List<WatchItem>()
                {
                    new WatchItem("Тор", 1, StatusCinema.Viewed, TypeCinema.Movie, Guid.Parse("18d4a732-ca7a-4b24-a78a-65733ba419a7"), new DateTime(2022, 08, 10, 00, 00, 00), 8),
                    new WatchItem("Тор", 2, StatusCinema.Viewed, TypeCinema.Movie, Guid.Parse("18d4a999-ca7a-4b24-a78a-65733ba419a7"), new DateTime(2022, 09, 10, 00, 00, 00), 8),
                },
            },
        };

        public static IEnumerable<object[]> WatchItemElement()
        {
            yield return new object[]
            {
                new WatchItem("Тор", 1, StatusCinema.Viewed, TypeCinema.Movie, Guid.Parse("18d4a732-ca7a-4b24-a78a-65733ba419a7"), new DateTime(2022, 08, 10, 00, 00, 00), 8),
            };
        }

        [Theory]
        [MemberData(nameof(WatchItemElement))]
        public void Equals_Two_Element_With_Same_Fields(WatchItem item)
        {
            // Act
            var comparison = item.Equals(item);

            // Assert
            Assert.True(comparison);
        }

        [Theory]
        [MemberData(nameof(TwoNotEqualItem))]
        public void Equals_Two_Element_Not_With_Same_Fields(List<WatchItem> items)
        {
            // Arrange
            var firstWatch = items[0];
            var secondWatch = items[1];

            // Act
            var comparison = firstWatch.Equals(secondWatch);

            // Assert
            Assert.False(comparison);
        }

        [Theory]
        [MemberData(nameof(WatchItemElement))]
        public void Non_Equality_Of_Two_Elements_With_One_Non_Identical_Null_Field(WatchItem item)
        {
            // Arrange
            var firstWatch = new WatchItem(
                                    item.Title,
                                    item.Sequel,
                                    item.Status,
                                    item.Type,
                                    item.Id,
                                    item.Date,
                                    item.Grade);

            var secondWatch = new WatchItem(
                                    item.Title,
                                    item.Sequel,
                                    item.Status,
                                    item.Type,
                                    null,
                                    item.Date,
                                    item.Grade);

            // Act
            var comparison = firstWatch.Equals(secondWatch);

            // Assert
            Assert.False(comparison);
        }

        [Theory]
        [MemberData(nameof(WatchItemElement))]
        public void Equality_Two_Elements_With_Null_Grade(WatchItem item)
        {
            // Arrange
            var itemNotWatch = new WatchItem(
                                    item.Title,
                                    item.Sequel,
                                    item.Status,
                                    item.Type,
                                    item.Id,
                                    item.Date,
                                    null);

            // Act
            var comparison = item.Equals(itemNotWatch);

            // Assert
            Assert.False(comparison);
        }

        [Theory]
        [MemberData(nameof(WatchItemElement))]
        public void Compare_Elements_With_Null_Object(WatchItem item)
        {
            // Arrange
            var nullItem = (WatchItem?)null;

            // Act
            var comparison = item.Equals(nullItem);

            // Assert
            Assert.False(comparison);
        }
    }
}
