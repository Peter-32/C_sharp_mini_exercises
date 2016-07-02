using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello_World
{
    class Program
    {
        static void Main(string[] args)
        {
            HelloWorld helloWorld = new HelloWorld();
            Console.WriteLine(helloWorld.toString());
            Console.ReadKey();
        }
    }

    class HelloWorld
    {
        public string toString()
        {
            return "Hello World";
        }
    }
}
