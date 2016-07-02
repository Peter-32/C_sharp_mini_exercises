using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greet_User
{
    class Program
    {
        static void Main(string[] args)
        {
            Greeter greeter = new Greeter();
            greeter.greeting();
            Console.ReadKey();
        }
    }

    public class Greeter
    {
        public void greeting()
        {
            Console.WriteLine("Hi, I'm a program.  What is your name?");
            var name = Console.ReadLine();
            Console.WriteLine("It's nice to meet you {0}.", name);
        }
    }

}
