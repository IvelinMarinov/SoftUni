namespace Extended_Database
{
    class Program
    {
        static void Main(string[] args)
        {

            Person person = new Person(1, "Test");
            Db db = new Db(person);

            Person person2 = new Person(2, "Test2");
            db.Add(person2);

            db.FindByUsername("");

            var debug = 0;
        }
    }
}
