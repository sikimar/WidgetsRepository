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


            WidgetDataContext wdc = new WidgetDataContext(widgetsDir);
            List<Widget> widgets = wdc.Widgets;

            Widget newWid1 = new Widget(null, "Hapukurk1");
            WidgetData wdata1 = new WidgetData(null, "Add1.txt", "Data");
            newWid1.Data.Add(wdata1);
            WidgetData wdata2 = new WidgetData(null, "Add2.txt", "Data");
            newWid1.Data.Add(wdata2);

            Widget newWid2 = new Widget(null, "Hapukurk2");
            WidgetData wdata11 = new WidgetData(null, "Add1.txt", "Data");
            newWid2.Data.Add(wdata11);
            WidgetData wdata22 = new WidgetData(null, "Add2.txt", "Data");
            newWid2.Data.Add(wdata22);

            Widget newWid3 = new Widget(null, "Hapukurk3");
            WidgetData wdata111 = new WidgetData(null, "Add1.txt", "Data");
            newWid3.Data.Add(wdata111);
            WidgetData wdata222 = new WidgetData(null, "Add2.txt", "Data");
            newWid3.Data.Add(wdata222);

            wdc.Add(newWid1);
            wdc.Add(newWid2);
            wdc.Add(newWid3);

            List<Widget> widgets1 = wdc.Widgets;
            Widget removeWid = widgets1[14];
            removeWid.Name = "Hernes";
            wdc.Update(removeWid);
            Widget removeSaveWid = widgets1[2];
            wdc.Delete(removeSaveWid);
            Widget chan = widgets1[1];
            chan.Name = "OHOO";
            chan.Data.Add(new WidgetData(null, "TESTq1.rrt", "DATA TEST"));
            wdc.Update(chan);

            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
