using System;

namespace P01_BillsPaymentSystem.Data.Models
{
    public class CreditCard
    {
        public int CreditCardId { get; set; }

        public DateTime ExpirationDate { get; set; }

        public decimal Limit { get; set; }

        public decimal MoneyOwed { get; private set; }

        public decimal LimitLeft => this.Limit - this.MoneyOwed;

        public PaymentMethod PaymentMethod { get; set; }

        public void Deposit(decimal amount)
        {
            if (amount < 0)
            {
                throw new InvalidOperationException("Invalid amount entered");
            }

            this.MoneyOwed -= amount;
        }

        public void Withdraw(decimal amount)
        {
            if (amount < 0)
            {
                throw new InvalidOperationException("Invalid amount entered");
            }

            if (amount > this.LimitLeft)
            {
                throw new InvalidOperationException("Insufficient funds");
            }

            this.MoneyOwed += amount;

        }
    }
}
