using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;

namespace BankKata.Test
{
    [TestFixture]
    public class StatementPrinterShould
    {
        private IConsole _console;
        private StatementPrinter _statementPrinter;

        [SetUp]
        public void Setup()
        {
            _console = Substitute.For<IConsole>();
            _statementPrinter = new StatementPrinter(_console);
        }

        [Test]
        public void always_print_header()
        {
            _statementPrinter.Print(new List<Transaction>());

            _console.Received().PrintLine("DATE | AMOUNT | BALANCE");
        }

        [Test]
        public void print_transactions_in_reverse_order()
        {
            var transactions = new List<Transaction>()
            {
                new Transaction(amount: 1000, date: "01/03/2017"),
                new Transaction(amount: -100, date: "02/03/2017"),
                new Transaction(amount: 500, date: "03/03/2017"),
            };

            _statementPrinter.Print(transactions);

            Received.InOrder(() =>
            {
                _console.PrintLine("DATE | AMOUNT | BALANCE");
                _console.PrintLine("03/03/2017 | 500.00 | 1400.00");
                _console.PrintLine("02/03/2017 | -100.00 | 900.00");
                _console.PrintLine("01/03/2017 | 1000.00 | 1000.00");
            });
        }
    }
}
