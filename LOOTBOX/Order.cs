using System;

namespace LOOTBOX
{
    public class Order : Person
    {
        public BoxSize BoxSize { get; }
        public int Distance { get; }
        public DateTime Stamp { get; }
        public Order(string fName,
                     string lName,
                     BoxSize size,
                     int distance,
                     DateTime Stamp,
                     string mName = "") : base(fName, lName, mName)
        {
            BoxSize = size;
            Distance = distance;
            Stamp = DateTime.Now;
        }
    }
}