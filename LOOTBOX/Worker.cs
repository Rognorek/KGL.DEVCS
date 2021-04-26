namespace LOOTBOX
{
    public class Worker : Person
    {
        public BoxSize BaseSize { get; }
        public int Speed { get; }
        public bool IsBusy { get; set; }
        public bool IsFired { get; set; }
        public Worker(string fName,
                      string lName,
                      string mName = "",
                      BoxSize size = BoxSize.Small,
                      int speed = 5,
                      bool isBusy = false,
                      bool isFired = false) : base(fName, lName, mName)
        {
            BaseSize = size;
            Speed = speed;
            IsBusy = isBusy;
            IsFired = isFired;
        }
    }
}