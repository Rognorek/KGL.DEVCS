using System;

namespace IPLootbox
{
    public class Client : Person
    {
        public int Id { get; }
        public BoxSize Boxsize { get; }
        public float Distance { get; }
        public DateTime Stamp { get; }

        public Client(int id,
                      string fname,
                      string lname,
                      string mname,
                      float distance,
                      BoxSize boxsize) : base(fname, lname, mname)
        {
            Id = id;
            Distance = distance;
            Boxsize = boxsize;
            Stamp = DateTime.Now;
        }

        public Client(int id,
                      string fname,
                      string lname,
                      string mname,
                      float distance,
                      BoxSize boxsize,
                      DateTime stamp)
        {
            Id = id;
            FName = fname;
            LName = lname;
            MName = mname;
            Distance = distance;
            Boxsize = boxsize;
            Stamp = stamp;
        }

        public Client Clone()
        {
            return new Client(this.Id,
                              this.FName,
                              this.LName,
                              this.MName,
                              this.Distance,
                              this.Boxsize,
                              this.Stamp);
        }
    }
}