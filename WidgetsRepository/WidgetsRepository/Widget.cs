using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WidgetsRepository
{
    public class Widget : IWidgetEntity
    {
        public string Data { get; set; }
        public string Id { get; set; }
    }
}
