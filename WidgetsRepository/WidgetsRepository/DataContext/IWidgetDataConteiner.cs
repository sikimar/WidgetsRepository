using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WidgetsRepository
{
    public interface IWidgetDataConteiner
    {
        List<WidgetData> WidgetData { get; }
    }
}
