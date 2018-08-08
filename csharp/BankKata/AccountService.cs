using Microsoft.Practices.Unity;

namespace BankKata
{
    public class AccountService
    {
        [Dependency]
        public ITransactionRepository Repository { get; set; }

        private readonly IClock _clock;
        private readonly IConsole _console;
        
        public AccountService(IClock clock, IConsole console)
        {
            this._clock = clock;
            this._console = console;
        }

        public void Deposit(int amount)
        {
            Repository.AddTransaction(amount, _clock.Now());
        }

        public void Withdraw(int amount)
        {
            Repository.AddTransaction(-amount, _clock.Now());
        }

        public void PrintStatement()
        {
            var statementPrinter = new StatementPrinter(_console);
            statementPrinter.Print(Repository.GetAllTransactions());
        }
    }
}