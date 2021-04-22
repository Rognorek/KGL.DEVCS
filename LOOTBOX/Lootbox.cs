using System.Collections.Generic;

namespace LOOTBOX
{
    static class Lootbox
    {
        public const int MAX_LEN_STRING_FOR_NAME = 50;

        private static List<Worker> workers;
        private static Queue<Order> orders;
        static Lootbox()
        {
            workers = new();
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
        public static void AddOrder(Order order)
        {
            orders.Enqueue(order);
        }
        public static void DelOrder(Order order)
        {
            orders.Dequeue();
        }
        public static Order Peak()
        {
            return orders.Peek();
        }
    }
}