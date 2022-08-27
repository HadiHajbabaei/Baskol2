using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MyDB.BusinessLayer.Models.Mapping
{
    public class VahedMap : EntityTypeConfiguration<Vahed>
    {
        public VahedMap()
        {
            // Primary Key
            this.HasKey(t => t.VahedPuID);

            // Table & Column Mappings
            this.ToTable("Vahed");
            this.Property(t => t.VahedPuID).HasColumnName("VahedPuID");
            this.Property(t => t.VahedName).HasColumnName("VahedName");
        }
    }
}
