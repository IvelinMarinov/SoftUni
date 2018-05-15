using System;
using System.Globalization;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using P01_BillsPaymentSystem.Data;
using P01_BillsPaymentSystem.Data.Models;

namespace P01_BillsPaymentSystem.App
{
    class StartUp
    {
        public static void Main()
        {
            using (var db = new BillsPaymentSystemContext())
            {
                db.Database.EnsureDeleted();
                db.Database.Migrate();

                Seed.SeedDb(db);
            }

            Console.WriteLine("Enter INFO [UserId] to get details for a user, PAYBILL [UserId] [Amount] to pay bill or END to exit");
            Console.Write("Please enter your command: ");
            string[] command = Console.ReadLine().Split();

            while (command[0].ToLower() != "end")
            {
                try
                {
                    switch (command[0].ToLower())
                    {
                        case "info":
                            GetInfoForUser(command[1]);
                            break;
                        case "paybill":
                            PayBill(command[1], command[2]);
                            break;
                        default:
                            throw new InvalidOperationException("Invalid command");
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                Console.Write("Please enter your command: ");
                command = Console.ReadLine().Split();
            }
        }

        private static void PayBill(string id, string amount)
        {
            int userId = 0;
            bool isInt = int.TryParse(id, out userId);

            if (!isInt)
            {
                throw new InvalidOperationException("User ID entered is invalid");
            }

            decimal billAmount = 0m;
            bool isAmountValid = decimal.TryParse(amount, out billAmount);

            if (!isAmountValid)
            {
                throw new InvalidOperationException("Invalid bill amount provided");
            }

            if (billAmount < 0)
            {
                throw new InvalidOperationException("Bill amount cannot be negative");
            }

            using (var db = new BillsPaymentSystemContext())
            {
                var user = db.Users
                    .Where(u => u.UserId == userId)
                    .Include(u => u.PaymentMethods)
                    .ThenInclude(pm => pm.CreditCard)
                    .Include(u => u.PaymentMethods)
                    .ThenInclude(pm => pm.BankAccount)
                    .FirstOrDefault();

                if (user == null)
                {
                    throw new InvalidOperationException($"User with ID { userId } not found!");
                }

                var bankAccFunds = user.PaymentMethods
                    .Where(pm => pm.Type == PaymentType.BankAccount)
                    .Sum(pm => pm.BankAccount.Balance);
                var creditCardFunds = user.PaymentMethods
                    .Where(pm => pm.Type == PaymentType.CreditCard)
                    .Sum(pm => pm.CreditCard.LimitLeft);
                var totalFundsAvailable = bankAccFunds + creditCardFunds;

                if (totalFundsAvailable < billAmount)
                {
                    throw new InvalidOperationException("Insufficient funds");
                }

                var bankAccounts = user.PaymentMethods
                    .Where(pm => pm.Type == PaymentType.BankAccount)
                    .OrderBy(pm => pm.BankAccountId)
                    .Select(pm => pm.BankAccount)
                    .ToList();

                foreach (var ba in bankAccounts)
                {
                    if (ba.Balance >= billAmount)
                    {
                        ba.Withdraw(billAmount);
                        billAmount = 0;
                        break;;
                    }
                    else
                    {
                        billAmount -= ba.Balance;
                        ba.Withdraw(ba.Balance);
                    }
                }

                if (billAmount > 0)
                {
                    var creditCards = user.PaymentMethods
                        .Where(pm => pm.Type == PaymentType.CreditCard)
                        .OrderBy(pm => pm.CreditCardId)
                        .Select(pm => pm.CreditCard)
                        .ToList();

                    foreach (var cc in creditCards)
                    {
                        if (cc.LimitLeft >= billAmount)
                        {
                            cc.Withdraw(billAmount);
                            billAmount = 0;
                            break; ;
                        }
                        else
                        {
                            billAmount -= cc.LimitLeft;
                            cc.Withdraw(cc.LimitLeft);
                        }
                    }
                }

                db.SaveChanges();
                Console.WriteLine("Bill successfully paid");

                //TODO - actual payment
            }
        }

        public static void GetInfoForUser(string id)
        {
            int userId = 0;
            bool isInt = isInt = int.TryParse(id, out userId);

            if (!isInt)
            {
                throw new InvalidOperationException("User ID entered is invalid");
            }

            using (var db = new BillsPaymentSystemContext())
            {
                var user = db.Users
                    .Where(u => u.UserId == userId)
                    .Include(u => u.PaymentMethods)
                    .ThenInclude(pm => pm.CreditCard)
                    .Include(u => u.PaymentMethods)
                    .ThenInclude(pm => pm.BankAccount)
                    .FirstOrDefault();

                if (user == null)
                {
                    throw new InvalidOperationException($"User with ID {userId} not found!");
                }

                var sb = new StringBuilder();
                sb.AppendLine($"User: {user.FirstName} {user.LastName}");
                sb.AppendLine($"Bank Accounts:");

                foreach (var pm in user.PaymentMethods.Where(x => x.Type == PaymentType.BankAccount))
                {
                    sb.AppendLine($"-- ID: {pm.BankAccountId}");
                    sb.AppendLine($"--- Balance: {pm.BankAccount.Balance:f2}");
                    sb.AppendLine($"--- {pm.BankAccount.BankName}");
                    sb.AppendLine($"--- SWIFT: {pm.BankAccount.SwiftCode}");
                }

                foreach (var pm in user.PaymentMethods.Where(x => x.Type == PaymentType.CreditCard))
                {
                    sb.AppendLine($"-- ID: {pm.CreditCard.CreditCardId}");
                    sb.AppendLine($"--- Limit: {pm.CreditCard.Limit:f2}");
                    sb.AppendLine($"--- Money Owed: {pm.CreditCard.MoneyOwed:f2}");
                    sb.AppendLine($"--- Limit Left:: {pm.CreditCard.LimitLeft}");
                    sb.AppendLine($"--- Expiration Date: {pm.CreditCard.ExpirationDate.ToString("yyyy/MM", CultureInfo.InvariantCulture)}");
                }

                Console.WriteLine(sb.ToString().Trim());
            }
        }
    }
}
