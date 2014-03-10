using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WidgetsRepository.DAL;

namespace WidgetsRepository
{
    public class FileDataContext : DataContext<Widget, string>
    {
        private readonly IDataQuery<IFileSystemData<string>, string> _query;

        public FileDataContext(string contextString):base(contextString)
        {
            _query =  new FileQuery(_contextString);
        }

        public override Widget Find(string id)
        {
            var fileInfo = _query.Find(id);
            Widget widget = new Widget();
            widget.Id = fileInfo.Id;
            widget.Data = fileInfo.Data.ToString();
            return widget;
        }

        public override IEnumerable<Widget> GetAll()
        {
            var fileInfoList = _query.GetAll();
            List<Widget> widgets = new List<Widget>();
            foreach (var fileInfo in fileInfoList)
            {
                Widget widget = new Widget();
                widget.Id = fileInfo.Id;
                widget.Data = fileInfo.Data.ToString();
                widgets.Add(widget);
            }

            return widgets;
        }

        public override void Insert(Widget entity)
        {
            FileData fileData = new FileData();
            fileData.Id = entity.Id;
            fileData.Data = entity.Data;
            _query.Insert(fileData);
        }

        public override void Update(Widget entity)
        {
            IFileSystemData<string> fileData = _query.Find(entity.Id);
            fileData.Data = entity.Data;
            _query.Update(fileData);
        }

        public override void Delete(Widget entity)
        {
            IFileSystemData<string> fileData = _query.Find(entity.Id);
            _query.Delete(fileData);
        }

        public override void Save()
        {
        }
    }
}
