using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WidgetsRepository.DAL
{
    public class DirectoryQuery : FileSystemQuery<DirectoryData>
    {
        public DirectoryQuery(string directory):base(directory)
        {
        }

        protected override FileSystemInfo GetInfo(string name)
        {
            string path = Path.Combine(this.RootDirectory, name);
            return new DirectoryInfo(path);
        }

        protected override List<FileSystemInfo> GetList(DirectoryInfo directoryInfo)
        {
            return directoryInfo.GetDirectories().Cast<FileSystemInfo>().ToList();
        }

        protected override void Create(FileSystemInfo info)
        {
            DirectoryInfo directoryInfo = ConvertToDirectoryInfo(info);
            directoryInfo.Create();
        }

        protected override void Delete(FileSystemInfo info)
        {
            DirectoryInfo directoryInfo = ConvertToDirectoryInfo(info);
            directoryInfo.Delete(true);
        }

        protected override DirectoryData Map(FileSystemInfo info)
        {
            DirectoryInfo directoryInfo = ConvertToDirectoryInfo(info);
            return new DirectoryData(directoryInfo.FullName, directoryInfo.Name);
        }

        protected override List<DirectoryData> MapToList(IEnumerable<FileSystemInfo> list)
        {
            List<DirectoryData> directoryDataList = new List<DirectoryData>();
            foreach (FileSystemInfo info in list)
            {
                DirectoryData data = Map(info);
                directoryDataList.Add(data);
            }

            return directoryDataList;
        }

        private DirectoryInfo ConvertToDirectoryInfo(FileSystemInfo info)
        {
            DirectoryInfo directoryInfo = info as DirectoryInfo;
            if (directoryInfo == null)
            {
                throw new ArgumentException("DirectoryQuery: Entered parameter is not type of DirectoryInfo.");
            }

            return directoryInfo;
        }
    }

}
