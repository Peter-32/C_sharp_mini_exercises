using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greet_User_Predicate
{
    class Program
    {
        static void Main(string[] args)
        {
            Greeter greeter = new Greeter();
            greeter.greet();
            Console.ReadKey();
        }
    }

    public class Greeter
    {
        public void greet()
        {
            Console.WriteLine("Hi, I'm a program.  What is your name?");
            var name = Console.ReadLine();
            if (name == "Alice" || name ==
                "Bob")
            {
                Console.WriteLine("It's nice to meet you {0}.", name);
            }
            else
            {
                Console.WriteLine("It's nice to meet you.");
            }
        }
    }

}
