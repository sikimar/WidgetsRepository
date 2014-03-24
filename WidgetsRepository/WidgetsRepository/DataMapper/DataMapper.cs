using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WidgetsRepository
{
    public abstract class DataMapper<TDataObject, TEntity> : IDataMapper<TDataObject, TEntity>
        where TDataObject : class
        where TEntity : IEntity
    {
        public abstract TDataObject MapToFileSystemObject(TEntity entity);
        public abstract TEntity MapToEntity(TDataObject fileSystemObject);
    }
}
