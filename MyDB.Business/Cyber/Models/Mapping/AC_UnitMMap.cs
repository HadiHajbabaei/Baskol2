using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MyDB.BusinessLayer.Cyber.Models.Mapping
{
    public class AC_UnitMMap : EntityTypeConfiguration<AC_UnitM>
    {
        public AC_UnitMMap()
        {
            // Primary Key
            this.HasKey(t => t.UnitID);

            // Properties

            this.Property(t => t.UnitDesc)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("AC_UnitM");
            this.Property(t => t.UnitID).HasColumnName("UnitID");
            this.Property(t => t.UnitDesc).HasColumnName("UnitDesc");
        }
    }
}
