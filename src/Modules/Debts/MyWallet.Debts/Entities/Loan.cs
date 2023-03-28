namespace MyWallet.Debts.Entities;

internal class Loan
{
    public int Id { get; }
    public int LenderId { get; set; }
    public string Description { get; set; }
    public decimal Principal { get; set; }
    public decimal InterestRate { get; set; }
    public int LoanTermMonths { get; set; }
    public LoanStatus LoanStatus { get; set; }
    
    public Lender Lender { get; set; }
    
}