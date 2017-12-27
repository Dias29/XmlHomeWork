using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;

namespace XmlHomeWork
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument document = new XmlDocument();
            List<Item> item = new List<Item>();

            string path = @"https://habrahabr.ru/rss/interesting/";
            document.Load(path);

            XmlElement root = document.DocumentElement;
            
            foreach(XmlNode node in root)
            {
               
                if (node.Attributes.Count > 0)
                {
                    Item items = new Item();
                    var nodes = node.ChildNodes;

                    foreach(XmlNode child in nodes)
                    {
                        if (child.Name == "title")
                            items.Title = child.InnerText;
                        else if (child.Name == "link")
                            items.Link = child.InnerText;
                        else if (child.Name == "description")
                            items.Description = child.InnerText;
                        else if (child.Name == "pubDate")
                            items.Description = child.InnerText;
                    }
                    item.Add(items);
                }
            }

            Console.ReadLine();


        }
    }
}
