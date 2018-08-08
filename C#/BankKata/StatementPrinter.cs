using System.Collections.Generic;
using System.Linq;

namespace BankKata
{
    public class StatementPrinter
    {
        private readonly IConsole _console;

        public StatementPrinter(IConsole console)
        {
            this._console = console;
        }

        public void Print(List<Transaction> transactions)
        {
            _console.PrintLine("DATE | AMOUNT | BALANCE");
            PrintStatementLines(transactions);
        }

        private void PrintStatementLines(IEnumerable<Transaction> transactions)
        {
            if(transactions == null) { return;}

            var sum = 0;

            var statementLines = transactions
                .OrderBy(t => t.Date)
                .Select(t => StatementLine(t, sum += t.Amount));

            foreach (var statementLine in statementLines.Reverse())
            {
                _console.PrintLine(statementLine);
            }
        }

        private string StatementLine(Transaction transaction, int runningBalance)
        {
            return transaction.Date
                   + " | "
                   + $"{transaction.Amount}.00" 
                   + " | "
                   + $"{runningBalance}.00";
        }
    }
}