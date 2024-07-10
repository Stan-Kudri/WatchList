namespace WatchList.ASP.Net.Controllers.Responses
{
    public class MessageResponse
    {
        public static readonly MessageResponse Ok = new() { Message = "OK", };

        public required string Message { get; init; } = string.Empty;
    }
}
