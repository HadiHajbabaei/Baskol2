using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MyDB.BusinessLayer.Models.Mapping
{
    public class View_SabtMahsolMap : EntityTypeConfiguration<View_SabtMahsol>
    {
        public View_SabtMahsolMap()
        {
            // Primary Key
            this.HasKey(t => new { t.SabtMahsolPuID, t.VahedPuID });

            // Table & Column Mappings Activate
            this.ToTable("View_SabtMahsol");
            this.Property(t => t.SabtMahsolPuID).HasColumnName("SabtMahsolPuID");
            this.Property(t => t.SabtMahsolName).HasColumnName("SabtMahsolName");
            this.Property(t => t.SabtMahsolCod).HasColumnName("SabtMahsolCod");
            this.Property(t => t.SabtMahsolDescription).HasColumnName("SabtMahsolDescription");
            this.Property(t => t.SabtMahsolPuUSER).HasColumnName("SabtMahsolPuUSER");
            this.Property(t => t.SabtMahsolEDdatetime).HasColumnName("SabtMahsolEDdatetime");
            this.Property(t => t.SabtMahsolEDPuUSER).HasColumnName("SabtMahsolEDPuUSER");
            this.Property(t => t.SabtMahsoldatetime).HasColumnName("SabtMahsoldatetime");
            this.Property(t => t.SabtMahsolAnbar).HasColumnName("SabtMahsolAnbar");
            this.Property(t => t.VahedPuID).HasColumnName("VahedPuID");
            this.Property(t => t.VahedName).HasColumnName("VahedName");
        }
    }
}
