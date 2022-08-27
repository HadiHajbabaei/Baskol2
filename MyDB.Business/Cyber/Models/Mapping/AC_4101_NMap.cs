using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MyDB.BusinessLayer.Cyber.Models.Mapping
{
    public class AC_4101_NMap : EntityTypeConfiguration<AC_4101_N>
    {
        public AC_4101_NMap()
        {
            // Primary Key
            this.HasKey(t => t.InvHeaderId);

            // Properties

            this.Property(t => t.InvDescription)
                .HasMaxLength(200);

            this.Property(t => t.GeneralRef)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("AC_4101_N");
            this.Property(t => t.InvHeaderId).HasColumnName("InvHeaderId");
            this.Property(t => t.InvTyp).HasColumnName("InvTyp");
            this.Property(t => t.InvNo).HasColumnName("InvNo");
            this.Property(t => t.InvDescription).HasColumnName("InvDescription");
            this.Property(t => t.InvDate).HasColumnName("InvDate");
            this.Property(t => t.GeneralRef).HasColumnName("GeneralRef");
            this.Property(t => t.RegisterRef).HasColumnName("RegisterRef");
            this.Property(t => t.CurrencyId).HasColumnName("CurrencyId");
            this.Property(t => t.AccountId).HasColumnName("AccountId");
            this.Property(t => t.JobCostingId).HasColumnName("JobCostingId");
            this.Property(t => t.DiscPer).HasColumnName("DiscPer");
            this.Property(t => t.Rate).HasColumnName("Rate");
            this.Property(t => t.UpPriceFlag).HasColumnName("UpPriceFlag");
            this.Property(t => t.firstissuerid).HasColumnName("firstissuerid");
            this.Property(t => t.lastissuerid).HasColumnName("lastissuerid");
            this.Property(t => t.printed).HasColumnName("printed");
            this.Property(t => t.PermanentNumber).HasColumnName("PermanentNumber");
            this.Property(t => t.CreateDate).HasColumnName("CreateDate");
        }
    }
}
