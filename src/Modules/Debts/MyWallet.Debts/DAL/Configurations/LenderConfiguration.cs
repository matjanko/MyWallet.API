using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyWallet.Debts.Entities;

namespace MyWallet.Debts.DAL.Configurations;

public class LenderConfiguration : IEntityTypeConfiguration<Lender>
{
    public void Configure(EntityTypeBuilder<Lender> builder)
    {
        builder.ToTable("lenders");
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id).HasColumnName("lender_id").ValueGeneratedOnAdd();
        builder.Property(e => e.CompanyName).HasColumnName("company_name").HasMaxLength(100).IsRequired();
    }
}