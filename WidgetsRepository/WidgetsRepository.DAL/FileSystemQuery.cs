using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WidgetsRepository.DAL
{
    public abstract class FileSystemQuery
    {
        /// <summary>
        /// Working directory
        /// </summary>
        private string _rootDirectory;

        public FileSystemQuery(string directory) 
        {
            _rootDirectory = directory;
        }

        protected string RootDirectory
        {
            get { return _rootDirectory; }
        }

        protected DirectoryInfo GetDirectoryInfo(string name)
        {
            string directoryPath = Path.Combine(_rootDirectory, name);
            return new DirectoryInfo(directoryPath);
        }

        protected FileInfo GetFileInfo(string name)
        {
            string filePath = Path.Combine(_rootDirectory, name);
            return new FileInfo(filePath);
        }
    }
}
