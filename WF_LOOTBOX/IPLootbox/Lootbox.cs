﻿using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;


namespace IPLootbox
{
    public static class Lootbox
    {
        public const int MAX_LEN_STRING_FOR_NAME = 50;

        private static readonly List<Worker> workers;
        private static List<Client> clients;
        private static List<Order> orders;

        static Lootbox()
        {
            workers = new();
            clients = new();
            orders = new();
        }

        public static void AddWorker(Worker worker)
        {
            workers.Add(worker);
        }
        public static void DelWorker(Worker worker)
        {
            workers.Remove(worker);
        }
        public static void ClearWorkers()
        {
            workers.Clear();
        }

        public static void AddClient(Client client)
        {
            clients.Add(client);
        }
        public static void DelClient(Client client)
        {
            clients.Remove(client);
        }
        public static void ClearClients()
        {
            clients.Clear();
        }

        public static void AddOrder(Order order)
        {
            orders.Add(order);
        }
        public static void DelOrder(Order order)
        {
            orders.Remove(order);
        }
        public static void ClearOrders()
        {
            orders.Clear();
        }

        public static void FeelGridWorkers(DataGridView grid)
        {
            foreach (var item in workers)
            {
                grid.Rows.Add(item.Id,
                                    item.FName,
                                    item.LName,
                                    item.MName,
                                    item.Speed,
                                    item.Boxsize.ToString(),
                                    item.IsBusy);
            }
        }

        public static bool TryInputString(string rawstring)
        {
            string pattern = "^[\\p{L}\\p{M}\\-\\s]+$";

            if (string.IsNullOrWhiteSpace(rawstring))
            {                
                return false;
            }
            else if (!Regex.IsMatch(rawstring, pattern))
            {                
                return false;
            }
            else
            {                
                return true;
            }
        }

        public static bool TryInputFloat(string rawstring, out float number)
        {
            if (float.TryParse(rawstring, out number))
            {                
                return true;
            }
            number = 0.0f;
            return false;
        }

        //private static bool TryOrder()
        //{
        //    if (clients.Count == 0) return false;
        //    if (workers.Count == 0) return false;
        //    if (orders.Any()) RickRollOrders();
        //    Client cli = clients.Peek();
        //    IEnumerable<Worker> wrks = workers
        //                                    .Where((Worker) =>
        //                                    !Worker.IsBusy && Worker.Boxsize >= cli.Boxsize)
        //                                    .OrderBy(Worker => Worker.Boxsize);

        //    if (wrks.Any())
        //    {
        //        Worker wrk = wrks.First();
        //        orders.Add(new Order(
        //                            new Client(cli.FName, cli.LName, cli.MName, cli.Boxsize, cli.Distance, cli.Stamp),
        //                            new Worker(wrk.FName, wrk.LName, wrk.MName, wrk.Boxsize, wrk.Speed, true)
        //                            )
        //                  );
        //        wrk.IsBusy = true;
        //        clients.Dequeue();
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        //private static void RickRollOrders()
        //{
        //    if (orders.Any())
        //    {
        //        for (int i = 0; i < orders.Count; i++)
        //        {
        //            if (orders[i].IsDone)
        //            {
        //                Worker wrk = workers.Find(Worker => Worker.ToFile() == orders[i].Worker.ToFile());
        //                {
        //                    if (wrk != null) wrk.IsBusy = false;
        //                }
        //                orders.RemoveAt(i);
        //                i--;
        //                if (!orders.Any()) { return; }
        //            }
        //        }
        //    }
        //}
    }
}