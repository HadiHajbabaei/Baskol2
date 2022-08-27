using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MyDB.BusinessLayer.Cyber.Models.Mapping
{
    public class AC_3601_NMap : EntityTypeConfiguration<AC_3601_N>
    {
        public AC_3601_NMap()
        {
            // Primary Key
            this.HasKey(t => t.STID);

            // Properties

            this.Property(t => t.STNumber)
                .HasMaxLength(50);

            this.Property(t => t.StDesc)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("AC_3601_N");
            this.Property(t => t.STID).HasColumnName("STID");
            this.Property(t => t.STNumber).HasColumnName("STNumber");
            this.Property(t => t.StDesc).HasColumnName("StDesc");
        }
    }
}
