namespace _04.Tracker
{
    [SoftUni("Ventsi")]
    public class StartUp
    {
        [SoftUni("Gosho")]
        public static void Main()
        {
            var tracker = new global::Tracker();
            tracker.PrintMethodsByAuthor();
        }

        [SoftUni("Ïvo")]
        public static void SomeMethod()
        {
            
        }
    }
}
