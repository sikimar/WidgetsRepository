using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WidgetsRepository.DAL;

namespace WidgetsRepository.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            string currentDir = Directory.GetCurrentDirectory();
            string widgetsDir = currentDir + @"\Widgets";
            //FileSystemContext context = new FileSystemContext(widgetsDir);
            //Widget widget =  context.Find("Data");

            //Widget newWidget = new Widget();
            //newWidget.Id = currentDir + @"\Widgets" + @"\HelloMy";
            //newWidget.Name = "HelloMy";
            //newWidget.Guid = new Guid();
            //newWidget.Data = new List<IWidgetData>();
            //WidgetData wdata = new WidgetData();
            //wdata.Name = "Mycontent.txt";
            //wdata.Id = currentDir + @"\Widgets" + @"\HelloMy" + @"\Mycontent.txt";
            //wdata.Data = "Installation";
            //newWidget.Data.Add(wdata);
            //context.Insert(newWidget);

            //Widget widgetDel =  context.Find("HelloMy");
            //context.Delete(widgetDel);

            //string currentDir = Directory.GetCurrentDirectory();
            //FileQuery fq = new FileQuery(currentDir);

            //FileData data = new FileData();
            //data.Name = "test.text";
            //data.Data = "insidetext23253";

            //fq.GetAll();

            WidgetsRepository widgetR = new WidgetsRepository(new FileSystemWidgetContext(widgetsDir));

            List<Widget> widgets = widgetR.FindAll().ToList();


            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
