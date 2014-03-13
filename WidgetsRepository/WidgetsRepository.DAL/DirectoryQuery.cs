using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WidgetsRepository.DAL
{
    public class DirectoryQuery : IDataQuery<IFileSystemData<string>, string>
    {
        private readonly string _directory;

        public DirectoryQuery(string directory)
        {
            _directory = directory;
        }

        public List<IFileSystemData<string>> GetAll()
        {
            if (!Directory.Exists(_directory))
            {
                throw new ArgumentException(string.Format("Directory does not exist. Location: '{0}'", _directory));
            }

            DirectoryInfo di = new DirectoryInfo(_directory);
            List<DirectoryInfo> files = di.GetDirectories().ToList();

            return MapList(files);
        }

        public IFileSystemData<string> Find(string name)
        {
            string directoryPath = Path.Combine(_directory, name);
            DirectoryInfo fileInfo = new DirectoryInfo(directoryPath);

            return Map(fileInfo);
        }

        public void Insert(IFileSystemData<string> data)
        {
            string directoryPath = Path.Combine(_directory, data.Name);
            DirectoryInfo directoryInfo = new DirectoryInfo(directoryPath);
            directoryInfo.Create();
        }

        public void Update(IFileSystemData<string> data)
        {
            //string directoryPath = Path.Combine(_directory, data.Name);
            //DirectoryInfo fileInfo = new DirectoryInfo(directoryPath);
        }

        public void Delete(IFileSystemData<string> data)
        {
            string directoryPath = Path.Combine(_directory, data.Name);
            DirectoryInfo directoryInfo = new DirectoryInfo(directoryPath);
            directoryInfo.Delete(true);
        }

        private IFileSystemData<string> Map(DirectoryInfo directoryInfo)
        {
            DirectoryData data = new DirectoryData();
            data.Id = directoryInfo.FullName;
            data.Name = directoryInfo.Name;

            return data;
        }

        private List<IFileSystemData<string>> MapList(IEnumerable<DirectoryInfo> directories)
        {
            List<IFileSystemData<string>> fileData = new List<IFileSystemData<string>>();
            foreach (DirectoryInfo directoryInfo in directories)
            {
                IFileSystemData<string> data = Map(directoryInfo);
                fileData.Add(data);
            }

            return fileData;
        }
    }

}
