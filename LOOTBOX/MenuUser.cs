using System;

namespace LOOTBOX
{
    public static class MenuUser
    {
        public static void Work()
        {
            do
            {
                PrintMenu();

                switch (GetPressedKey())
                {
                    case ConsoleKey.D1 or ConsoleKey.NumPad1:
                        // add order

                        break;

                    case ConsoleKey.D2 or ConsoleKey.NumPad2:
                        // list queue orders

                        break;

                    case ConsoleKey.D3 or ConsoleKey.NumPad3:
                        // list workers

                        break;

                    case ConsoleKey.Escape:
                        return;

                    default:
                        break;
                }

            } while (true);
        }
        private static void PrintMenu()
        {
            Console.Clear();
            Console.WriteLine("ВЫБРАНА РОЛЬ ПОЛЬЗОВАТЕЛЬ, ВАМ ДОСТУПНЫ ДЕЙСТВИЯ:\n\n\n");
            Console.WriteLine("\t1. Оформить заказ на доставку.\n");
            Console.WriteLine("\t2. Просмотреть очередь на доставку.\n");
            Console.WriteLine("\t3. Просмотреть список работников.\n");
            Console.WriteLine("\n\n\nНажмите ESC для перехода на предыдущий экран.");
        }
        private static ConsoleKey GetPressedKey() { return Console.ReadKey(true).Key; }
    }
}