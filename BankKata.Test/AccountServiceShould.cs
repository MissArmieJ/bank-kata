using NSubstitute;
using NUnit.Framework;

namespace BankKata.Test
{
    [TestFixture]
    public class AccountServiceShould
    {
        private const string DepositDate = "03/03/2017";
        private const int DepositAmount = 1000;
        private const string WithdrawDate = "03/03/2017";
        private const int WithdrawAmount = 500;

        private ITransactionRepository _repository;
        private IClock _clock;
        readonly IConsole _console = Substitute.For<IConsole>();

        [SetUp]
        public void Setup()
        {
            _repository = Substitute.For<ITransactionRepository>();
            _clock = Substitute.For<IClock>();
        }

        [Test]
        public void deposit_amount_into_account()
        {
            _clock.Now().Returns(DepositDate);

            var account = new AccountService(_repository, _clock, _console);
            account.Deposit(DepositAmount);

            _repository.Received().AddTransaction(DepositAmount, DepositDate);
        }

        [Test]
        public void withdraw_amount_from_account()
        {
            _clock.Now().Returns(WithdrawDate);

            var account = new AccountService(_repository, _clock, _console);
            account.Withdraw(WithdrawAmount);

            _repository.Received().AddTransaction(-WithdrawAmount, WithdrawDate);
        }

        [Test]
        public void print_statement_when_no_transactions()
        {
            var account = new AccountService(_repository, _clock, _console);
            account.PrintStatement();

            _console.Received().PrintLine("DATE | AMOUNT | BALANCE");
        }

        [Test]
        public void print_statement_with_transaction()
        {
            _clock.Now().Returns(DepositDate);
            var account = new AccountService(_repository, _clock, _console);
            account.Deposit(DepositAmount);

            account.PrintStatement();

            _repository.Received().GetAllTransactions();
        }
    }
}
