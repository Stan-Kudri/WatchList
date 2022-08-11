namespace ListWatchedMoviesAndSeries.Models
{
    public class Series : Cinema
    {
        public Series(string name, decimal? season) : this(name, season, null, null)
        {
        }

        public Series(string name, decimal? season, DateTime? date, decimal? grade) : base(name, date, grade)
        {
            Part = season;
        }
    }
}
