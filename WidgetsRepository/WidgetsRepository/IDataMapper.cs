using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WidgetsRepository.DAL;

namespace WidgetsRepository
{
    public interface IDataMapper<TFileSystemObject, TEntity>
        where TFileSystemObject : IFileSystemObject
        where TEntity : IEntity
    {
        TFileSystemObject MapToFileSystemObject(TEntity entity);
        TEntity MapToEntity(TFileSystemObject fileSystemObject);
    }
}
