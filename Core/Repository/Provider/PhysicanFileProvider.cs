namespace Core.Repository.Provider
{
    public class PhysiсFileProvider : IFileProvider
    {
        public Stream Open(string path, FileMode mode)
        {
            var stream = new FileStream(path, mode);
            return stream;
        }
    }
}
