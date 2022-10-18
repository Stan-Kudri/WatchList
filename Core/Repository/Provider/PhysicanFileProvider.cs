namespace Core.Repository.Provider
{
    public class PhysiсFileProvider : IFileProvider
    {
        public Stream Open(string path, FileMode mode) => new FileStream(path, mode);
    }
}
