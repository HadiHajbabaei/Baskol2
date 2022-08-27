using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MyDB.BusinessLayer.Models.Mapping
{
    public class Tozin2Map : EntityTypeConfiguration<Tozin2>
    {
        public Tozin2Map()
        {
            // Primary Key
            this.HasKey(t => t.Tozin2PuID);

            // Table & Column Mappings
            this.ToTable("Tozin2");
            this.Property(t => t.Tozin1PuID).HasColumnName("Tozin1PuID");
            this.Property(t => t.Tozin2PuID).HasColumnName("Tozin2PuID");
            this.Property(t => t.Ttype).HasColumnName("Ttype");
            this.Property(t => t.Tozin2Time).HasColumnName("Tozin2Time");
            this.Property(t => t.Tozin2Ghabz).HasColumnName("Tozin2Ghabz");
            this.Property(t => t.Tozin2Weighte).HasColumnName("Tozin2Weighte");
            this.Property(t => t.Tozin2Date).HasColumnName("Tozin2Date");
            this.Property(t => t.Tozin2DateTime).HasColumnName("Tozin2DateTime");
            this.Property(t => t.Tozin2PuUser).HasColumnName("Tozin2PuUser");
        }
    }
}
