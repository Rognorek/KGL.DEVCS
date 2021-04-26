using System;

namespace LOOTBOX
{
    class Program
    {
        static void Main()
        {
            do
            {
                MenuMain.PrintMenu();

                switch (Lootbox.GetPressedKey())
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