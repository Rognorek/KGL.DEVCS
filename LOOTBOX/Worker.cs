namespace LOOTBOX
{
    public class Worker : Person
    {
        public BoxSize BaseSize { get; }
        public float Speed { get; }
        public bool IsBusy { get; set; }
        public bool IsFired { get; set; }
        public Worker(string fName,
                      string lName,
                      string mName = "",
                      BoxSize size = BoxSize.Small,
                      float speed = 5f,
                      bool isBusy = false,
                      bool isFired = false) : base(fName, lName, mName)
        {
            BaseSize = size;
            Speed = speed;
            IsBusy = isBusy;
            IsFired = isFired;
        }
        public string ToString(char delim = ';')
        {
            string result = "";
            result += FName() + delim + LName() + delim + MName();
            return result;
        }        
    }
}