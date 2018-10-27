using System;
using System.IO;
using NsuGo.Definition.Interfaces.PlatformProviders;

[assembly: Xamarin.Forms.Dependency(typeof(Todo.iOS.PlatformProviders.FileSystemProvider))]

namespace Todo.iOS.PlatformProviders
{
    public class FileSystemProvider : IFileSystemProvider
    {
        public string GetFilePath(string filename)
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(documentsPath, "..", "Library", filename);
        }
    }
}
