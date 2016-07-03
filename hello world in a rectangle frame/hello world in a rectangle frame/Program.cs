using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hello_world_in_a_rectangle_frame
{
    public class Program
    {
        static void Main(string[] args)
        {
            ProgramLogic programLogic = new ProgramLogic();
            List<string> list = new List<string> { "Hello","World","in","a","frame" };
            programLogic.printListInFrame(list);
            List<string> list2 = new List<string> { "Inserts", "the", "string", "representation", "of", "a", "specified", "32", "-", "bit", "signed", "integer", "into", "this", "instance", "at", "the", "specified", "character", "position." };
            programLogic.printListInFrame(list2);                
            Console.ReadKey();
        }
    }

    public class ProgramLogic
    {
        public void execute()
        {

        }

        public void printListInFrame(List<string> list)
        {
            int maxLength = 0;
            foreach (var element in list) // find the longest element
            {
                if (maxLength < element.Length)
                    maxLength = element.Length;
            }

            // Print to console. 2 characaters for the border, 2 characters for padding, and maxLength characters for the words.
            Console.WriteLine(String.Concat(Enumerable.Repeat("*", maxLength + 4)));
            int listLength = list.Count();
            for (var i = 0; i < listLength; i++)
            {
                var whiteSpaceCount = maxLength - list[i].Length;
                Console.WriteLine("* " + list[i] + String.Concat(Enumerable.Repeat(" ", whiteSpaceCount)) + " *");
            }
            Console.WriteLine(String.Concat(Enumerable.Repeat("*", maxLength + 4)));
        }
    }
}
