namespace _01.Library
{
    public class StartUp
    {
        public static void Main()
        {
            Book bookOne = new Book("Animal Farm", 2003, "George Orwell");
            Book bookTwo = new Book("The Documents in the Case", 2002, "Dorothy Sayers", "Robert Eustace");
            Book bookThree = new Book("The Documents in the Case", 1930);

            global::Library libraryOne = new global::Library();
            global::Library libraryTwo = new global::Library(bookOne, bookTwo, bookThree);
        }
    }
}