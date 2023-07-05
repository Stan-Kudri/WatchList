namespace WatchList.Core.PageItem
{
    public class Page
    {
        private const int StartPageSize = 10;
        private const int NumberStartPage = 1;

        private int _number;
        private int _size;

        public Page(int number = NumberStartPage, int size = StartPageSize)
        {
            if (number <= 0)
            {
                throw new ArgumentException("The page number is greater than zero.", nameof(number));
            }

            if (size <= 0)
            {
                throw new ArgumentException("The page must contain an element.", nameof(number));
            }

            _size = size;
            _number = number;
        }

        public int Number
        {
            get => _number;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Page number can not be less than zero.", nameof(value));
                }

                _number = value;
            }
        }

        public int Size
        {
            get => _size;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Page size can not be less than one.", nameof(value));
                }

                _size = value;
            }
        }
    }
}
