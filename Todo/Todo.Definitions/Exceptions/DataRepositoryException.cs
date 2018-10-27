using System;
namespace NsuGo.Definition.Exceptions
{
    public class DataRepositoryException : Exception
    {
        public DataRepositoryException() 
        {
        }

        public DataRepositoryException(string message) 
            : base(message)
        {
        }

        public DataRepositoryException(string message, Exception innerException) 
            : base(message, innerException)
        {
        }
    }
}
