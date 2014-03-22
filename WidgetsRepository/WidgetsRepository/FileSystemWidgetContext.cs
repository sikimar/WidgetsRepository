using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WidgetsRepository.DAL;

namespace WidgetsRepository
{
    public class FileSystemWidgetContext : DataContext<Widget>
    {
        private IFileQuery _fileQuery;
        private readonly IDirectoryQuery _directoryQuery;

        public FileSystemWidgetContext(string contextString)
            : base(contextString)
        {
            _fileQuery = new FileQuery(base.ContextString);
            _directoryQuery = new DirectoryQuery(base.ContextString);
        }

        public override Widget Find(string id)
        {
            var directroyData = _directoryQuery.Find(id);

            Widget widget = new Widget();
            widget.Id = directroyData.Id;
            widget.Name = directroyData.Name;
            widget.Guid = Guid.NewGuid();
            widget.Data = new List<IWidgetData>();

            _fileQuery = new FileQuery(base.ContextString + @"/" + widget.Name);
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
            var directoryList = _directoryQuery.GetAll();
            List<Widget> widgets = new List<Widget>();
            foreach (var directoryData in directoryList)
            {
                Widget widget = new Widget();
                widget.Id = directoryData.Id;
                widget.Name = directoryData.Name;
                widget.Data = new List<IWidgetData>();
                _fileQuery = new FileQuery(base.ContextString + "\\" + directoryData.Name);

                List<FileData> fileData = _fileQuery.GetAll();
                foreach(var file in fileData)
                {
                    widget.Data.Add( new WidgetData() { Id = file.Id, Name = file.Name, Data = file.Data });
                }

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
            FileData fileData = _fileQuery.Find(entity.Id);
            fileData.Data = entity.Data;
            _fileQuery.Update(fileData);
        }

        public override void Delete(Widget entity)
        {
            DirectoryData directoryData = _directoryQuery.Find(entity.Id);
            _directoryQuery.Delete(directoryData);
        }

        public override void Save()
        {
        }
    }
}
