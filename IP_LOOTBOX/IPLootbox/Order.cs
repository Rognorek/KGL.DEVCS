using System;

namespace IPLootbox
{
    public class Order
    {
        private readonly int TICK_RATE = 60;
        public Client Client { get; }
        public Worker Worker { get; }
        public long TimeStart { get; }
        public bool IsDone
        {
            get
            {
                long ttl = (long)(TimeSpan.TicksPerHour * (Client.Distance / (double)(Worker.Speed * TICK_RATE)));
                return (TimeStart + ttl - DateTime.Now.Ticks) <= 0;
            }
        }
        public Order(Client client, Worker worker)
        {
            Client = client;
            Worker = worker;
            TimeStart = DateTime.Now.Ticks;
        }
        public Order(Client client, Worker worker, long timestart)
        {
            Client = client;
            Worker = worker;
            TimeStart = timestart;
        }

        public override string ToString()
        {
            return "Данные клиента: " + Client.ToString() + "|" + "Данные работника: " + Worker.ToString();
        }
        public string ToFile()
        {
            return Client.ToFile() + "|" + Worker.ToFile() + "|" + TimeStart;
        }
    }
}
