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
#if DEBUG
            #region workers_add
            workers.Add(new Worker("A", "A", "A", (BoxSize)1, 5.5f));
            workers.Add(new Worker("B", "B", "B", (BoxSize)2, 10f));
            workers.Add(new Worker("C", "C", "C", (BoxSize)3, 15f));
            workers.Add(new Worker("D", "D", "D", (BoxSize)1, 20f));
            workers.Add(new Worker("E", "E", "E", (BoxSize)2, 25f));
            workers.Add(new Worker("F", "F", "F", (BoxSize)3, 30f));
            workers.Add(new Worker("G", "G", "G", (BoxSize)1, 35f));
            workers.Add(new Worker("H", "H", "H", (BoxSize)2, 40f));
            workers.Add(new Worker("I", "I", "I", (BoxSize)3, 45f));
            workers.Add(new Worker("J", "J", "J", (BoxSize)1, 50f));
            workers.Add(new Worker("K", "K", "K", (BoxSize)2, 60f));
            workers.Add(new Worker("L", "L", "L", (BoxSize)3, 5.5f));
            workers.Add(new Worker("M", "M", "M", (BoxSize)1, 10f));
            workers.Add(new Worker("N", "N", "N", (BoxSize)2, 15f));
            workers.Add(new Worker("O", "O", "O", (BoxSize)3, 20f));
            workers.Add(new Worker("P", "P", "P", (BoxSize)1, 25f));
            workers.Add(new Worker("Q", "Q", "Q", (BoxSize)2, 30f));
            workers.Add(new Worker("R", "R", "R", (BoxSize)3, 35f));
            workers.Add(new Worker("S", "S", "S", (BoxSize)1, 40f));
            workers.Add(new Worker("T", "T", "T", (BoxSize)2, 45f));
            workers.Add(new Worker("U", "U", "U", (BoxSize)3, 50f));
            workers.Add(new Worker("V", "V", "V", (BoxSize)1, 60f));
            workers.Add(new Worker("W", "W", "W", (BoxSize)2, 100f));
            workers.Add(new Worker("X", "X", "X", (BoxSize)3, 1000f));
            workers.Add(new Worker("Y", "Y", "Y", (BoxSize)1, 0.001f));
            workers.Add(new Worker("Z", "Z", "Z", (BoxSize)2, 17.17f));
            #endregion

            #region clients_add
            // todo
            #endregion
#endif
        }
        #region with Worker
        public static void AddWorker(Worker worker)
        {
            workers.Add(worker);
        }
        public static void PrintWorkers()
        {
            foreach (Worker item in workers)
            {
                if (item.IsBusy) continue;
                Console.WriteLine(item.ToString());
            }
        }
        public static void DelWorker()
        {
            if (workers.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("Нет данных. Нажмите любую клавишу чтобы вернуться в предыщее меню.");
                GetPressedKey();
                return;
            }

            int pagesize = 5;
            int lastscreen = (int)Math.Ceiling(((Double)(workers.Count) / (Double)pagesize));
            int pos = -1;

            int screen = 1;
            ConsoleKey key;
            do
            {
                Console.Clear();
                DrawScreen(screen, pagesize, lastscreen);
                key = GetPressedKey();
                switch (key)
                {
                    case ConsoleKey.LeftArrow:
                        if (screen - 1 >= 1) screen--;
                        goto default;

                    case ConsoleKey.RightArrow:
                        if (screen + 1 <= lastscreen) screen++;
                        goto default;

                    case ConsoleKey.Escape:
                        return;

                    default:
                        if (key == ConsoleKey.D1) pos = 0;
                        if (key == ConsoleKey.D2) pos = 1;
                        if (key == ConsoleKey.D3) pos = 2;
                        if (key == ConsoleKey.D4) pos = 3;
                        if (key == ConsoleKey.D5) pos = 4;
                        if (pos != -1 && (screen - 1) * pagesize + pos < workers.Count)
                        {
                            ConsoleKey answer;

                            Console.Clear();
                            Console.WriteLine("Подтвердите удаление записи о сотруднике:\n\n\n");
                            Console.WriteLine(workers[(screen - 1) * pagesize + pos].ToString());
                            Console.WriteLine("\n\n\nY - YES. N - NO.");
                            answer = GetPressedKey();
                            if (answer == ConsoleKey.Y)
                            {
                                workers.RemoveAt((screen - 1) * pagesize + pos);

                                int prevls = lastscreen;
                                lastscreen = (int)Math.Ceiling(((Double)(workers.Count) / (Double)pagesize));
                                if (prevls > lastscreen && screen != 1)
                                {
                                    screen--;
                                }
                            }
                            pos = -1;
                        }
                        break;
                }
            } while (true);
        }
        private static void DrawScreen(int screen, int pagesize, int maxscreens)
        {
            string buff;
            string header = "|KEY|  №  |        ИМЯ         |      ФАМИЛИЯ       |      ОТЧЕСТВО      |\n";
            string footer = "| LEFT ARROW :: PREV | RIGHT ARROW :: NEXT | ESC :: BACK 2 PREVIOUS MENU |\n";

            string prefooter =
                "| PRESS KEY{1...5} THAT DELETE RECORD BY NUMBER. " +
                "   SCREEN: " + screen.ToString().PadLeft(5 - screen.ToString().Length, ' ') +
                " OF " + maxscreens.ToString().PadLeft(5 - maxscreens.ToString().Length, ' ') + " |\n";
            // SCREEN: _____ OF _____

            char border = '|';

            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(header);
            Console.ResetColor();
            int delta = (screen - 1) * pagesize;

            for (int pos = 0; pos < pagesize; pos++)
            {
                if (pos % 2 == 0)
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.ForegroundColor = ConsoleColor.White;
                }
                if (delta + pos < workers.Count)
                {
                    int index = delta + pos; int printid = index + 1;
                    buff =
                        border +
                        "[" + (1 + pos).ToString() + "]" +
                        border +
                        "".PadLeft(5 - printid.ToString().Length, ' ') + printid.ToString() +
                        border +
                        ToCoverStr(workers[index].FName) +
                        border +
                        ToCoverStr(workers[index].LName) +
                        border +
                        ToCoverStr(workers[index].MName) +
                        border;
                    Console.WriteLine(buff);
                }
                else
                {
                    break;
                }
            }

            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("".PadRight(74, '~'));
            Console.ResetColor();
            Console.WriteLine("\n\n\n");
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(prefooter);
            Console.Write(footer);
            Console.ResetColor();
        }
        private static string ToCoverStr(string str)
        {
            if (str.Length < 20) return str + "".PadRight(20 - str.Length, ' ');
            if (str.Length > 20) return str.Substring(0, 20);
            return str;
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
            if (view.Count() == 1)
            {
                Console.WriteLine(view.ElementAt(0).ToString());
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