using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guessing_Game_Secret_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            Initialize initialize = new Initialize();
            initialize.execute();
            GameLoop   gameLoop   = new GameLoop(initialize);
            gameLoop.mainLoop();
        }
    }

    public class Initialize
    {
        public int secretNumber
        {
            get;
            set;
        }

        public void execute()
        {
            setSecretNumber();
            Console.WriteLine("A secret integer has been generated and is between 1 and 100!");
            Console.WriteLine("Try to guess the secret integer!");
        }

        public void setSecretNumber()
        {
            Random rnd = new Random();
            secretNumber = rnd.Next(1, 101); // excludes 101
        }
    }

    public class GameLoop
    {
        public GameLoop(Initialize initialize)
        {
            this.initialize = initialize;
            System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
            this.stopwatch = stopwatch;
        }

        public int currentGuess
        {
            get;
            set;
        }

        public int guessCounter
        {
            get;
            set;
        }

        public void mainLoop()
        {

            promptUserAndUpdateCurrentGuess();
            stopwatch.Start();
            guessCounter++;
            if (currentGuess == initialize.secretNumber)
            {
                stopwatch.Stop();
                GameEnd gameEnd = new GameEnd(guessCounter, stopwatch.ElapsedMilliseconds / 1000);
                gameEnd.execute();
            }
            displayConditionalMessage();
            mainLoop();
        }

        public void promptUserAndUpdateCurrentGuess()
        {
            Console.WriteLine("What integer will you guess?");
            int guess;
            string line = Console.ReadLine();
            while(!Int32.TryParse(line, out guess))
            {
                Console.WriteLine("Not a valid integer, try again.");

                line = Console.ReadLine();
            }
            currentGuess = guess;
        }

        public void displayConditionalMessage()
        {
            if (currentGuess > initialize.secretNumber)
            {
                Console.WriteLine("The number is too high");
            } else
            {
                Console.WriteLine("The number is too low");
            }
        }

        private readonly Initialize initialize;
        private readonly System.Diagnostics.Stopwatch stopwatch;
    }

    public class GameEnd
    {
        public GameEnd (int guessesTaken, decimal timeTaken)
        {
            this.guessesTaken = guessesTaken;
            this.timeTaken = timeTaken;
        }

        public void execute()
        {
            Console.WriteLine("Congratulations! You found the secret number and beat the game in {0} guess(es) taking {1} seconds!", guessesTaken, timeTaken);
            if (timeTaken > 8) Console.WriteLine("Try to win in under 8 seconds!");
            else Console.Write("That was under 8 seconds!");
            Console.ReadKey();
            System.Environment.Exit(1);
        }

        private readonly int guessesTaken;
        private readonly decimal timeTaken;
    }
}