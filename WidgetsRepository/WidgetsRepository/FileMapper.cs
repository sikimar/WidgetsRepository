using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WidgetsRepository.DAL;

namespace WidgetsRepository
{
    public abstract class FileMapper<TEntity> : FileSystemMapper<FileData, TEntity>
        where TEntity : IEntity
    {
    }
}
