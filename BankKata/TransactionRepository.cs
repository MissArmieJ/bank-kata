using System.Collections.Generic;

namespace BankKata
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly List<Transaction> _transactions;

        public TransactionRepository()
        {
            _transactions = new List<Transaction>();
        }

        public void AddTransaction(int amount, string date)
        {
            _transactions.Add(new Transaction(amount,date));
        }

        public List<Transaction> GetAllTransactions()
        {
            return _transactions;
        }
    }
}