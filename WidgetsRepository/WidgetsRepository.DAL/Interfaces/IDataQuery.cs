using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WidgetsRepository.DAL
{
    public interface IDataQuery<T, in TV>
    {
        List<T> GetAll();
        T Find(TV id);
        void Insert(T data);
        void Update(T data);
        void Delete(T data);
    }
}
