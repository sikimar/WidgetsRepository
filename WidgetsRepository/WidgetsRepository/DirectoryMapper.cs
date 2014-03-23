using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WidgetsRepository.DAL;

namespace WidgetsRepository
{
    public abstract class DirectoryMapper<TEntity> : FileSystemMapper<DirectoryData, TEntity>
        where TEntity : IEntity
    {
    }
}
