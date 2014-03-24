using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WidgetsRepository.DAL;

namespace WidgetsRepository
{
    public class FileGateway<TEntity> : FileSystemGateway<FileData, TEntity>
        where TEntity : IEntity
    {
        public FileGateway(string contextString, FileMapper<TEntity> mapper)
            :base(new FileQuery(contextString), mapper)
        {
        
        }
    }
}
