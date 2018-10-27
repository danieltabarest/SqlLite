using System;
using System.IO;
using NsuGo.Definition.Interfaces.PlatformProviders;

[assembly: Xamarin.Forms.Dependency(typeof(Todo.Droid.PlatformProviders.FileSystemProvider))]

namespace Todo.Droid.PlatformProviders
{
    public class FileSystemProvider : IFileSystemProvider
    {
        public string GetFilePath(string filename)
        {
            var libraryPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(libraryPath, filename);
        }
    }
}
