using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WidgetsRepository.DAL;

namespace WidgetsRepository
{
    public abstract class FileSystemMapper<TFileSystemObject, TEntity> : IDataMapper<TFileSystemObject, TEntity>
        where TFileSystemObject : IFileSystemObject
        where TEntity : IEntity
    {
        public abstract TFileSystemObject MapToFileSystemObject(TEntity destination);
        public abstract TEntity MapToEntity(TFileSystemObject source);
    }
}
