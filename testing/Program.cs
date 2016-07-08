using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testing
{
    class Program
    {
        static void Main(string[] args)
        {
            Foo foo = new Foo();
            Console.WriteLine(foo.X);
            Console.ReadKey();
        }
    }

    class Foo
    {
        public int X = 3;
        


        public Foo() { Console.WriteLine(X);  }
    }
}
