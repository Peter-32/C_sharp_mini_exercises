using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Print_In_Frame
{
    public class PrintInFrame
    {
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
