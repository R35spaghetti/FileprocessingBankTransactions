using FileprocessingRB.Models;

namespace FileprocessingRB.DictReaders
{
    internal class ReadBankDictionary
    {

        internal Dictionary<string, List<string>> ReadBankDict(string nameOfFile, string userInputDate)
        {
            List<RegularBankAccountTransaction> transactions = ReadTransactionsFromFile(nameOfFile);
            Dictionary<string, List<string>> bankTransactions = FillBankTransactionsDictionary(transactions, userInputDate);

            return bankTransactions;
        }

        public List<RegularBankAccountTransaction> ReadTransactionsFromFile(string nameOfFile)
        {
            List<RegularBankAccountTransaction> transactions = new List<RegularBankAccountTransaction>();

            using var reader = new StreamReader(nameOfFile ?? "File doesn't exist or incorrect value");
            reader.ReadLine(); //skip header
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine() ?? throw new InvalidOperationException();
                string[] parts = line.Split(';');

                RegularBankAccountTransaction transaction = new RegularBankAccountTransaction()
                {
                    Account = parts[0],
                    Amount = parts[1],
                    Date = parts[2],
                    Bank = parts[3]
                };

                transactions.Add(transaction);
            }

            return transactions;
        }
        
        public Dictionary<string, List<string>> FillBankTransactionsDictionary(List<RegularBankAccountTransaction> transactions, string userInputDate)
        {
            Dictionary<string, List<string>> bankTransactions = new Dictionary<string, List<string>>();

            foreach (var transaction in transactions)
            {
                string typ = AgeOfDate(transaction.Date, userInputDate);
                string bankInfo = $"{transaction.Account};{transaction.Amount};{transaction.Date};{typ}";

                if (!bankTransactions.ContainsKey(transaction.Bank))
                {
                    bankTransactions.Add(transaction.Bank, new List<string> { bankInfo });
                }
                else
                {
                    bankTransactions[transaction.Bank].Add(bankInfo);
                }
            }

            return bankTransactions;
        }

        
        
        private string AgeOfDate(string date, string userInputDate)
        {
            var parsedUserInputDate = DateTime.Parse(userInputDate);
            var parsedDate = DateTime.Parse(date);

            if (parsedUserInputDate > parsedDate)
            {
                return "OLD";
            }
            else if (parsedUserInputDate < parsedDate)
            {
                return "FUTURE";
            }
            return "ACTIVE";
        }

    }
}
