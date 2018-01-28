using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace MethodTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var xobject = new TestObject("henry","fool");
            var hobject = new TestObject("henry", "fool");
            
            var objects = new List<TestObject>
            {
                hobject,
                new TestObject("robert","genius")  
            };
            var hindex = objects.IndexOf(hobject);
            var xindex = objects.IndexOf(xobject);
            var index = objects.Exists(x => x.Name == xobject.Name && x.Value == xobject.Name);

            var xmlString = "<SSS>test</SSS>";
            var xDoc = XDocument.Parse(xmlString);
            var result = (from item in xDoc.Element("SSS")?.Elements("ff")
                select new TestObject(item.Value,item.Value)).ToList();

            Console.ReadKey();
        }
    }
}

