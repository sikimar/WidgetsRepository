using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WidgetsRepository
{
    public class WidgetsRepository : IRepository<Widget>
    {
        private DataContext _context;

        private List<Widget> _widgets;

        public WidgetsRepository(DataContext context) 
        {
            _context = context;
        }

        public DataContext Context
        {
            get { return _context; }
        }

        public Widget Find(string name)
        {
            if(_widgets == null)
            {
                _widgets = new List<Widget>();
            }

            Widget foundWidget = _widgets.Find(x => x.Name == name);
            if(foundWidget == null)
            {
                //foundWidget = _context.Find(name);

                if (foundWidget != null)
                {
                    _widgets.Add(foundWidget);
                }
            }

            return foundWidget;
        }

        public Widget FindByGuid(Guid guid)
        {
            if (_widgets == null)
            {
                _widgets = new List<Widget>();
            }

            Widget foundWidget = _widgets.Find(x => x.Guid == guid);
            return foundWidget;
        }

        public ICollection<Widget> FindAll()
        {
            if (_widgets == null)
            {
                _widgets = new List<Widget>();
            }

            //List<Widget> foundWidgets = _context.GetAll().ToList();

            //foreach (Widget widget in foundWidgets) 
            //{
            //    if(!_widgets.Exists(x => x.Name == widget.Name))
            //    {
            //        _widgets.Add(widget);
            //    }
            //}

            return _widgets;
        }

        public void Delete(Widget widget)
        {
            if (_widgets.Exists(x => x.Guid == widget.Guid)) 
            {
                _widgets.Remove(widget);
                //_context.Delete(widget);
            }
        }

        public void Insert(Widget widget)
        {
            if (!_widgets.Exists(x => x.Guid == widget.Guid)) 
            {
                _widgets.Add(widget);
                //_context.Insert(widget);
            }
        }

        public void Update(Widget widget)
        {
            Widget oldWidget = _widgets.Find(x => x.Guid == widget.Guid);
            if (oldWidget != null)
            {
                _widgets.Remove(oldWidget);
                //_context.Delete(oldWidget);
                
                _widgets.Add(widget);
                //_context.Update(widget);
            }
        }
    }
}
