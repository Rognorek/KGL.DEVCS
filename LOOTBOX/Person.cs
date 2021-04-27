namespace LOOTBOX
{
    public class Person
    {
        public string FName { get; set; }
        public string LName { get; set; }
        public string MName { get; set; }

        public Person()
        {
            FName = LName = MName = "Неизвестно";
        }
        public Person(string fname, string lname, string mname)
        {
            FName = fname;
            LName = lname;
            MName = mname;
        }
    }
}