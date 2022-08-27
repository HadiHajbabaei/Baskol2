using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MyDB.BusinessLayer.Cyber.Models.Mapping
{
    public class AC_3001_NMap : EntityTypeConfiguration<AC_3001_N>
    {
        public AC_3001_NMap()
        {
            // Primary Key
            this.HasKey(t => t.ItemId);

            // Properties

            this.Property(t => t.ItemCode)
                .HasMaxLength(200);

            this.Property(t => t.ItemDesc)
                .HasMaxLength(300);

            // Table & Column Mappings
            this.ToTable("AC_3001_N");
            this.Property(t => t.ItemId).HasColumnName("ItemId");
            this.Property(t => t.ItemCode).HasColumnName("ItemCode");
            this.Property(t => t.ItemDesc).HasColumnName("ItemDesc");
        }
    }
}
