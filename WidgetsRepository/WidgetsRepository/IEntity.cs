using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WidgetsRepository
{
    public interface IEntity
    {
        Guid Guid { get; set; }
        string Id { get; set; }
    }

    public interface IWidget : IEntity
    {
        string Name { get; set; }
        List<IWidgetData> Data { get; set; }
    }

    public interface IWidgetData : IEntity
    {
        string Name { get; set; }
        object Data { get; set; }
    }
}
