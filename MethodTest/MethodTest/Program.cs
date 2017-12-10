using System;
using System.Collections.Generic;

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
            Console.ReadKey();
        }
    }
}

