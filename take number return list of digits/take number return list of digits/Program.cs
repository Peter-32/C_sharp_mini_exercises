using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace take_number_return_list_of_digits
{
    public class Program
    {
        static void Main(string[] args)
        {
            ProgramLogic programLogic = new ProgramLogic();
            List<int> list = programLogic.takeNumberReturnListOfDigits(1421432);
            list.ForEach (Console.WriteLine);
            Console.ReadKey();
        }
    }

    public class ProgramLogic
    {
        public void execute()
        {

        }

        public List<int> takeNumberReturnListOfDigits(int number)
        {
            number = Math.Abs(number); // don't want to deal with a negative sign
            string stringNumber = number.ToString(); // convert the number to a string            
            List<int> list = new List<int>(); // creating a list
            foreach (var chr in stringNumber) // looping over the string
            {
                list.Add(Int32.Parse(chr.ToString()));
                // list.Add(chr - '0'); Alternatively will convert from character directly to string.
            }
            return list;
        }
    }
}