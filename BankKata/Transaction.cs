namespace BankKata
{
    public class Transaction
    {
        public Transaction(int amount, string date)
        {
            this.Amount = amount;
            this.Date = date;
        }

        public int Amount { get; }
        public string Date { get; }
    }
}