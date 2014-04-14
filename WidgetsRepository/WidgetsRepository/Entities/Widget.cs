using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WidgetsRepository
{
    [Serializable]
    public class Widget : IWidget<WidgetData>
    {
        public Widget(string id, string name) 
        {
            Id = id;
            Name = name;
            Guid = Guid.NewGuid();
            Data = new List<WidgetData>();
        }

        public string Id { get; set; }
        public Guid Guid {get; set;}
        public string Name { get; set; }
        public List<WidgetData> Data { get; set; }
    }
}
