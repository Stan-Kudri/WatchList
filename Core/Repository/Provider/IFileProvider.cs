namespace Core.Repository.Provider
{
    public interface IFileProvider
    {
        public Stream Open(string path, FileMode mode);
    }
}
