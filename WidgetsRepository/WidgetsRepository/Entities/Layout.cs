using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WidgetsRepository.Entities
{
    public class Layout : ILayout
    {
        public Layout(string id, string name, string layout)
        {
            Id = id;
            Name = name;
            LayoutFile = layout;
            Guid = Guid.NewGuid();
        }

        public string Name { get; set; }
        public Guid Guid { get; set; }
        public string Id { get; set; }
        public string LayoutFile { get; set; }
    }
}
