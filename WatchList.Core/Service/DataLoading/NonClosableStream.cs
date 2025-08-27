namespace WatchList.Core.Service.DataLoading
{
    public class NonClosableStream : Stream
    {
        private readonly Stream _root;

        public NonClosableStream(Stream root) => _root = root;

        public bool AllowClose { get; set; }

        public override bool CanRead => _root.CanRead;

        public override bool CanSeek => _root.CanSeek;

        public override bool CanWrite => _root.CanWrite;

        public override long Length => _root.Length;

        public override long Position
        {
            get => _root.Position;
            set => _root.Position = value;
        }

        public override void Close()
        {
            if (AllowClose)
            {
                _root.Close();
            }
        }

        public override void Flush() => _root.Flush();

        public override int Read(byte[] buffer, int offset, int count)
            => _root.Read(buffer, offset, count);

        public override long Seek(long offset, SeekOrigin origin)
            => _root.Seek(offset, origin);

        public override void SetLength(long value)
            => _root.SetLength(value);

        public override void Write(byte[] buffer, int offset, int count)
            => _root.Write(buffer, offset, count);
    }
}
