﻿namespace LOOTBOX
{
    public class Worker : Person
    {
        public BoxSize Boxsize { get; }
        public float Speed { get; }
        public bool IsBusy { get; set; }
        public bool IsFired { get; set; }
        public Worker(string fname,
                      string lname,
                      string mname,
                      BoxSize size,
                      float speed,
                      bool isbusy = false,
                      bool isfired = false) : base(fname, lname, mname)
        {
            Boxsize = size;
            Speed = speed;
            IsBusy = isbusy;
            IsFired = isfired;
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
            result += Speed.ToString("0.000");
            return result;
        }
    }
}