using ListWatchedMoviesAndSeries.Models;
using ListWatchedMoviesAndSeries.Models.Item;

namespace EqualsTest
{
    public class EqualsWatchItemlTest
    {
        [Theory]
        [MemberData(nameof(WatchItemDate))]
        public void Equals_Two_Element_With_Same_Fields(List<WatchItem> items)
        {
            //Arrange
            var сomparisonList = new List<bool>();
            //Act
            foreach (var element in items)
                сomparisonList.Add(element.Equals(element));

            //Assert
            foreach (var compare in сomparisonList)
                Assert.True(compare);
        }

        [Theory]
        [MemberData(nameof(WatchItemTwoElementsNotCompare))]
        public void Equals_Two_Element_Not_With_Same_Fields(List<WatchItem> items)
        {
            //Arrange
            var firstWatch = items[0];
            var secondWatch = items[1];

            //Act
            var comparison = firstWatch.Equals(secondWatch);

            //Assert
            Assert.False(comparison);
        }

        [Theory]
        [MemberData(nameof(WatchItemElement))]
        public void Non_Equality_Of_Two_Elements_With_One_Non_Identical_Null_Field(WatchItem item)
        {
            //Arrange
            var firstWatch = new WatchItem(
                                    item.Name,
                                    item.NumberSequel,
                                    item.Detail.DateWatch,
                                    decimal.Parse(item.Detail.Grade),
                                    item.Type,
                                    item.Id);

            var secondWatch = new WatchItem(
                                    item.Name,
                                    item.NumberSequel,
                                    item.Detail.DateWatch,
                                    decimal.Parse(item.Detail.Grade),
                                    null,
                                    item.Id);

            //Act
            var comparison = firstWatch.Equals(secondWatch);

            //Assert
            Assert.False(comparison);
        }

        [Theory]
        [MemberData(nameof(WatchItemElement))]
        public void Equality_Two_Elements_With_One_Null_Field(WatchItem item)
        {
            //Arrange
            var firstWatch = new WatchItem(
                                    item.Name,
                                    item.NumberSequel,
                                    item.Detail.DateWatch,
                                    decimal.Parse(item.Detail.Grade),
                                    null,
                                    item.Id);

            var secondWatch = new WatchItem(
                                    item.Name,
                                    item.NumberSequel,
                                    item.Detail.DateWatch,
                                    decimal.Parse(item.Detail.Grade),
                                    null,
                                    item.Id);

            //Act
            var comparison = firstWatch.Equals(secondWatch);

            //Assert
            Assert.True(comparison);
        }

        [Theory]
        [MemberData(nameof(WatchItemElement))]
        public void Equality_Two_Elements_With_Null_Detail(WatchItem item)
        {
            //Arrange
            var itemWithNullDatail = new WatchItem(
                                    item.Name,
                                    item.NumberSequel,
                                    item.Detail.DateWatch,
                                    decimal.Parse(item.Detail.Grade),
                                    item.Type,
                                    item.Id);
            itemWithNullDatail.Detail = null;

            //Act
            var comparison = item.Equals(itemWithNullDatail);

            //Assert
            Assert.False(comparison);
        }

        [Theory]
        [MemberData(nameof(WatchItemElement))]
        public void Compare_Elements_With_Null_Object(WatchItem item)
        {
            //Arrange
            var nullItem = (WatchItem?)null;

            //Act
            var comparison = item.Equals(nullItem);

            //Assert
            Assert.False(comparison);
        }

        public static IEnumerable<object[]> WatchItemDate()
        {
            return new List<object[]>
            {
                new object[]
                {
                    new List<WatchItem>()
                    {
                        new ("Тор", 1, new DateTime(2022,08,10, 00, 00, 00), 8, TypeCinema.Movie, Guid.Parse("18d4a732-ca7a-4b24-a78a-65733ba419a7")),
                        new ("Ход королевы", 1, null, null, TypeCinema.Series, Guid.Parse("5bbb70a3-0be8-4970-a95e-a5fbad2d1c72")),
                        new ("Хоббит", 1, new DateTime(2022,03,22, 00, 00, 00), 10, TypeCinema.Movie, Guid.Parse("7a7d2f55-03e9-450e-955e-4e132c956d7e"))
                    }

                },
            };
        }

        public static IEnumerable<object[]> WatchItemTwoElementsNotCompare()
        {
            return new List<object[]>
            {
                new object[]
                {
                    new List<WatchItem>()
                    {
                        new ("Тор", 1, new DateTime(2022,08,10, 00, 00, 00), 8, TypeCinema.Movie, Guid.Parse("18d4a732-ca7a-4b24-a78a-65733ba419a7")),
                        new ("Тор", 2, new DateTime(2022,09,10, 00, 00, 00), 8, TypeCinema.Movie, Guid.Parse("18d4a999-ca7a-4b24-a78a-65733ba419a7")),
                    }

                },
            };
        }

        public static IEnumerable<object[]> WatchItemElement()
        {
            yield return new object[]
            {
                new WatchItem("Тор", 1, new DateTime(2022,08,10, 00, 00, 00), 8, TypeCinema.Movie, Guid.Parse("18d4a732-ca7a-4b24-a78a-65733ba419a7")),
            };
        }
    }
}
