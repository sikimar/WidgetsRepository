using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WidgetsRepository.DAL
{
    public class FileQuery : FileSystemQuery, IFileQuery
    {
        public FileQuery(string directory):base(directory)
        {
        }

        public List<FileData> GetAll()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(base.RootDirectory);
            List<FileInfo> files = directoryInfo.Exists ? directoryInfo.GetFiles().ToList() : new List<FileInfo>();

            return MapList(files);
        }

        public FileData Find(string filename)
        {
            FileInfo fileInfo = GetFileInfo(filename);

            return fileInfo.Exists ? Map(fileInfo) : null;
        }

        public void Insert(FileData data)
        {
            string filename = data.Name;
            FileInfo fileInfo = GetFileInfo(filename);

            SaveContent(fileInfo, data.Data.ToString());
        }

        public void Update(FileData data)
        {
            Insert(data);
        }

        public void Delete(FileData data)
        {
            string filename = data.Name;
            FileInfo fileInfo = GetFileInfo(filename);

            if (fileInfo.Exists)
            {
                fileInfo.Delete();
            }
        }

        private FileData Map(FileInfo fileInfo)
        {
            FileData data = new FileData();
            data.Id = fileInfo.FullName;
            data.Name = fileInfo.Name;
            data.Data = ReadContent(fileInfo);

            return data;
        }

        private List<FileData> MapList(IEnumerable<FileInfo> files)
        {
            List<FileData> fileData = new List<FileData>();
            foreach (FileInfo fileInfo in files)
            {
                FileData data = Map(fileInfo);
                fileData.Add(data);
            }

            return fileData;
        }

        private object ReadContent(FileInfo fileInfo)
        {
            using (StreamReader streamReader = fileInfo.OpenText())
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
