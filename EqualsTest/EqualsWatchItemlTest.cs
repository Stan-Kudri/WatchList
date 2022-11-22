using ListWatchedMoviesAndSeries.Models;
using ListWatchedMoviesAndSeries.Models.Item;

namespace EqualsTest
{
    public class EqualsWatchItemlTest
    {
        public static WatchItem? _firstWathchItem = new WatchItem("Тор", 1, TypeCinema.Movie, Guid.NewGuid());
        public static WatchItem? _secondWathchItem = new WatchItem("Озарк", 2, TypeCinema.Series, Guid.NewGuid());
        public static WatchItem? _thirdWatchItem = new WatchItem("Муви 43", 3, DateTime.Now, 5, TypeCinema.Movie, Guid.NewGuid());

        //(string name, decimal? numberSequel, DateTime? date, decimal? grade, TypeCinema? type
        [Theory]
        [InlineData()]
        public void EquelsTrueTest()
        {
            Assert.Equal(_firstWathchItem, _firstWathchItem);
            Assert.Equal(_secondWathchItem, _secondWathchItem);
            Assert.Equal(_thirdWatchItem, _thirdWatchItem);
        }

        [Theory]
        [InlineData(2000, 10, 10, 8)]
        [InlineData(2022, 7, 19, 6)]
        public void EquelsFalseTest(int year, int month, int day, int grade)
        {
            Assert.False(_firstWathchItem.Equals(_secondWathchItem));
            Assert.False(_thirdWatchItem.Equals(_secondWathchItem));
            Assert.False(_firstWathchItem.Equals(_thirdWatchItem));
        }

        [Theory]
        [InlineData(2000, 10, 10, 8)]
        [InlineData(2022, 7, 19, 6)]
        public void NullObjectTest(int year, int month, int day, int grade)
        {
            var firstWatch = new WatchItem() { Name = _firstWathchItem.Name, Detail = null, Id = _firstWathchItem.Id, NumberSequel = _firstWathchItem.NumberSequel, Type = _firstWathchItem.Type };

            var secondWatch = new WatchItem { Name = _secondWathchItem.Name, Detail = _secondWathchItem.Detail, Id = _secondWathchItem.Id, NumberSequel = _secondWathchItem.NumberSequel, Type = null };

            var thirdWatch = null as WatchItem;

            Assert.False(firstWatch.Equals(secondWatch));
            Assert.False(firstWatch.Equals(thirdWatch));
            Assert.False(secondWatch.Equals(thirdWatch));

            Assert.Equal(thirdWatch, thirdWatch);
            Assert.True(secondWatch.Equals(secondWatch));
        }
    }
}
