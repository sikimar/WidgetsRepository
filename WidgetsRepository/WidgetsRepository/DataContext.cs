using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WidgetsRepository.DAL;

namespace WidgetsRepository
{
    public abstract class DataContext<TEntity> : IDataContext<TEntity> where TEntity : IEntity
    {
        private string _contextString;

        public DataContext(string contextString)
        {
            _contextString = contextString;
        }

        protected string ContextString
        {
            get { return _contextString; }
        }

        public abstract TEntity Find(string name);

        public abstract IEnumerable<TEntity> GetAll();

        public abstract void Insert(TEntity entity);

        public abstract void Update(TEntity entity);

        public abstract void Delete(TEntity entity);

        public abstract void Save();
    }
}
