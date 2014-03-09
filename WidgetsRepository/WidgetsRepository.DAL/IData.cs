using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WidgetsRepository.DAL
{
    public interface IData<T>
    {
        T Id { get;set; }
        object Data { get; set; }
    }

    public interface IFileSystemData :  IData<string>
    {
        string Name { get; set; }
    }

    public class FileData : IFileSystemData 
    {
        public string Name { get; set; }

        public string Id { get; set; }

        public object Data { get; set; }
    }

}
