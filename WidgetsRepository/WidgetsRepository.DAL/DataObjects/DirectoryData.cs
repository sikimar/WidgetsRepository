using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WidgetsRepository.DAL
{
    public class DirectoryData : IFileSystemObject
    {
        public DirectoryData(string id, string name) 
        {
            Id = id;
            Name = name;
        }

        public string Name { get; set; }
        public string Id { get; set; }
    }
}
