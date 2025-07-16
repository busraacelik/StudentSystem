namespace StudentSystem.Exception
{
    public class AppException: System.Exception
    {
        public string? ErrorCode { get;  }
        protected AppException(string message, string? errorCode = null) : base(message)
        {
            ErrorCode = errorCode;
        }

    }
    
    }

