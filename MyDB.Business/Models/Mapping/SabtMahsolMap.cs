using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MyDB.BusinessLayer.Models.Mapping
{
    public class SabtMahsolMap : EntityTypeConfiguration<SabtMahsol>
    {
        public SabtMahsolMap()
        {
            // Primary Key
            this.HasKey(t => t.SabtMahsolPuID);

            this.Property(t => t.ItemCode)
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("SabtMahsol");
            this.Property(t => t.SabtMahsolPuID).HasColumnName("SabtMahsolPuID");
            this.Property(t => t.SabtMahsolName).HasColumnName("SabtMahsolName");
            this.Property(t => t.SabtMahsolVahed).HasColumnName("SabtMahsolVahed");
            this.Property(t => t.SabtMahsolCod).HasColumnName("SabtMahsolCod");
            this.Property(t => t.SabtMahsolEnable).HasColumnName("SabtMahsolEnable");
            this.Property(t => t.SabtMahsolAnbar).HasColumnName("SabtMahsolAnbar");
            this.Property(t => t.SabtMahsolPrice).HasColumnName("SabtMahsolPrice");
            this.Property(t => t.SabtMahsolDescription).HasColumnName("SabtMahsolDescription");
            this.Property(t => t.SabtMahsolPuUSER).HasColumnName("SabtMahsolPuUSER");
            this.Property(t => t.SabtMahsolEDdatetime).HasColumnName("SabtMahsolEDdatetime");
            this.Property(t => t.SabtMahsolEDPuUSER).HasColumnName("SabtMahsolEDPuUSER");
            this.Property(t => t.SabtMahsoldatetime).HasColumnName("SabtMahsoldatetime");
            this.Property(t => t.ItemCode).HasColumnName("ItemCode");

        }
    }
}
