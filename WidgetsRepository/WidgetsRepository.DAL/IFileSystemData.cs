using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WidgetsRepository.DAL
{
    public interface IFileSystemData<T> : IData<T>
    {
        string Name { get; set; }
    }
}
