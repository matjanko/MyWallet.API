using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyWallet.Debts.Entities;

namespace MyWallet.Debts.DAL.Configurations;

internal class LoanConfiguration : IEntityTypeConfiguration<Loan>
{
    public void Configure(EntityTypeBuilder<Loan> builder)
    {
        builder.ToTable("loans");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("loan_id").ValueGeneratedOnAdd();
        builder.Property(x => x.LenderId).HasColumnName("lender_id").IsRequired();
        builder.Property(x => x.Description).HasColumnName("description").IsRequired();
        builder.Property(x => x.Principal).HasColumnName("principal").IsRequired();
        builder.Property(x => x.InterestRate).HasColumnName("interest_rate").IsRequired();
        builder.Property(x => x.LoanTermMonths).HasColumnName("loan_term_months").IsRequired();
        
        builder.Property(e => e.LoanStatus)
            .HasColumnName("loan_status")
            .HasConversion(
                e => e.ToString(), 
                e => (LoanStatus)Enum.Parse(typeof(LoanStatus), e))
            .HasDefaultValue(LoanStatus.Draft);
    }
}