namespace SharpGun.Exceptions
{
    public interface IKnowException
    {
        public string Message { get; }
        public int ErrorCode { get; }
        public object[] ErrorData { get; }
    }

    public class KnowException : IKnowException
    {
        public string Message { get; private set; }
        public int ErrorCode { get; private set; }
        public object[] ErrorData { get; private set; }

        public static readonly IKnowException Unknown = new KnowException
        {
            Message = "未知错误",
            ErrorCode = 599,
        };

        public static IKnowException FromKnownException(IKnowException e) {
            return new KnowException
            {
                Message = e.Message,
                ErrorCode = e.ErrorCode,
                ErrorData = e.ErrorData
            };
        }
    }
}
