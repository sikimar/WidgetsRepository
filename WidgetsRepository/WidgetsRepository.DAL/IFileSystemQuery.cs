using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WidgetsRepository.DAL
{
    public interface IDataQuery<T, V>
    {
        List<T> GetAll();
        T Find(V id);
        void Insert(T data);
        void Update(T data);
        void Delete(T data);
    }

    public interface IFileQuery : IDataQuery<IFileSystemData, string>
    {
    }

    public class FileQuery : IFileQuery
    {
        private string _directory;

        public FileQuery(string directory) 
        {
            _directory = directory;
        }

        public List<IFileSystemData> GetAll()
        {
            if (!Directory.Exists(_directory))
            {
                throw new ArgumentException(string.Format("Directory does not exist. Location: '{0}'", _directory));
            }

            DirectoryInfo di = new DirectoryInfo(_directory);
            List<FileInfo> files = di.GetFiles().ToList();


            return MapList(files);
        }

        public IFileSystemData Find(string name)
        {
            string filePath = Path.Combine(_directory, name);
            FileInfo fileInfo = new FileInfo(filePath);

            return Map(fileInfo);
        }

        public void Insert(IFileSystemData data)
        {
            string filePath = Path.Combine(_directory, data.Name);
            FileInfo fileinfo = new FileInfo(filePath);
            SaveContent(fileinfo, data.Data.ToString());
        }

        public void Update(IFileSystemData data)
        {
            string filePath = Path.Combine(_directory, data.Name);
            FileInfo fileInfo = new FileInfo(filePath);
            SaveContent(fileInfo, data.Data.ToString());
        }

        public void Delete(IFileSystemData data)
        {
            string filePath = Path.Combine(_directory, data.Name);
            FileInfo fileInfo = new FileInfo(filePath);
            fileInfo.Delete();
        }

        private IFileSystemData Map(FileInfo fileInfo) 
        {
            FileData data = new FileData();
            data.Id = fileInfo.FullName;
            data.Name = fileInfo.Name;
            data.Data = ReadContent(fileInfo);

            return data;
        }

        private List<IFileSystemData> MapList(List<FileInfo> files) 
        {
            List<IFileSystemData> fileData = new List<IFileSystemData>();
            foreach (FileInfo fileInfo in files) 
            {
                IFileSystemData data = Map(fileInfo);
                fileData.Add(data);
            }

            return fileData;
        }

        private object ReadContent(FileInfo fileInfo) 
        {
            using(StreamReader streamReader = fileInfo.OpenText())
            {
                return streamReader.ReadToEnd();
            }
        }

        private void SaveContent(FileInfo fileInfo, string content) 
        {
            using (StreamWriter streamWriter = fileInfo.CreateText())
            {
                streamWriter.Write(content);
            }
        }

        private bool IsBinaryFile(string filePath, int sampleSize = 10240)
        {
            if (!File.Exists(filePath))
                throw new ArgumentException("File path is not valid", "filePath");

            var buffer = new char[sampleSize];
            string sampleContent;

            using (var sr = new StreamReader(filePath))
            {
                int length = sr.Read(buffer, 0, sampleSize);
                sampleContent = new string(buffer, 0, length);
            }

            //Look for 4 consecutive binary zeroes
            if (sampleContent.Contains("\0\0\0\0"))
                return true;

            return false;
        }
    }
}
