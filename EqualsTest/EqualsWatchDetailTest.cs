using ListWatchedMoviesAndSeries.Models.Item;

namespace EqualsTest
{
    public class WatchDetailTest
    {
        [Theory]
        [InlineData(2000, 10, 10, 8)]
        [InlineData(2022, 7, 19, 6)]
        public void EquelsTrueTest(int year, int month, int day, int grade)
        {
            var firstWatch = new WatchDetail(
                                    new DateTime(year, month, day),
                                    (decimal)grade);
            var secondWatch = new WatchDetail(
                                    new DateTime(year, month, day),
                                    (decimal)grade);
            Assert.True(firstWatch.Equals(secondWatch));
        }

        [Theory]
        [InlineData(2000, 10, 10, 8)]
        [InlineData(2022, 7, 19, 6)]
        public void EquelsFalseTest(int year, int month, int day, int grade)
        {
            var firstWatch = new WatchDetail(
                                    new DateTime(year, month, day),
                                    (decimal)grade);

            var newDay = day - 2;
            if (newDay <= 0)
                newDay = day + 2;
            var secondWatch = new WatchDetail(
                                    new DateTime(year, month, newDay),
                                    (decimal)grade);

            var newGrade = grade - 1;
            if (newGrade == 0)
                newGrade = grade++;
            var thirdWatch = new WatchDetail(
                                    new DateTime(year, month, newDay),
                                    (decimal)newGrade);

            Assert.False(firstWatch.Equals(secondWatch));
            Assert.False(firstWatch.Equals(thirdWatch));
            Assert.False(secondWatch.Equals(thirdWatch));
        }

        [Theory]
        [InlineData(2000, 10, 10, 8)]
        [InlineData(2022, 7, 19, 6)]
        public void NullObjectTest(int year, int month, int day, int grade)
        {
            var firstWatch = new WatchDetail(
                                    new DateTime(year, month, day),
                                    (decimal)grade);

            var secondWatch = new WatchDetail(
                                    new DateTime(year, month, day),
                                    null);

            var thirdWatch = null as WatchDetail;

            Assert.False(firstWatch.Equals(secondWatch));
            Assert.False(firstWatch.Equals(thirdWatch));
            Assert.False(secondWatch.Equals(thirdWatch));

            Assert.Equal(thirdWatch, thirdWatch);
            Assert.True(secondWatch.Equals(secondWatch));
        }
    }
}
