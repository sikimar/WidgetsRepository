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

    public interface IWidget<TWidgetData> : IEntity
        where TWidgetData : IWidgetData
    {
        string Name { get; set; }
        List<TWidgetData> Data { get; set; }
    }

    public interface IWidgetData : IEntity
    {
        string Name { get; set; }
        object Data { get; set; }
    }

    public interface ILayout : IEntity
    {
        string Name { get; set; }
        string LayoutFile { get; set; }
    }
}
