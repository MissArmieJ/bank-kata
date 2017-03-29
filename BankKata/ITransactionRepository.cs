using System.Collections.Generic;

namespace BankKata
{
    public interface ITransactionRepository
    {
        void AddTransaction(int amount, string date);
        List<Transaction> GetAllTransactions();
    }
}