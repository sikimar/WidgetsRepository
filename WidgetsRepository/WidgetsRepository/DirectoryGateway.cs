using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WidgetsRepository.DAL;

namespace WidgetsRepository
{
    public class DirectoryGateway<TEntity> : FileSystemGateway<DirectoryData, TEntity>
        where TEntity : IEntity
    {
        public DirectoryGateway(string contextString, DirectoryMapper<TEntity> mapper) 
            : base(new DirectoryQuery(contextString), mapper)
        {
        }
    }
}
