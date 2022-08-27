using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MyDB.BusinessLayer.Cyber.Models.Mapping
{
    public class AC_0101_NMap : EntityTypeConfiguration<AC_0101_N>
    {
        public AC_0101_NMap()
        {
            // Primary Key
            this.HasKey(t => t.AccountId);

            // Properties

            this.Property(t => t.AccountNumber)
                .HasMaxLength(50);

            this.Property(t => t.SubscribtionCode)
                .HasMaxLength(50);

            this.Property(t => t.AccountName)
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("AC_0101_N");
            this.Property(t => t.AccountId).HasColumnName("AccountId");
            this.Property(t => t.AccountNumber).HasColumnName("AccountNumber");
            this.Property(t => t.SubscribtionCode).HasColumnName("SubscribtionCode");
            this.Property(t => t.MoinId).HasColumnName("MoinId");
            this.Property(t => t.AccountTypeId).HasColumnName("AccountTypeId");
            this.Property(t => t.Deptartment).HasColumnName("Deptartment");
            this.Property(t => t.CostCenter).HasColumnName("CostCenter");
            this.Property(t => t.JobCosting).HasColumnName("JobCosting");
            this.Property(t => t.CurrencyDefault).HasColumnName("CurrencyDefault");
            this.Property(t => t.Hgcode).HasColumnName("Hgcode");
            this.Property(t => t.CInactive).HasColumnName("CInactive");
            this.Property(t => t.AccountName).HasColumnName("AccountName");
            this.Property(t => t.CInactive).HasColumnName("CInactive");
            this.Property(t => t.JobGroupId).HasColumnName("JobGroupId");
        }
    }
}
