using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WidgetsRepository.DAL;

namespace WidgetsRepository
{
    public class FileSystemWidgetContext : DataContext
    {
        private FileQuery _fileQuery;
        private readonly DirectoryQuery _directoryQuery;

        public FileSystemWidgetContext(string contextString)
            : base(contextString)
        {
            _fileQuery = new FileQuery(base.ContextString);
            _directoryQuery = new DirectoryQuery(base.ContextString);
        }

        public  Widget Find(string id)
        {
            var directroyData = _directoryQuery.Find(id);

            Widget widget = new Widget(directroyData.Id, directroyData.Name);
            widget.Data = new List<IWidgetData>();

            _fileQuery = new FileQuery(base.ContextString + @"/" + widget.Name);
            var fileDataList = _fileQuery.GetAll();
            foreach (var fileData in fileDataList)
            {
                WidgetData widgetData = new WidgetData(fileData.Id, fileData.Name, fileData.Data);
                widget.Data.Add(widgetData);
            }
            return widget;
        }

        public IEnumerable<Widget> GetAll()
        {
            var directoryList = _directoryQuery.GetAll();
            List<Widget> widgets = new List<Widget>();
            foreach (var directoryData in directoryList)
            {
                Widget widget = new Widget(directoryData.Id, directoryData.Name);
                widget.Data = new List<IWidgetData>();
                _fileQuery = new FileQuery(base.ContextString + "\\" + directoryData.Name);

                List<FileData> fileData = _fileQuery.GetAll();
                foreach(var file in fileData)
                {
                    widget.Data.Add( new WidgetData(file.Id, file.Name, file.Data));
                }

                widgets.Add(widget);
            }

            return widgets;
        }

        public void Insert(Widget entity)
        {
            DirectoryData directoryData = new DirectoryData(entity.Id, entity.Name);

            _directoryQuery.Insert(directoryData);

            _fileQuery = new FileQuery(directoryData.Id);
            foreach (WidgetData widgetData in entity.Data) 
            {
                FileData fileData = new FileData(widgetData.Id, widgetData.Name, Convert.ToString(widgetData.Data));
                _fileQuery.Insert(fileData);
            }
        }

        public void Update(Widget entity)
        {
            FileData fileData = _fileQuery.Find(entity.Id);
            fileData.Data = entity.Data;
            _fileQuery.Update(fileData);
        }

        public void Delete(Widget entity)
        {
            DirectoryData directoryData = _directoryQuery.Find(entity.Id);
            _directoryQuery.Delete(directoryData);
        }

        public override void Save()
        {
        }
    }
}
