namespace AssetManager.Application.Exceptions
{
    public class BadRequestException(string message, string errorCode) : Exception
    {
        public override string Message { get; } = message;
        public string ErrorCode { get; } = errorCode;
    }
}
