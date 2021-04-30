using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;


namespace IPLootbox
{
    public static class Lootbox
    {
        public const int MAX_LEN_STRING_FOR_NAME = 50;

        private static List<Worker> workers;
        private static Queue<Client> clients;
        private static List<Order> orders;
        static Lootbox()
        {
            workers = new();
            clients = new();
            orders = new();
            LoadData();
        }
        public static void SaveData()
        {
            string workerspath = Environment.CurrentDirectory + "\\Workers.txt";
            string clientspath = Environment.CurrentDirectory + "\\Clients.txt";
            string orderspath = Environment.CurrentDirectory + "\\Orders.txt";

            IEnumerable<string> workersfile = workers.Select(Worker => Worker.ToFile());
            IEnumerable<string> clientsfile = clients.Select(Client => Client.ToFile());
            IEnumerable<string> ordersfile = orders.Select(Order => Order.ToFile());

            if (File.Exists(workerspath)) { File.Delete(workerspath); }
            if (File.Exists(clientspath)) { File.Delete(clientspath); }
            if (File.Exists(orderspath)) { File.Delete(orderspath); }

            File.WriteAllLines(workerspath, workersfile, System.Text.Encoding.UTF8);
            File.WriteAllLines(clientspath, clientsfile, System.Text.Encoding.UTF8);
            File.WriteAllLines(orderspath, ordersfile, System.Text.Encoding.UTF8);
        }
        public static void LoadData()
        {
            string[] workersfile;
            string[] clientsfile;
            string[] ordersfile;

            string workerspath = Environment.CurrentDirectory + "\\Workers.txt";
            string clientspath = Environment.CurrentDirectory + "\\Clients.txt";
            string orderspath = Environment.CurrentDirectory + "\\Orders.txt";

            if (File.Exists(workerspath))
            {
                workersfile = File.ReadAllLines(workerspath, System.Text.Encoding.UTF8);

                foreach (string item in workersfile)
                {
                    string[] buff = item.Split(';');
                    workers.Add(new(fname: buff[0],
                                    lname: buff[1],
                                    mname: buff[2],
                                    size: (BoxSize)int.Parse(buff[3]),
                                    speed: float.Parse(buff[4]),
                                    isbusy: buff[5] == "0" ? false : true
                                    )
                                );
                }
            }
            if (File.Exists(workerspath))
            {
                clientsfile = File.ReadAllLines(clientspath, System.Text.Encoding.UTF8);
                foreach (string item in clientsfile)
                {
                    string[] buff = item.Split(';');
                    clients.Enqueue(new(fname: buff[0],
                                        lname: buff[1],
                                        mname: buff[2],
                                        boxsize: (BoxSize)int.Parse(buff[3]),
                                        distance: float.Parse(buff[4]),
                                        stamp: new DateTime().AddTicks(long.Parse(buff[5]))
                                        )
                                    );
                }
            }
            if (File.Exists(orderspath))
            {
                ordersfile = File.ReadAllLines(orderspath, System.Text.Encoding.UTF8);
                foreach (string item in ordersfile)
                {
                    string[] bufforder = item.Split('|');
                    string[] buffclient = bufforder[0].Split(';');
                    Client cli = new(fname: buffclient[0],
                                     lname: buffclient[1],
                                     mname: buffclient[2],
                                     boxsize: (BoxSize)int.Parse(buffclient[3]),
                                     distance: float.Parse(buffclient[4]),
                                     stamp: new DateTime().AddTicks(long.Parse(buffclient[5]))
                                     );

                    string[] buffworker = bufforder[1].Split(';');
                    Worker wrk = new(fname: buffworker[0],
                                     lname: buffworker[1],
                                     mname: buffworker[2],
                                     size: (BoxSize)int.Parse(buffworker[3]),
                                     speed: float.Parse(buffworker[4]),
                                     isbusy: buffworker[5] == "0" ? false : true
                                    );
                    long timestart = long.Parse(bufforder[2]);
                    orders.Add(new Order(cli, wrk, timestart));
                }
            }
        }
        #region with Worker
        public static void AddWorker(Worker worker)
        {
            workers.Add(worker);
        }
        public static void PrintWorkers()
        {
            if (workers.Any())
            {
                foreach (Worker item in workers)
                {
                    if (item.IsBusy) continue;
                    Console.WriteLine(item.ToString());
                }
                return;
            }
            Console.WriteLine("Нет данных.");
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
                "   SCREEN: " + screen.ToString().PadLeft(4) +
                " OF " + maxscreens.ToString().PadLeft(4) + " |\n";
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
            do
            {

            } while (TryOrder());
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
        private static bool TryOrder()
        {
            if (clients.Count == 0) return false;
            if (workers.Count == 0) return false;
            if (orders.Any()) RickRollOrders();
            Client cli = clients.Peek();
            IEnumerable<Worker> wrks = workers
                                            .Where((Worker) =>
                                            !Worker.IsBusy && Worker.Boxsize >= cli.Boxsize)
                                            .OrderBy(Worker => Worker.Boxsize);

            if (wrks.Any())
            {
                Worker wrk = wrks.First();
                orders.Add(new Order(
                                    new Client(cli.FName, cli.LName, cli.MName, cli.Boxsize, cli.Distance, cli.Stamp),
                                    new Worker(wrk.FName, wrk.LName, wrk.MName, wrk.Boxsize, wrk.Speed, true)
                                    )
                          );
                wrk.IsBusy = true;
                clients.Dequeue();
                return true;
            }
            else
            {
                return false;
            }
        }
        public static void PrintOrders()
        {
            if (orders.Any())
            {
                foreach (Order item in orders)
                {
                    Console.WriteLine(item.ToString());
                }
                return;
            }
            Console.WriteLine("Нет данных.");
        }
        private static void RickRollOrders()
        {
            if (orders.Any())
            {
                for (int i = 0; i < orders.Count; i++)
                {
                    if (orders[i].IsDone)
                    {
                        Worker wrk = workers.Find(Worker => Worker.ToFile() == orders[i].Worker.ToFile());
                        {
                            if (wrk != null) wrk.IsBusy = false;
                        }
                        orders.RemoveAt(i);
                        i--;
                        if (!orders.Any()) { return; }
                    }
                }
            }
        }
    }
}