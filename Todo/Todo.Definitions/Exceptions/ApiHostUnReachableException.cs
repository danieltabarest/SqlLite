using Todo.Common.Helpers;
using System;


namespace NsuGo.Definition.Exceptions
{
    public class ApiHostUnReachableException : Exception
    {
        public ApiHostUnReachableException() 
            : this(Preferences.ApiBaseAddress)
        {
        }

        public ApiHostUnReachableException(string message)
            : base(message)
        {
        }

        public ApiHostUnReachableException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
