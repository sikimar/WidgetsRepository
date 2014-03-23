using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WidgetsRepository.DAL
{
    public abstract class FileSystemQuery<TFileSystemObject> : IDataQuery<TFileSystemObject, string>
        where TFileSystemObject : IFileSystemObject
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

        public abstract List<TFileSystemObject> GetAll();

        public abstract TFileSystemObject Find(string id);

        public abstract void Insert(TFileSystemObject data);

        public abstract void Update(TFileSystemObject data);

        public abstract void Delete(TFileSystemObject data);
    }
}
