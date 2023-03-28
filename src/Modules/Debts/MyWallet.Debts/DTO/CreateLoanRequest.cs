namespace MyWallet.Debts.DTO;

public record CreateLoanRequest(
    int LenderId, 
    string Description, 
    decimal Principal,
    decimal InterestRate, 
    int LoanTermMonths
);