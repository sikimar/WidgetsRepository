using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WidgetsRepository.Entities;

namespace WidgetsRepository
{
    public interface ILayoutConteiner
    {
        List<Layout> WidgetLayouts { get; set; }
    }
}
