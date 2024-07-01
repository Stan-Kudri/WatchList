namespace WatchList.Core.Model
{
    public class Wrapper<T>
    {
        public T? Value { get; set; }

        public virtual string Name { get; } = string.Empty;
    }
}
