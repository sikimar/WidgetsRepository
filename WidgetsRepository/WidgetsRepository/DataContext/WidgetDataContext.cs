using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WidgetsRepository
{
    public class WidgetDataContext : DataContext, IWidgetConteiner, IWidgetDataConteiner
    {
        public WidgetDataContext(string contextString) : base(contextString)
        {
        }

        private List<Widget> _widgets;

        protected List<Widget> WidgetInternal
        {
            set { _widgets = value; }
        }

        public List<Widget> Widgets
        {
            get { return _widgets; }
        }

        private List<WidgetData> _widgetData;

        protected List<WidgetData> WidgetDataInternal
        {
            set { _widgetData = value; }
        }

        public List<WidgetData> WidgetData
        {
            get { return _widgetData; }
        }

        public override void Save()
        {
            throw new NotImplementedException();
        }
    }
}
