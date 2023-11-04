namespace FileprocessingRB.Models.Contracts
{
    internal interface IBankTransaction
    {
        string? Account { get; set; }
        string? Amount { get; set; }
        string? Date { get; set; }
        string? Bank { get; set; }
    }
}
