using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace LOOTBOX
{
    static class Lootbox
    {
        public const int MAX_LEN_STRING_FOR_NAME = 50;

        private static List<Worker> workers;
        private static Queue<Client> clients;
        static Lootbox()
        {
            workers = new();
            clients = new();
        }
        #region with Worker
        public static void AddWorker(Worker worker)
        {
            workers.Add(worker);
        }
        public static void DelWorker(int pos)
        {
            workers.RemoveAt(pos);
        }
        public static void PrintWorkers()
        {
            foreach (Worker item in workers)
            {
                if (item.IsFired) continue;
                Console.WriteLine(item.ToString());
            }
        }
        #endregion

        #region with Client
        public static void AddClient(Client client)
        {
            clients.Enqueue(client);
        }
        public static void DelClient(Client client)
        {
            clients.Dequeue();
        }
        public static Client Peak()
        {
            return clients.Peek();
        }
        public static void PrintClient()
        {
            Console.Clear();
            IEnumerable<Client> view = clients;
            
            if (view.Count() == 0)
            {
                Console.WriteLine("Нет данных");
                return;
            }

            Console.WriteLine("Выберете режимы сортировки:" +
                " F1 - по имени;" +
                " F2 - по фамилии;" +
                " F3 - по дистанции;" +
                " F4 - по размеру посылки.");

            switch (GetPressedKey())
            {
                case ConsoleKey.F1:
                    view = clients.OrderBy(Client => Client.FName);
                    goto default;

                case ConsoleKey.F2:
                    view = clients.OrderBy(Client => Client.LName);
                    goto default;

                case ConsoleKey.F3:
                    view = clients.OrderBy(Client => Client.Distance);
                    goto default;

                case ConsoleKey.F4:
                    view = clients.OrderBy(Client => Client.Boxsize);
                    goto default;

                default:
                    foreach (var item in view)
                    {
                        Console.WriteLine(item.ToString());
                    }
                    break;
            }
        }
        #endregion
        public static ConsoleKey GetPressedKey() { return Console.ReadKey(true).Key; }
        public static bool TryInputNumber(string message, out int number)
        {
            do
            {
                Console.Clear();
                Console.WriteLine("(1 - малый, 2 - средний, 3 - большой)");
                Console.WriteLine(message);
                switch (Lootbox.GetPressedKey())
                {
                    case ConsoleKey.D1 or ConsoleKey.NumPad1:
                        number = 1; return true;

                    case ConsoleKey.D2 or ConsoleKey.NumPad3:
                        number = 2; return true;

                    case ConsoleKey.D3 or ConsoleKey.NumPad4:
                        number = 3; return true;

                    default:
                        Console.WriteLine("Введено неверное значение.");
                        break;
                }

                Console.WriteLine("Esc - вернуться в предыдущее меню.\nЛюбая клавиша для повтора ввода.");

            } while (Lootbox.GetPressedKey() != ConsoleKey.Escape);

            number = 0;
            return false;
        }
        public static bool TryInputNumber(string message, out float number)
        {
            do
            {
                Console.Clear();
                Console.Write(message);
                if (float.TryParse(Console.ReadLine(), out number))
                {
                    if (number > 0 && number <= float.MaxValue)
                    {
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Значение должно быть больше 0");
                    }
                }
                Console.WriteLine("Введено неверное значение.");
                Console.WriteLine("Esc - вернуться в предыдущее меню.\nЛюбая клавиша для повтора ввода.");

            } while (Lootbox.GetPressedKey() != ConsoleKey.Escape);

            number = 0.0f;
            return false;
        }
        public static bool TryInputString(string message, out string str)
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
                }

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Строка пустая или состоит из пробелов.");
                    input = "";
                }

                if (!Regex.IsMatch(input, pattern))
                {
                    Console.WriteLine("Строка должна содержать буквы. Пробел и или дефис для двойных фамилий.");
                    input = "";
                }
                else
                {
                    str = input;
                    return true;
                }

                Console.WriteLine("Esc - вернуться в предыдущее меню.\nЛюбая клавиша для повтора ввода.");

            } while (Lootbox.GetPressedKey() != ConsoleKey.Escape);

            str = "";
            return false;
        }

    }
}