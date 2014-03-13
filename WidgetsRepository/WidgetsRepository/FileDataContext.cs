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
        private IDataQuery<IFileSystemData<string>, string> _fileQuery;
        private readonly IDataQuery<IFileSystemData<string>, string> _directoryQuery;

        public FileDataContext(string contextString):base(contextString)
        {
            _fileQuery = new FileQuery(_contextString);
            _directoryQuery = new DirectoryQuery(_contextString);
        }

        public override Widget Find(string id)
        {
            var directroyData = _directoryQuery.Find(id);

            Widget widget = new Widget();
            widget.Id = directroyData.Id;
            widget.Name = directroyData.Name;
            widget.Guid = Guid.NewGuid();
            widget.Data = new List<IWidgetData>();

            _fileQuery = new FileQuery(_contextString + @"/" + widget.Name);
            var fileDataList = _fileQuery.GetAll();
            foreach (var fileData in fileDataList)
            {
                WidgetData widgetData = new WidgetData();
                widgetData.Id = fileData.Id;
                widgetData.Name = fileData.Name;
                widgetData.Data = fileData.Data;
                widget.Data.Add(widgetData);
            }
            return widget;
        }

        public override IEnumerable<Widget> GetAll()
        {
            var fileInfoList = _fileQuery.GetAll();
            List<Widget> widgets = new List<Widget>();
            foreach (var fileInfo in fileInfoList)
            {
                Widget widget = new Widget();
                widget.Id = fileInfo.Id;
                widget.Data = new List<IWidgetData>() { new WidgetData() { Data = fileInfo.Data } };
                widgets.Add(widget);
            }

            return widgets;
        }

        public override void Insert(Widget entity)
        {
            DirectoryData directoryData = new DirectoryData();

            directoryData.Id = entity.Id;
            directoryData.Name = entity.Name;

            _directoryQuery.Insert(directoryData);

            _fileQuery = new FileQuery(directoryData.Id);
            foreach (WidgetData widgetData in entity.Data) 
            {
                FileData fileData = new FileData();
                fileData.Id = widgetData.Id;
                fileData.Name = widgetData.Name;
                fileData.Data = widgetData.Data;
                _fileQuery.Insert(fileData);
            }
        }

        public override void Update(Widget entity)
        {
            IFileSystemData<string> fileData = _fileQuery.Find(entity.Id);
            fileData.Data = entity.Data;
            _fileQuery.Update(fileData);
        }

        public override void Delete(Widget entity)
        {
            IFileSystemData<string> directoryData = _directoryQuery.Find(entity.Id);
            _directoryQuery.Delete(directoryData);
        }

        public override void Save()
        {
        }
    }
}
