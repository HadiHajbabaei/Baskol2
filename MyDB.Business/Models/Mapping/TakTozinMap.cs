using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MyDB.BusinessLayer.Models.Mapping
{
    public class TakTozinMap : EntityTypeConfiguration<TakTozin>
    {
        public TakTozinMap()
        {
            // Primary Key
            this.HasKey(t => t.TakTozinPuID); 

            // Table & Column Mappings
            this.ToTable("TakTozin");
            this.Property(t => t.TakTozinPuID).HasColumnName("TakTozinPuID"); 
            this.Property(t => t.DriverPuID).HasColumnName("DriverPuID");
            this.Property(t => t.CustomerPuID).HasColumnName("CustomerPuID");
            this.Property(t => t.TakTozinGhabz).HasColumnName("TakTozinGhabz");
            this.Property(t => t.SabtMahsolPuID).HasColumnName("SabtMahsolPuID");
            this.Property(t => t.TakTozinTime).HasColumnName("TakTozinTime");
            this.Property(t => t.TakTozinWeighte).HasColumnName("TakTozinWeighte");
            this.Property(t => t.TakTozinDate).HasColumnName("TakTozinDate");
            this.Property(t => t.Ttype).HasColumnName("Ttype");
            this.Property(t => t.TakTozinDateTime).HasColumnName("TakTozinDateTime");
            this.Property(t => t.TakTozinPuUser).HasColumnName("TakTozinPuUser");

        }
    }
}
