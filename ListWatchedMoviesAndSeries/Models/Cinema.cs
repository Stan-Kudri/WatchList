namespace ListWatchedMoviesAndSeries
{
    public class Cinema
    {
        public string Name { get; set; } = string.Empty;

        public DateTime? Date { get; set; } = null;

        public decimal? Part { get; set; } = null;

        public string View
        {
            get
            {
                if (Date == null)
                    return "-";
                else
                    return "+";
            }
        }

        public decimal? Grade { get; set; } = 0;

        public Cinema(string name) : this(name, null, null)
        {

        }

        public Cinema(string name, DateTime? date, decimal? grade)
        {
            Name = name;
            Date = date;
            Grade = grade;
        }
    }
}
