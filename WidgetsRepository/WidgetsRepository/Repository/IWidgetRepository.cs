using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WidgetsRepository
{
    public interface IRepository<TEntity> where TEntity : IEntity
    {
        TEntity Find(string name);
        TEntity FindByGuid(Guid guid);
        ICollection<TEntity> FindAll();

        void Delete(TEntity entity);
        void Insert(TEntity entity);
        void Update(TEntity entity);
    }
}
