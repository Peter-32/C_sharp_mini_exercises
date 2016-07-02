using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isPalindrome
{
    public class Program
    {
        static void Main(string[] args)
        {
            ProgramLogic programLogic = new ProgramLogic();
            Console.ReadKey();
        }
    }

    public class ProgramLogic
    {
        public void execute()
        {

        }

        public bool isPalindrome(string str)
        {
            int length = str.Length;
            int i = 1;

            foreach (var chr in str)
            {
                if (chr != str[length - i])
                {
                    return false;
                }
                i++;
            }
            return true;
        }
    }
}