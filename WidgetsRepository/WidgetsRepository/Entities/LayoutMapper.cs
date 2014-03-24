using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WidgetsRepository.DAL;

namespace WidgetsRepository.Entities
{
    public class LayoutMapper : FileMapper<Layout>
    {
        public override FileData MapToFileSystemObject(Layout entity)
        {
            FileData fileData = new FileData(entity.Id, entity.Name, entity.LayoutFile);
            return fileData;
        }

        public override Layout MapToEntity(FileData fileSystemObject)
        {
            Layout widgetLayout = new Layout(fileSystemObject.Id, fileSystemObject.Name, Convert.ToString(fileSystemObject.Data));
            return widgetLayout;
        }
    }
}
