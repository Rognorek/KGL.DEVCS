namespace IPLootbox
{
    public class Worker : Person
    {
        public BoxSize Boxsize { get; }
        public float Speed { get; }
        public bool IsBusy { get; set; }
        public Worker(string fname,
                      string lname,
                      string mname,
                      BoxSize size,
                      float speed,
                      bool isbusy = false) : base(fname, lname, mname)
        {
            Boxsize = size;
            Speed = speed;
            IsBusy = isbusy;
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
            result += Speed.ToString("F3");
            return result;
        }
        public string ToFile()
        {
            return $"{FName};{LName};{MName};{(int)Boxsize};{Speed.ToString("F3")};" + (IsBusy ? 1 : 0);
        }
    }
}