using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WidgetsRepository
{
    [Serializable]
    public class WidgetData : IWidgetData
    {
        public WidgetData(string id, string name, object data)
        {
            Id = id;
            Name = name;
            Data = data;
            Guid = Guid.NewGuid();
        }

        public string Name { get; set; }
        public Guid Guid { get; set; }
        public string Id { get; set; }
        public object Data { get; set; }
    }
}
