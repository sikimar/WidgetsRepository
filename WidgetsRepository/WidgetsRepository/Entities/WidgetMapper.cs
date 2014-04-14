using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WidgetsRepository.DAL;

namespace WidgetsRepository
{

    public class WidgetMapper : DirectoryMapper<Widget>
    {
        public override DirectoryData MapToFileSystemObject(Widget entity)
        {
            DirectoryData directroyData = new DirectoryData(entity.Id, entity.Name);
            return directroyData;
        }

        public override Widget MapToEntity(DirectoryData fileSystemObject)
        {
            Widget widget = new Widget(fileSystemObject.Id, fileSystemObject.Name);
            return widget;
        }
    }
}
