using NSubstitute;
using NUnit.Framework;

namespace BankKata.Test
{
    [TestFixture]
    public class PrintStatementFeature
    {
        [Test]
        public void print_statement_with_transactions_in_reverse_order()
        {
            var console = Substitute.For<IConsole>();
            var clock = Substitute.For<IClock>();
            clock.Now().Returns(x => "01/04/2014", x => "02/04/2014", x => "10/04/2014");

            var account = new AccountService(clock, console) {Repository = new TransactionRepository()};

            account.Deposit(1000);
            account.Withdraw(100);
            account.Deposit(500);

            account.PrintStatement();

            Received.InOrder(() =>
            {
                console.PrintLine("DATE | AMOUNT | BALANCE");
                console.PrintLine("10/04/2014 | 500.00 | 1400.00");
                console.PrintLine("02/04/2014 | -100.00 | 900.00");
                console.PrintLine("01/04/2014 | 1000.00 | 1000.00");
            });
        }
    }
}
