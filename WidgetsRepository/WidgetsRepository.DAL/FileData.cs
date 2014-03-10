using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WidgetsRepository.DAL
{
    public class FileData : IFileSystemData<string>
    {
        public string Name { get; set; }

        public string Id { get; set; }

        public object Data { get; set; }
    }
}
