using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WidgetsRepository.DAL
{
    public abstract class FileSystemQuery<TFileSystemObject> : DataQuery<TFileSystemObject, string>
        where TFileSystemObject : class, IFileSystemObject
    {
        /// <summary>
        /// Working directory
        /// </summary>
        private readonly string _rootDirectory;

        public FileSystemQuery(string directory) 
        {
            _rootDirectory = directory;
        }

        protected string RootDirectory
        {
            get { return _rootDirectory; }
        }

        protected abstract FileSystemInfo GetInfo(string name);
        protected abstract List<FileSystemInfo> GetList(DirectoryInfo info);
        protected abstract void Create(FileSystemInfo info);
        protected abstract TFileSystemObject Map(FileSystemInfo info);
        protected abstract List<TFileSystemObject> MapToList(IEnumerable<FileSystemInfo> list);

        protected virtual void Delete(FileSystemInfo info)
        {
            info.Delete();
        }

        public override List<TFileSystemObject> GetAll()
        {
            DirectoryInfo info = new DirectoryInfo(this.RootDirectory);
            List<FileSystemInfo> list = GetList(info);

            return list != null && list.Count > 0 ?  MapToList(list) : new List<TFileSystemObject>();
        }

        public override TFileSystemObject Find(string name)
        {
            FileSystemInfo info = GetInfo(name);
            return info.Exists ? Map(info) : null;
        }

        public override void Insert(TFileSystemObject data)
        {
            string name = data.Name;
            FileSystemInfo info = GetInfo(name);
            if (!info.Exists)
            {
                this.Create(info);
            }
        }

        public override void Update(TFileSystemObject data)
        {
            Insert(data);
        }

        public override void Delete(TFileSystemObject data)
        {
            FileSystemInfo info = GetInfo(data.Name);
            if (info.Exists)
            {
                this.Delete(info);
            }
        }
    }
}
