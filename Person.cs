namespace LOOTBOX
{
    public class Person
    {
        private readonly string fName = "", lName = "", mName = "";
        public Person(string fName, string lName, string mName = "")
        {
            this.fName = fName;
            this.lName = lName;
            this.mName = mName;
        }
        public string FName() { return fName; }
        public string LName() { return lName; }
        public string MName() { return mName; }
    }
}