using System;
using System.Text.RegularExpressions;

namespace LOOTBOX
{
    public static class MenuAdmin
    {
        public static void Work()
        {
            do
            {
                PrintMenu();

                switch (GetPressedKey())
                {
                    case ConsoleKey.D1 or ConsoleKey.NumPad1:
                        // add worker
                        MenuAddWorker();
                        break;

                    case ConsoleKey.D2 or ConsoleKey.NumPad2:
                        // del worker
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
        private static ConsoleKey GetPressedKey() { return Console.ReadKey(true).Key; }

        private static void MenuAddWorker()
        {
            //int speed;
            //BoxSize boxsize;

            string fname = InputName("Введите имя сотрудника: ");
            string lname = InputName("Введите фамилию сотрудника: ");
            string mname = InputName("Введите отчество сотрудника: ");

            //worker = new(fname, lname, mname, boxsize, speed);
            //Lootbox.AddWorker(worker);
        }
        private static string InputName(string message)
        {
            string input, pattern = "^[\\p{L}\\p{M}\\-\\s]+$";
            do
            {
                Console.Clear();
                Console.Write(message);
                input = Console.ReadLine().Trim();
                
                if (input.Length > Lootbox.MAX_LEN_STRING_FOR_NAME)
                {
                    Console.WriteLine("Строка будет обрезана до 50 символов.");
                    input = input.Substring(0, Lootbox.MAX_LEN_STRING_FOR_NAME).Trim();
                    ;
                }
                
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Строка пустая или состоит из пробелов.");
                    input="";
                }
                
                if (!Regex.IsMatch(input, pattern))
                {
                    Console.WriteLine("Строка должна содержать буквы. Пробел и или дефис для двойных фамилий.");
                    input="";
                }               
                
                Console.WriteLine("Esc - выйти.");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);

            return input;
        }
    }
}