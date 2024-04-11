namespace CriteriosAplicaion.inerfaces
{
    public interface IErrorFactory{
         IErrorDetails CreateError(int errorCode, string message);
    }

    public interface IErrorDetails{
        int ErrorCode { get; }
        string Message { get; }
    }
}