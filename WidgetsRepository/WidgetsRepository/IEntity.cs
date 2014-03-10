using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WidgetsRepository
{
    public interface IEntity
    {
        string Id { get; set; }
    }

    public interface IWidgetEntity : IEntity
    {
        string Data { get; set; }
    }
}
