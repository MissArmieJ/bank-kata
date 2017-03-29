namespace BankKata
{
    public class AccountService
    {
        private readonly ITransactionRepository _repository;
        private readonly IClock _clock;
        private readonly IConsole _console;
        
        public AccountService(IClock clock, IConsole console)
        {
            this._repository = new TransactionRepository();
            this._clock = clock;
            this._console = console;
        }

        public AccountService(ITransactionRepository repository, IClock clock, IConsole console)
        {
            this._repository = repository;
            this._clock = clock;
            this._console = console;
        }

        public void Deposit(int amount)
        {
            _repository.AddTransaction(amount, _clock.Now());
        }

        public void Withdraw(int amount)
        {
            _repository.AddTransaction(-amount, _clock.Now());
        }

        public void PrintStatement()
        {
            var statementPrinter = new StatementPrinter(_console);
            statementPrinter.Print(_repository.GetAllTransactions());
        }
    }
}