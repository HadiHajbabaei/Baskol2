using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MyDB.BusinessLayer.Models.Mapping
{
    public class AccountMap : EntityTypeConfiguration<Account>
    {
        public AccountMap()
        {
            // Primary Key
            this.HasKey(t => t.AccountPuID);

            // Properties 

            this.Property(t => t.AccountName)
                .HasMaxLength(150);

            this.Property(t => t.AccountFamily)
                .HasMaxLength(150);

            this.Property(t => t.AccountCodeMeli)
                .HasMaxLength(27);

            this.Property(t => t.AccountTel)
                .HasMaxLength(27);

            this.Property(t => t.AccountMobile)
                .HasMaxLength(27);

            // Table & Column Mappings
            this.ToTable("Account");
            this.Property(t => t.AccountPuID).HasColumnName("AccountPuID"); 
            this.Property(t => t.AccountUser).HasColumnName("AccountUser");
            this.Property(t => t.AccountPassword).HasColumnName("AccountPassword");
            this.Property(t => t.AccountName).HasColumnName("AccountName");
            this.Property(t => t.AccountFamily).HasColumnName("AccountFamily");
            this.Property(t => t.AccountGender).HasColumnName("AccountGender");
            this.Property(t => t.AccountCodeMeli).HasColumnName("AccountCodeMeli");
            this.Property(t => t.AccountImg).HasColumnName("AccountImg"); 
            this.Property(t => t.AccountTel).HasColumnName("AccountTel");
            this.Property(t => t.AccountMobile).HasColumnName("AccountMobile");
            this.Property(t => t.AccountAddress).HasColumnName("AccountAddress");
            this.Property(t => t.AccountEnable).HasColumnName("AccountEnable");
            this.Property(t => t.AccountDescription).HasColumnName("AccountDescription");
            this.Property(t => t.AccountDateTime).HasColumnName("AccountDateTime");
            this.Property(t => t.AccountPuUser).HasColumnName("AccountPuUser");
            this.Property(t => t.AccountEdDateTime).HasColumnName("AccountEdDateTime");
            this.Property(t => t.AccountEdPuUser).HasColumnName("AccountEdPuUser");
        }
    }
}
