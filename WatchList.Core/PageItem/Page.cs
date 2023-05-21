namespace WatchList.Core.PageItem
{
    public class Page
    {
        private int _number;
        private int _size;

        public Page()
            : this(1, 5)
        {
        }

        public Page(int number, int size)
        {
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
