using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileprocessingRB.DictPrinters
{
    internal class PrintBankDictionary
    {
        internal void PrintBankDictToFolder(Dictionary<string, List<string>> bankInfoDict, string chosenOutputPath)
        {
            string outputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, chosenOutputPath);
            
            outputPath = outputPath.TrimEnd('/') + "/";
            foreach (var value in bankInfoDict)
            {

                string bank = value.Key;
                List<string> bankTransaction = value.Value;
                bankTransaction.Insert(0, "Konto;Belopp;Datum;Typ");
                using StreamWriter sw = new StreamWriter(outputPath + $"{bank}.txt");
                sw.Write(string.Join(Environment.NewLine, bankTransaction));
            }


        }
    }
}
