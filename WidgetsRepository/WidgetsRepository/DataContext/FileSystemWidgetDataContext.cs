using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WidgetsRepository;

namespace WidgetsRepository
{
    public class FileSystemWidgetDataContext : WidgetDataContext
    {
        private FileGateway<WidgetData> _widgetDataGateway;
        private DirectoryGateway<Widget> _widgetGateway;

        private readonly List<WidgetData> _initialWidgetData;
        private readonly List<Widget> _initialWidget;

        public FileSystemWidgetDataContext(string contextString) : base(contextString)
        {
            _widgetDataGateway = new FileGateway<WidgetData>(base.ContextString, new WidgetDataMapper());
            _widgetGateway = new DirectoryGateway<Widget>(base.ContextString, new WidgetMapper());
        }



    }
}
