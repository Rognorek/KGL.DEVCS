using System;

namespace IPLootbox
{
    public static class MenuAdmin
    {
        public static void Work()
        {
            do
            {
                PrintMenu();

                switch (Lootbox.GetPressedKey())
                {
                    case ConsoleKey.D1 or ConsoleKey.NumPad1:
                        // add worker
                        MenuAddWorker();
                        break;

                    case ConsoleKey.D2 or ConsoleKey.NumPad2:
                        // del worker
                        MenuDelWorker();
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
            Console.WriteLine("ВЫБРАНА РОЛЬ АДМИНИСТРАТОР, ВАМ ДОСТПУПНЫ ДЕЙСТВИЯ:\n\n\n");
            Console.WriteLine("\t1. Добавить работника.\n");
            Console.WriteLine("\t2. Удалить работника.\n");
            Console.WriteLine("\n\n\nНажмите ESC для перехода на предыдущий экран.");
        }
        private static void MenuAddWorker()
        {
            if (!Lootbox.TryInputString("Введите имя сотрудника:", out string fname)) { return; }
            if (!Lootbox.TryInputString("Введите фамилию сотрудника:", out string lname)) { return; }
            if (!Lootbox.TryInputString("Введите отчество сотрудника:", out string mname)) { return; }
            if (!Lootbox.TryInputNumber("Введите скорость доставки сотрудником (км/ч):", out float speed)) { return; }
            if (!Lootbox.TryInputNumber("Введите доступный размер бандероли для сотрудника:", out int boxsize)) { return; }

            Console.Clear();
            Console.WriteLine("Нажмите Y, чтобы добавить данные о сотруднике:\n");
            Console.WriteLine("{0} {1} {2}\nСкорость: {3:0.00}\nРазмер бандероли: {4}",
                fname, lname, mname, speed, (BoxSize)boxsize);
            if (Lootbox.GetPressedKey() == ConsoleKey.Y)
            {
                Lootbox.AddWorker(new Worker(fname, lname, mname, (BoxSize)boxsize, speed));
            }
        }
        private static void MenuDelWorker()
        {
            Lootbox.DelWorker();
        }
    }
}