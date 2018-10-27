using NsuGo.Definition.Interfaces.PlatformProviders;
using NsuGo.Definition.Interfaces.Services;

namespace NsuGo.ServiceAccess.Services
{
    public class FileSystemService : IFileSystemService
    {
        private readonly IFileSystemProvider _fileSystemProvider;

        public FileSystemService(IFileSystemProvider fileSystemProvider)
        {
            _fileSystemProvider = fileSystemProvider;
        }

        public string GetFilePath(string filename)
        {
            return _fileSystemProvider.GetFilePath(filename);
        }
    }
}
