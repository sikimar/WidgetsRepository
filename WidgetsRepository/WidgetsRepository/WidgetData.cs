using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WidgetsRepository
{
    public class WidgetData : IWidgetData
    {
        public string Name { get; set; }
        public Guid Guid { get; set; }
        public string Id { get; set; }
        public object Data { get; set; }
    }
}
