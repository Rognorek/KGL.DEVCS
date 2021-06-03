namespace IPLootbox
{
    public class Worker : Person
    {
        public int Id { get; }
        public BoxSize Boxsize { get; }
        public float Speed { get; }
        public bool IsBusy { get; set; }

        public Worker(int id,
                      string fname,
                      string lname,
                      string mname,
                      float speed,
                      BoxSize size,
                      bool isbusy = false) : base(fname, lname, mname)
        {
            Id = id;
            Boxsize = size;
            Speed = speed;
            IsBusy = isbusy;
        }

        public Worker Clone()
        {
            return new Worker(this.Id,
                              this.FName,
                              this.LName,
                              this.MName,
                              this.Speed,
                              this.Boxsize,
                              this.IsBusy);
        }
    }
}