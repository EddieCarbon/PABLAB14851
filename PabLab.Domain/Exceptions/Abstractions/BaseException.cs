using System.Net;

namespace PabLab.Domain.Exceptions;

public abstract class BaseException : Exception
{
    public abstract HttpStatusCode StatusCode { get; }
    public BaseException(string message) : base(message)
    {
        
    }
}

