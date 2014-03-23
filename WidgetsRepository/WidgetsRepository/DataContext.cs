using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WidgetsRepository.DAL;

namespace WidgetsRepository
{
    public abstract class DataContext : IDataContext
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

        public abstract void Save();
    }
}
