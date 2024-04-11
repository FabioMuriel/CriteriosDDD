using CriteriosAplicaion.inerfaces;

namespace CriteriosAplicaion.Services
{
    public class ErrorFactory : IErrorFactory
    {
        public IErrorDetails CreateError(int errorCode, string message)
        {
            return new ErrorDetails
            {
                ErrorCode = errorCode,
                Message = message
            };
        }
        
    }

    public class ErrorDetails : IErrorDetails
    {
        public int ErrorCode { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}