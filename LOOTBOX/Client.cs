using System;

namespace LOOTBOX
{
    public class Client : Person
    {
        public BoxSize BoxSize { get; }
        public float Distance { get; }
        public DateTime Stamp { get; }
        public Client(string fName,
                     string lName,
                     BoxSize size,
                     float distance,                     
                     string mName = "") : base(fName, lName, mName)
        {
            BoxSize = size;
            Distance = distance;
            Stamp = DateTime.Now;
        }
    }
}