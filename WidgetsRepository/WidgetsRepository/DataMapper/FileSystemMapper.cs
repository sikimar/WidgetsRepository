using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WidgetsRepository.DAL;

namespace WidgetsRepository
{
    public abstract class FileSystemMapper<TFileSystemObject, TEntity> : DataMapper<TFileSystemObject, TEntity> 
        where TFileSystemObject : class, IFileSystemObject
        where TEntity : IEntity
    {
        public abstract override TFileSystemObject MapToFileSystemObject(TEntity destination);
        public abstract override TEntity MapToEntity(TFileSystemObject source);
    }
}
