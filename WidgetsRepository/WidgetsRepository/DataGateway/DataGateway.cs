using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WidgetsRepository
{
    public abstract class DataGateway<TEntity> : IDataGateway<TEntity>
        where TEntity : IEntity
    {
        public abstract TEntity Find(string name);

        public abstract IEnumerable<TEntity> GetAll();

        public abstract void Insert(TEntity entity);

        public abstract void Update(TEntity entity);

        public abstract void Delete(TEntity entity);
    }
}
