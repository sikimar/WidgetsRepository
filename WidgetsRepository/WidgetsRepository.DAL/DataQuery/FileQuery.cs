using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WidgetsRepository.DAL
{
    public class FileQuery : FileSystemQuery<FileData>
    {
        public FileQuery(string directory):base(directory)
        {
        }

        public override void Insert(FileData data)
        {
            base.Insert(data);

            FileInfo fileInfo = ConvertToFileInfo(GetInfo(data.Name));
            SaveContent(fileInfo, Convert.ToString(data.Data));
        }

        protected override FileSystemInfo GetInfo(string name)
        {
            string path = Path.Combine(this.RootDirectory, name);
            return new FileInfo(path);
        }

        protected override List<FileSystemInfo> GetList(DirectoryInfo directoryInfo)
        {
            return directoryInfo.GetFiles().Cast<FileSystemInfo>().ToList();
        }

        protected override void Create(FileSystemInfo info)
        {
            // Do nothing
        }

        protected override FileData Map(FileSystemInfo info)
        {
            FileInfo fileInfo = ConvertToFileInfo(info);

            string id = fileInfo.FullName;
            string name = fileInfo.Name;
            string data = ReadContent(fileInfo);

            return new FileData(id, name, data);
        }

        protected override List<FileData> MapToList(IEnumerable<FileSystemInfo> list)
        {
            List<FileData> fileDataList = new List<FileData>();
            foreach (FileSystemInfo info in list)
            {
                FileData data = Map(info);
                fileDataList.Add(data);
            }

            return fileDataList;
        }

        private FileInfo ConvertToFileInfo(FileSystemInfo info)
        {
            FileInfo fileInfo = info as FileInfo;
            if (fileInfo == null)
            {
                throw new ArgumentException("FileQuery: Entered parameter is not type of FileInfo.");
            }

            return fileInfo;
        }

        private string ReadContent(FileInfo fileInfo)
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
    }
}
