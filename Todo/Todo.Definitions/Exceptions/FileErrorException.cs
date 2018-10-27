using System;
namespace NsuGo.Definition.Exceptions
{
    public class FileErrorException : Exception
    {
        public FileErrorException() 
        {
        }

        public FileErrorException(string message) 
            : base(message)
        {
        }

        public FileErrorException(string message, Exception innerException) 
            : base(message, innerException)
        {
        }
    }
}
