using FileprocessingRB.DictPrinters;
using FileprocessingRB.DictReaders;
using FileprocessingRB.UserInputs;

UserInputFileReader userInputFileReader = new UserInputFileReader();

Console.WriteLine("Enter a file to read");
string fileNameInput = userInputFileReader.GetFilePathInput();

Console.WriteLine("Enter output folder path");
string fileNameOutput = userInputFileReader.GetFilePathOutput();

Console.WriteLine("Enter reference date in ISO format");
string referenceDate = userInputFileReader.GetDateReference();

ReadBankDictionary nReadBankDictionary = new ReadBankDictionary();
var bankTransactions = nReadBankDictionary.ReadBankDict(fileNameInput, referenceDate);

PrintBankDictionary nPrintBankDictionary = new PrintBankDictionary();
nPrintBankDictionary.PrintBankDictToFolder(bankTransactions, fileNameOutput);
