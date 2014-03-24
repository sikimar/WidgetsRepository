using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WidgetsRepository.DAL
{
    public abstract class DataQuery<TFileSystemObject, TIdType> : IDataQuery<TFileSystemObject, TIdType>
        where TFileSystemObject : class, IFileSystemObject
    {
        public abstract List<TFileSystemObject> GetAll();

        public abstract TFileSystemObject Find(TIdType id);

        public abstract void Insert(TFileSystemObject data);

        public abstract void Update(TFileSystemObject data);

        public abstract void Delete(TFileSystemObject data);
    }
}
