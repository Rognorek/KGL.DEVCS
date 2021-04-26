using System;

namespace LOOTBOX
{
    class Program
    {
        static void Main()
        {
            //do
            //{
            //    string input, pattern = "^[\\p{L}\\p{M}\\-\\s]+$";

            //    Console.Write("input=");
            //    input = Console.ReadLine().Trim();
            //    Console.WriteLine(Regex.IsMatch(input, pattern) ? "True---" : "False+++");

            //} while (Console.ReadKey(True).Key != ConsoleKey.Escape);            

            do
            {
                MenuMain.PrintMenu();

                switch (MenuMain.GetPressedKey())
                {
                    case ConsoleKey.NumPad1 or ConsoleKey.D1:
                        //user space
                        MenuUser.Work();
                        break;

                    case ConsoleKey.NumPad2 or ConsoleKey.D2:
                        //admin space
                        MenuAdmin.Work();
                        break;

                    case ConsoleKey.Escape:
                        return;

                    default:
                        break;
                }
            } while (true);
        }
    }
}