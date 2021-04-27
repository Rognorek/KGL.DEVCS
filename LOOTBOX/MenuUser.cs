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

                switch (Lootbox.GetPressedKey())
                {
                    case ConsoleKey.D1 or ConsoleKey.NumPad1:
                        // add order
                        MenuAddClient();
                        break;

                    case ConsoleKey.D2 or ConsoleKey.NumPad2:
                        // list queue
                        MenuListClient();
                        break;

                    case ConsoleKey.D3 or ConsoleKey.NumPad3:
                        // list workers
                        MenuListWorkres();
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
        private static void MenuAddClient()
        {
            if (!Lootbox.TryInputString("Введите имя:", out string fname)) { return; }
            if (!Lootbox.TryInputString("Введите фамилию:", out string lname)) { return; }
            if (!Lootbox.TryInputString("Введите отчество:", out string mname)) { return; }
            if (!Lootbox.TryInputNumber("Введите дистанцию (км):", out float distance)) { return; }
            if (!Lootbox.TryInputNumber("Выберете размер бандероли:", out int boxsize)) { return; }

            Console.Clear();
            Console.WriteLine("Нажмите Y, чтобы оформить заказ:\n");
            Console.WriteLine("{0} {1} {2}\nДистанция: {3:0.00} км.\nРазмер бандероли: {4}",
                fname, lname, mname, distance, (BoxSize)boxsize);
            if (Lootbox.GetPressedKey() == ConsoleKey.Y)
            {
                Lootbox.AddClient(new Client(fname, lname, mname, (BoxSize)boxsize, distance));
            }
        }
        private static void MenuListWorkres()
        {
            do
            {
                Console.Clear();
                Lootbox.PrintWorkers();
                Console.WriteLine("\n\n\n Для возврата нажмите Esc");
            } while (Lootbox.GetPressedKey() != ConsoleKey.Escape);
        }
        private static void MenuListClient()
        {
            do
            {
                Console.Clear();
                Lootbox.PrintClient();
                Console.WriteLine("\n\n\n Для возврата нажмите Esc");
            } while (Lootbox.GetPressedKey() != ConsoleKey.Escape);
        }
    }
}