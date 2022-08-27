using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MyDB.BusinessLayer.Models.Mapping
{
    public class CompanyMap : EntityTypeConfiguration<Company>
    {
        public CompanyMap()
        {
            // Primary Key
            this.HasKey(t => t.CompanyPuID);

            // Properties
            this.Property(t => t.CompanyName)
                .HasMaxLength(200);

            this.Property(t => t.CompanyEghtesadi)
                .HasMaxLength(12);

            this.Property(t => t.CompanyMeli)
                .HasMaxLength(11);

            this.Property(t => t.CompanyFax)
                .HasMaxLength(11);

            this.Property(t => t.CompanyCodePosti)
                .HasMaxLength(10);

            this.Property(t => t.CompanyActivity)
                .HasMaxLength(200);

            this.Property(t => t.CompanyTel1)
                .HasMaxLength(11);

            this.Property(t => t.CompanyTel2)
                .HasMaxLength(11);

            this.Property(t => t.CompanyFax)
                .HasMaxLength(11);

            this.Property(t => t.CompanyTel3)
                .HasMaxLength(11);

            // Table & Column Mappings
            this.ToTable("Company");
            this.Property(t => t.CompanyPuID).HasColumnName("CompanyPuID");
            this.Property(t => t.CompanyName).HasColumnName("CompanyName");
            this.Property(t => t.CompanyEghtesadi).HasColumnName("CompanyEghtesadi");
            this.Property(t => t.CompanyMeli).HasColumnName("CompanyMeli");
            this.Property(t => t.CompanySabt).HasColumnName("CompanySabt");
            this.Property(t => t.CompanyFax).HasColumnName("CompanyFax");
            this.Property(t => t.CompanyCodePosti).HasColumnName("CompanyCodePosti");
            this.Property(t => t.CompanyActivity).HasColumnName("CompanyActivity");
            this.Property(t => t.CompanyTel1).HasColumnName("CompanyTel1");
            this.Property(t => t.CompanyTel2).HasColumnName("CompanyTel2");
            this.Property(t => t.CompanyTel3).HasColumnName("CompanyTel3");
            this.Property(t => t.CompanyAdress).HasColumnName("CompanyAdress");
            this.Property(t => t.CompanyLogo).HasColumnName("CompanyLogo");
            this.Property(t => t.CompanyDatetime).HasColumnName("CompanyDatetime");
            this.Property(t => t.CompanyPuUser).HasColumnName("CompanyPuUser");
            this.Property(t => t.CompanyEdDatetime).HasColumnName("CompanyEdDatetime");
            this.Property(t => t.CompanyEdPuUser).HasColumnName("CompanyEdPuUser");
        }
    }
}
