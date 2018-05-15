using System;
using P01_BillsPaymentSystem.Data;
using P01_BillsPaymentSystem.Data.Models;

namespace P01_BillsPaymentSystem.App
{
    public static class Seed
    {
        public static void SeedDb(BillsPaymentSystemContext db)
        {
            var firstAcc = new BankAccount
            {
                BankName = "First Investment Bank",
                SwiftCode = "FINVBGSF",
            };

            firstAcc.Deposit(1000);

            var secondAcc = new BankAccount
            {
                BankName = "Unicredit Bulbank",
                SwiftCode = "UNCRBGSF"
            };

            secondAcc.Deposit(1000);

            var firstCreditCard = new CreditCard
            {
                Limit = 1000,
                ExpirationDate = new DateTime(2020, 01, 01)
            };

            firstCreditCard.Withdraw(200);

            var secondCreditCard = new CreditCard
            {
                Limit = 2000,
                ExpirationDate = new DateTime(2020, 01, 01)
            };

            secondCreditCard.Withdraw(500);
            
            var firstUser = new User
            {
                FirstName = "Mickey",
                LastName = "Mouse",
                Email = "mickey.mouse@disney.com",
                Password = "123456"
            };

            var secondUser = new User
            {
                FirstName = "Donald",
                LastName = "Duck",
                Email = "donald.duck@disney.com",
                Password = "123456"
            };
            
            var firstPayment = new PaymentMethod
            {
                BankAccount = firstAcc,
                User = firstUser,
                Type = PaymentType.BankAccount
            };

            var secondPayment = new PaymentMethod
            {
                BankAccount = secondAcc,
                User = firstUser,
                Type = PaymentType.BankAccount
            };

            var thirdPayment = new PaymentMethod
            {
                CreditCard = firstCreditCard,
                User = firstUser,
                Type = PaymentType.CreditCard
            };

            var fourthPayment = new PaymentMethod
            {
                CreditCard = secondCreditCard,
                User = firstUser,
                Type = PaymentType.CreditCard
            };

            db.Users.AddRange(firstUser, secondUser);
            db.CreditCards.AddRange(firstCreditCard, secondCreditCard);
            db.BankAccounts.AddRange(firstAcc, secondAcc);
            db.PaymentMethods.AddRange(firstPayment, secondPayment, thirdPayment, fourthPayment);
            db.SaveChanges();
        }
    }
}
