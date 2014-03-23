using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WidgetsRepository
{
    public class Widget : IWidget
    {
        public Widget(string id, string name) 
        {
            Id = id;
            Name = name;
            Guid = Guid.NewGuid();
        }

        public string Id { get; set; }
        public Guid Guid {get; set;}
        public string Name { get; set; }
        public List<IWidgetData> Data { get; set; }
    }
}
