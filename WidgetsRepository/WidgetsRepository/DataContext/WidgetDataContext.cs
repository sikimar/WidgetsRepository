using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace WidgetsRepository
{
    public class WidgetDataContext : DataContext, IWidgetConteiner
    {
        // Make so that if edit then delete old and add new

        private ObjectStateManager<Widget> _widgetManager;
        private DirectoryGateway<Widget> _widgetGateway;

        public WidgetDataContext(string contextString) : base(contextString)
        {
            _widgetManager = new ObjectStateManager<Widget>();
            _widgetGateway = new DirectoryGateway<Widget>(base.ContextString, new WidgetMapper());

            LoadData();
        }

        public List<Widget> Widgets
        {
            get 
            {
                List<Widget> widgets = _widgetManager.WorkObjects;
                List<Widget> returnWidgets = new List<Widget>();
                foreach (Widget widget in widgets) 
                {
                    returnWidgets.Add(ObjectCopy.DeepCopy<Widget>(widget));
                }

                return returnWidgets;
            }
        }


        public override void Save()
        {
            throw new NotImplementedException();
        }

        private void LoadData() 
        {
            LoadWidgets();
        }

        private void LoadWidgets() 
        {
            List<Widget> widgets = _widgetGateway.GetAll().ToList();
            foreach (Widget widget in widgets)
            {
                List<WidgetData> widgetData = LoadWidgetData(widget);
                widget.Data = widgetData;
                _widgetManager.RegisterObject(widget);
            }
        }

        private List<WidgetData> LoadWidgetData(Widget widget) 
        {
            FileGateway<WidgetData> widgetDataGateway = 
                new FileGateway<WidgetData>(base.ContextString +"\\"+ widget.Name, new WidgetDataMapper());
            return widgetDataGateway.GetAll().ToList();
        }

        public void Add(Widget widget) 
        {
            _widgetManager.NewObject(widget);
        }

        public void Update(Widget widget) 
        {
            _widgetManager.ModifyObject(widget);
        }

        public void Delete(Widget widget) 
        {
            _widgetManager.DeleteObject(widget);
        }
    }
}
