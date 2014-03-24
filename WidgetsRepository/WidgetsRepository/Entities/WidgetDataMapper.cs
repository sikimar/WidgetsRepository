using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WidgetsRepository.DAL;

namespace WidgetsRepository
{
    public class WidgetDataMapper : FileMapper<WidgetData>
    {
        public override FileData MapToFileSystemObject(WidgetData entity)
        {
            FileData fileData = new FileData(entity.Id, entity.Name, Convert.ToString(entity.Data));
            return fileData;
        }

        public override WidgetData MapToEntity(FileData fileSystemObject)
        {
            WidgetData widgetData = new WidgetData(fileSystemObject.Id, fileSystemObject.Name, fileSystemObject.Data);
            return widgetData;
        }
    }
}
