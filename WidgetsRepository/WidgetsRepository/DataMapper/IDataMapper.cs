using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WidgetsRepository.DAL;

namespace WidgetsRepository
{
    public interface IDataMapper<TDataObject, TEntity>
        where TEntity : IEntity
    {
        TDataObject MapToFileSystemObject(TEntity entity);
        TEntity MapToEntity(TDataObject fileSystemObject);
    }
}
