using Core.Repository.Provider;

namespace TestUnitCore
{
    public class MemoryFileProvider : IFileProvider
    {
        private readonly NoDisposMemoryStream _memoryStream = new();

        public Stream Open(string path, FileMode mode)
        {
            _memoryStream.Position = 0;
            return _memoryStream;
        }

        public string ReadJson(string path)
        {
            var stream = Open(path, FileMode.Open);
            using var streamRead = new StreamReader(stream);
            return streamRead.ReadToEnd();
        }

        public MemoryFileProvider WriteJson(string path, string jsonDate)
        {
            var stream = Open(path, FileMode.Open);
            using var streamWrite = new StreamWriter(stream);
            streamWrite.Write(jsonDate);
            return this;
        }

        private class NoDisposMemoryStream : MemoryStream
        {
            protected override void Dispose(bool disposing)
            {
            }
        }
    }
}
