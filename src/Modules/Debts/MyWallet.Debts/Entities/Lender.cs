namespace MyWallet.Debts.Entities;

public class Lender
{
    public int Id { get; }
    public string CompanyName { get; }

    public Lender(string companyName)
    {
        CompanyName = companyName;
    }
}