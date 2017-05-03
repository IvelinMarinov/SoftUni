using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace _06.Book_Library_Modification
{
    class BookLibraryModification
    {
        public static Book InitializeBook(string[] bookInfo)
        {
            var currBook = new Book()
            {
                Title = bookInfo[0],
                Author = bookInfo[1],
                Publisher = bookInfo[2],
                ReleaseDate = DateTime.ParseExact(bookInfo[3],
                "dd.MM.yyyy", CultureInfo.InvariantCulture),
                ISBN = bookInfo[4],
                Price = double.Parse(bookInfo[5])
            };

            return currBook;
        }

        public static void Main()
        {
            var numberOfBooks = int.Parse(Console.ReadLine());

            var myLibrary = new Library()
            {
                Name = "someLibrary",
                ListOfBooks = new List<Book>()
            };

            for (int i = 0; i < numberOfBooks; i++)
            {
                var currBookInfo = Console.ReadLine().Split();
                var currBook = InitializeBook(currBookInfo);
                myLibrary.ListOfBooks.Add(currBook);
            }

            var releaseDateMin = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy", CultureInfo.InvariantCulture);

            foreach (var book in myLibrary.ListOfBooks
                .Where(d => d.ReleaseDate > releaseDateMin)
                .OrderBy(x => x.ReleaseDate).ThenBy(y => y.Title))
            {
                Console.WriteLine($"{book.Title} -> {book.ReleaseDate:dd.MM.yyyy}");
            }
        }
    }
}
