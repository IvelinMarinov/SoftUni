namespace _03.Attributes
{
    [SoftUni("Ventsi")]
    public class StartUp
    {
        [SoftUni("Gosho")]
        public static void Main()
        {
            var tracker = new Tracker();
            tracker.PrintMethodsByAuthor();
        }

        [SoftUni("Ïvo")]
        public static void SomeMethod()
        {
            
        }
    }
}
