using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MyDB.BusinessLayer.Models.Mapping
{
    public class CrackMap : EntityTypeConfiguration<Crack>
    {
        public CrackMap()
        {
            // Primary Key
            this.HasKey(t => t.CrackPuID);

            // Table & Column Mappings
            this.ToTable("Crack");
            this.Property(t => t.CrackPuID).HasColumnName("CrackPuID");
            this.Property(t => t.CrackUserNumber).HasColumnName("CrackUserNumber");
            this.Property(t => t.CrackCompanyName).HasColumnName("CrackCompanyName");
            this.Property(t => t.CrackPuApp).HasColumnName("CrackPuApp");
            this.Property(t => t.CrackCode).HasColumnName("CrackCode");
        }
    }
}
