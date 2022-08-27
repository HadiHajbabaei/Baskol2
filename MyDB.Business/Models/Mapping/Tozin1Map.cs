using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MyDB.BusinessLayer.Models.Mapping
{
    public class Tozin1Map : EntityTypeConfiguration<Tozin1>
    {
        public Tozin1Map()
        {
            // Primary Key
            this.HasKey(t => t.Tozin1PuID); 

            // Table & Column Mappings
            this.ToTable("Tozin1");
            this.Property(t => t.Tozin1PuID).HasColumnName("Tozin1PuID"); 
            this.Property(t => t.DriverPuID).HasColumnName("DriverPuID");
            this.Property(t => t.CustomerPuID).HasColumnName("CustomerPuID");
            this.Property(t => t.SabtMahsolPuID).HasColumnName("SabtMahsolPuID");
            this.Property(t => t.Tozin1Time).HasColumnName("Tozin1Time");
            this.Property(t => t.Tozin1Weighte).HasColumnName("Tozin1Weighte");
            this.Property(t => t.Tozin1Date).HasColumnName("Tozin1Date");
            this.Property(t => t.Ttype).HasColumnName("Ttype");
            this.Property(t => t.Tozin1DateTime).HasColumnName("Tozin1DateTime");
            this.Property(t => t.Tozin1PuUser).HasColumnName("Tozin1PuUser");

        }
    }
}
