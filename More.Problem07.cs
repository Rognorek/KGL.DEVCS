using System;

namespace MoreProblemMul2Add3
{
    class Mul2_Add3
    {
        enum Answer : int
        {
            No = 0,
            Yes = 1
        }
        private static void Main()
        {
            string userInputString;            

            do
            {
                Console.Clear();
                userInputString = InputString();

                if (!IsNumber(userInputString))
                {                 
                    Console.WriteLine("Wrong input data!");
                }
                else
                {
                    PrintResult(Calculate(int.Parse(userInputString)));
                }

                Console.Write("Repeat?(Y/N)");
            } while (Console.ReadKey().Key == ConsoleKey.Y);
        }
        private static void PrintResult(Answer answer)
        {
            Console.WriteLine("{0}", answer == Answer.Yes ? "Yes." : "No.");
        }
        private static bool IsNumber(string input)
        {
            int number;

            if (int.TryParse(input, out number))
            {
                if (number > 0) return true;
            }
            return false;
        }
        private static string InputString()
        {
            string consoleInputString;

            do
            {
                Console.Write("Input any integer positive number: ");
                consoleInputString = Console.ReadLine().Trim();
            } while (string.IsNullOrWhiteSpace(consoleInputString));

            return consoleInputString;
        }
        private static Answer Calculate(int number)
        {
            switch (number)
            {
                case 3:
                    return Answer.No;                                    
                default:
                    return Answer.Yes;                    
            }
        }
    }
}

