namespace BusTicketsSystem.Models.Models
{
    public class BankAccount
    {
        public int Id { get; set; }

        public string AccountNumber { get; set; }

        public decimal Balance { get; set; }

        public int AccountHolderId { get; set; }

        public Customer AccountHolder { get; set; }
    }
}
