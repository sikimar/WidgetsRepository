using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WidgetsRepository.DAL
{
    public class DirectoryQuery : FileSystemQuery, IDirectoryQuery
    {
        public DirectoryQuery(string directory):base(directory)
        {
        }

        public List<DirectoryData> GetAll()
        {
            DirectoryInfo directoryInfo = GetDirectoryInfo(base.RootDirectory);
            List<DirectoryInfo> files = directoryInfo.Exists ? directoryInfo.GetDirectories().ToList() : new List<DirectoryInfo>();

            return MapList(files);
        }

        public DirectoryData Find(string name)
        {
            DirectoryInfo directoryInfo = GetDirectoryInfo(name);

            return directoryInfo.Exists ? Map(directoryInfo) : null;
        }

        public void Insert(DirectoryData data)
        {
            DirectoryInfo directoryInfo = GetDirectoryInfo(data.Name);
            if (!directoryInfo.Exists)
            {
                directoryInfo.Create();
            }
        }

        public void Update(DirectoryData data)
        {
            Insert(data);
        }

        public void Delete(DirectoryData data)
        {
            DirectoryInfo directoryInfo = GetDirectoryInfo(data.Name);
            if (directoryInfo.Exists)
            {
                directoryInfo.Delete(true);
            }
        }

        private DirectoryData Map(DirectoryInfo directoryInfo)
        {
            DirectoryData data = new DirectoryData();
            data.Id = directoryInfo.FullName;
            data.Name = directoryInfo.Name;

            return data;
        }

        private List<DirectoryData> MapList(IEnumerable<DirectoryInfo> directories)
        {
            List<DirectoryData> fileData = new List<DirectoryData>();
            foreach (DirectoryInfo directoryInfo in directories)
            {
                DirectoryData data = Map(directoryInfo);
                fileData.Add(data);
            }

            return fileData;
        }
    }

}
