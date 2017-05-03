using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Book_Library
{
    public class BookLibrary
    {
        public static Book InitializeBook(string[] bookInfo)
        {
            var currBook = new Book()
            {
                Title = bookInfo[0],
                Author = bookInfo[1],
                Publisher = bookInfo[2],
                ReleaseDate = bookInfo[3],
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

            var filteredBooks = myLibrary.ListOfBooks.
                Select(b => new
                {
                    Author = b.Author,
                    EarningsTotal = myLibrary.ListOfBooks
                        .Where(b1 => b1.Author.Equals(b.Author))
                        .Sum(b1 => b1.Price)
                })
                .Distinct()
                .OrderByDescending(b => b.EarningsTotal)
                .ThenBy(b => b.Author)
                .ToList();
            foreach (var book in filteredBooks)
            {
                Console.WriteLine("{0:f2} -> {1:f2}", book.Author, book.EarningsTotal);
            }

        }
    }
}
