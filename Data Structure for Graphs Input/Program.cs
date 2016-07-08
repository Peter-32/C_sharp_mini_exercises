using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Structure_for_Graphs_DDL;

namespace Data_Structure_for_Graphs_Input
{
    class Program
    {
        static void Main(string[] args)
        {
            PromptInput.mainLoop();
            Console.ReadKey();
        }
    }

    public static class PromptInput
    {
        private static string line = "";
        private static bool exit = false;

        // the main loop
        public static void mainLoop()
        {
            do
            {
                // get input from the user
                Console.WriteLine("Please issue a command for the graph input pile.");
                line = Console.ReadLine();
                placeInInputPile(line);
                updateExit(line);
            } while (!exit);
        }

        // issues the request to the graphing ddl
        public static void placeInInputPile(string input)
        {
            InputPile.issueRequest(input);
        }
        
        public static void updateExit(string line)
        {
            if (line == "exit" || line == "quit")
                exit = true;
            else
                exit = false;
        }
    }

}
