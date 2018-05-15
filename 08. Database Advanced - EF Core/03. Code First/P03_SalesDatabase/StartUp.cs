using P03_SalesDatabase.Data;

namespace P03_SalesDatabase
{
    public class StartUp
    {
        public static void Main()
        {
            using (var db = new SalesDbContext())
            {
                db.Database.EnsureCreated();
            }
        }
    }
}
