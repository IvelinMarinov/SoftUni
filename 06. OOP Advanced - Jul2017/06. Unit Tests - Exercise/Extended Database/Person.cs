namespace Extended_Database
{
    public class Person
    {
        public Person(long id, string username)
        {
            this.Id = id;
            this.Username = username;
        }
        
        public long Id { get; set; }

        public string Username { get; set; }
    }
}
