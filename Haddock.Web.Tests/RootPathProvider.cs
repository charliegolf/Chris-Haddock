
namespace Haddock.Web.Tests
{
    using Nancy;
    using System;
    using System.IO;

    public class RootPathProvider : IRootPathProvider
    {
        private static readonly string _root;

        static RootPathProvider()
        {
            var directoryName = Path.GetDirectoryName(typeof (Bootstrapper).Assembly.CodeBase);

            if (directoryName != null)
            {
                var assemblyPath = directoryName.Replace(@"file:\", string.Empty);

                Uri uri = new Uri(Path.Combine(assemblyPath, "..", "..", "..", "Haddock.Web", "Views"));
                _root = uri.LocalPath;
            }
        }

        public string GetRootPath()
        {
            return _root;
        }
    }
}
