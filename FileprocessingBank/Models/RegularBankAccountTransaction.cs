using FileprocessingRB.Models.Contracts;

namespace FileprocessingRB.Models
{
    internal class RegularBankAccountTransaction : IBankTransaction
    {
        public string? Account { get; set; }
        public string? Amount { get; set; }
        public string? Date { get; set; }
        public string? Bank { get; set; }
    }
}
