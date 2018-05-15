using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using BookShop.Models;
using Microsoft.EntityFrameworkCore;

namespace BookShop
{
    using BookShop.Data;
    using BookShop.Initializer;

    public class StartUp
    {
        public static void Main()
        {
            using (var db = new BookShopContext())
            {
                DbInitializer.ResetDatabase(db);

                //var command = Console.ReadLine();
                //var year = int.Parse(Console.ReadLine());
                //var categories = Console.ReadLine();
                //var releaseDate = Console.ReadLine();
                //var authorNameEnd = Console.ReadLine();
                //var titleContainingString = Console.ReadLine();
                //var input = int.Parse(Console.ReadLine());

                //Console.WriteLine(GetBooksByAgeRestriction(db, command));
                //Console.WriteLine(GetGoldenBooks(db));
                //Console.WriteLine(GetBooksByPrice(db));
                //Console.WriteLine(GetBooksNotRealeasedIn(db, year));
                //Console.WriteLine(GetBooksByCategory(db, categories));
                //Console.WriteLine(GetBooksReleasedBefore(db, releaseDate));
                //Console.WriteLine(GetAuthorNamesEndingIn(db, authorNameEnd));
                //Console.WriteLine(GetBookTitlesContaining(db, titleContainingString));
                //Console.WriteLine(GetBooksByAuthor(db, input));
                //Console.WriteLine(CountBooks(db, input));
                //Console.WriteLine(CountCopiesByAuthor(db));
                //Console.WriteLine(GetTotalProfitByCategory(db));
                //Console.WriteLine(GetMostRecentBooks(db));
                Console.WriteLine($"{RemoveBooks(db)} books were deleted");
            }
        }

        //01. Age Restriction
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var ageRestrictionAsEnum = (AgeRestriction) Enum.Parse(typeof(AgeRestriction), command, true);

            var books = context.Books
                .Where(b => b.AgeRestriction == ageRestrictionAsEnum)
                .Select(b => b.Title)
                .OrderBy(b => b)
                .ToList();

            return string.Join(Environment.NewLine, books);
        }

        //02. Golden Books
        public static string GetGoldenBooks(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.EditionType == EditionType.Gold && b.Copies < 5000)
                .Select(b => b.Title)
                .ToList();

            return string.Join(Environment.NewLine, books);
        }

        //03. Books by Price
        public static string GetBooksByPrice(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.Price > 40)
                .Select(b => new
                {
                    Title = b.Title,
                    Price = b.Price
                })
                .OrderByDescending(b => b.Price)
                .ToList();

            var sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - ${book.Price:f2}");
            }

            return sb.ToString().Trim();
        }

        //04. Not Released In
        public static string GetBooksNotRealeasedIn(BookShopContext context, int year)
        {
            var books = context.Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToList();

            return string.Join(Environment.NewLine, books);
        }

        //05. Book Titles by Category
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var categories = input.ToLower().Split(new[] { "\t", Environment.NewLine, " " }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            var books = context.Books
                .Where(b => b.BookCategories.Any(bc => categories.Contains(bc.Category.Name.ToLower())))
                .OrderBy(b => b.Title)
                .Select((book => book.Title))
                .ToList();

            var result = string.Join(Environment.NewLine, books);

            return result;
        }

        //06. Released Before Date
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            var releaseDate = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var books = context.Books
                .Where(b => b.ReleaseDate < releaseDate)
                .OrderByDescending(b => b.ReleaseDate)
                .Select(b => $"{b.Title} - {b.EditionType} - ${b.Price:f2}")
                .ToList();

            return string.Join(Environment.NewLine, books);
        }

        //07. Author Search
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authors = context.Authors
                .Where(a => a.FirstName.ToLower().EndsWith(input.ToLower()))
                .Select(a => a.FirstName + " " + a.LastName)
                .OrderBy(x => x)
                .ToList();

            return string.Join(Environment.NewLine, authors);
        }

        //08. Book Search
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var books = context.Books
                .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToList();

            return String.Join(Environment.NewLine, books);
        }

        //09. Book Search by Author
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var books = context.Books
                .Include(b => b.Author)
                .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .OrderBy(b => b.BookId)
                .Select(b => $"{b.Title} ({b.Author.FirstName} {b.Author.LastName})")
                .ToList();

            return string.Join(Environment.NewLine, books);
        }

        //10. Count Books
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var books = context.Books
                .Where(b => b.Title.Length > lengthCheck)
                .ToList();

            return books.Count;
        }

        //11. Total Book Copies
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var result = new StringBuilder();

            context.Authors
                .Select(a => new
                {
                    Name = $"{a.FirstName} {a.LastName}",
                    Copies = a.Books.Select(b => b.Copies).Sum()
                })
                .OrderByDescending(a => a.Copies)
                .ToList()
                .ForEach(x => result.AppendLine($"{x.Name} - {x.Copies}"));

            return result.ToString().Trim();
        }

        //12. Profit by Category
        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var sb = new StringBuilder();

            var result = new Dictionary<string, decimal>();

            var categoriesBooks = context.Categories
                .Select(c => new
                {
                    Name = c.Name,
                    Books = c.CategoryBooks.Select(cb => cb.Book).ToList()
                })
                .ToList();

            foreach (var cb in categoriesBooks)
            {
                result.Add(cb.Name, 0);

                foreach (var book in cb.Books)
                {
                    result[cb.Name] += book.Copies * book.Price;
                }
            }

            foreach (var kvp in result.OrderByDescending(x => x.Value))
            {
                sb.AppendLine($"{kvp.Key} ${kvp.Value:f2}");
            }

            return sb.ToString();
        }

        //13. Most Recent Books
        public static string GetMostRecentBooks(BookShopContext context)
        {
            var result = new StringBuilder();

            var categoryBooks = context.Categories
                .Select(c => new
                {
                    Name = c.Name,
                    Books = c.CategoryBooks
                        .OrderByDescending(cb => cb.Book.ReleaseDate)
                        .Take(3)
                        .Select(cb => $"{cb.Book.Title} ({cb.Book.ReleaseDate.Value.Year})")
                });

            foreach (var cb in categoryBooks.OrderBy(cb => cb.Name))
            {
                result.AppendLine($"--{cb.Name}");

                foreach (var bookInfo in cb.Books)
                {
                    result.AppendLine(bookInfo);
                }
            }

            return result.ToString().Trim();
        }

        //14. Increase Prices
        public static void IncreasePrices(BookShopContext context)
        {
            var booksToIncreasePrice = context.Books
                .Where(b => b.ReleaseDate.Value.Year < 2010)
                .ToList();

            foreach (var book in booksToIncreasePrice)
            {
                book.Price += 5;
            }

            context.SaveChanges();
        }

        //15. Remove Books
        public static int RemoveBooks(BookShopContext context)
        {
            var booksToDelete = context.Books
                .Include(b => b.BookCategories)
                .Where(b => b.Copies < 4200);

            foreach (var book in booksToDelete)
            {
                book.BookCategories.Clear();
            }

            var booksCount = booksToDelete.Count();
            context.Books.RemoveRange(booksToDelete);
            context.SaveChanges();

            return booksCount;
        }
    }
}

