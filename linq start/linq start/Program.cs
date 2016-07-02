using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linq_start
{
    public class Program
    {
        static void Main(string[] args)
        {
            ProgramLogic programLogic = new ProgramLogic();
            programLogic.execute();
            Console.ReadKey();
        }
    }

    public class ProgramLogic
    {
        public void execute()
        {
            string[] names = {"Burke", "Connor", "Frank",
                              "Everett", "Albert", "George",
                              "Harris", "David"};

            IEnumerable<string> query = from s in names
                                        where s.Length == 5
                                        orderby s
                                        select s.ToUpper();

            foreach (string item in query)
                Console.WriteLine(item);
        }
    }
}
