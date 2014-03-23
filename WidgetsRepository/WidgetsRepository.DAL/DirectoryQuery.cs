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

        public override List<DirectoryData> GetAll()
        {
            DirectoryInfo directoryInfo = GetDirectoryInfo(base.RootDirectory);
            List<DirectoryInfo> files = directoryInfo.Exists ? directoryInfo.GetDirectories().ToList() : new List<DirectoryInfo>();

            return MapList(files);
        }

        public override DirectoryData Find(string name)
        {
            DirectoryInfo directoryInfo = GetDirectoryInfo(name);

            return directoryInfo.Exists ? Map(directoryInfo) : null;
        }

        public override void Insert(DirectoryData data)
        {
            DirectoryInfo directoryInfo = GetDirectoryInfo(data.Name);
            if (!directoryInfo.Exists)
            {
                directoryInfo.Create();
            }
        }

        public override void Update(DirectoryData data)
        {
            Insert(data);
        }

        public override void Delete(DirectoryData data)
        {
            DirectoryInfo directoryInfo = GetDirectoryInfo(data.Name);
            if (directoryInfo.Exists)
            {
                directoryInfo.Delete(true);
            }
        }

        private DirectoryData Map(DirectoryInfo directoryInfo)
        {
            DirectoryData data = new DirectoryData(directoryInfo.FullName, directoryInfo.Name);
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
