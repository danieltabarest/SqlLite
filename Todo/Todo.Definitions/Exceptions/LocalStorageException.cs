using System;
namespace NsuGo.Definition.Exceptions
{
    public class LocalStorageException : Exception
    {
        public LocalStorageException(string message)
            : base(message)
        {
        }

        public LocalStorageException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
