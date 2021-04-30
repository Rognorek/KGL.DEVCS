using System;

namespace IPLootbox
{
    public class Client : Person
    {
        public BoxSize Boxsize { get; }
        public float Distance { get; }
        public DateTime Stamp { get; }
        public Client(string fname,
                      string lname,
                      string mname,
                      BoxSize boxsize,
                      float distance) : base(fname, lname, mname)
        {
            Boxsize = boxsize;
            Distance = distance;
            Stamp = DateTime.Now;
        }
        public Client(string fname,
                      string lname,
                      string mname,
                      BoxSize boxsize,
                      float distance,
                      DateTime stamp)
        {
            FName = fname;
            LName = lname;
            MName = mname;
            Boxsize = boxsize;
            Distance = distance;
            Stamp = stamp;
        }
        public override string ToString()
        {
            string result;
            result = $"{LName} {FName} {MName} ";

            switch (Boxsize)
            {
                case BoxSize.Small:
                    result += "Малый ";
                    break;
                case BoxSize.Middle:
                    result += "Средний ";
                    break;
                case BoxSize.Big:
                    result += "Большой ";
                    break;
            }
            result += Distance.ToString("F3");
            return result;
        }
        public string ToFile()
        {
            return $"{FName};{LName};{MName};{(int)Boxsize};{Distance.ToString("F3")};{Stamp.Ticks.ToString()}";
        }
    }
}