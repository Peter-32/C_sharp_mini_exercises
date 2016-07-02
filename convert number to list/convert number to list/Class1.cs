using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace convert_number_to_list
{
    public static class ListUtils
    {

        public static List<int> convertNumberToList(int number)
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
