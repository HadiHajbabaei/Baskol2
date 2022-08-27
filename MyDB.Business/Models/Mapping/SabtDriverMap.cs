using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MyDB.BusinessLayer.Models.Mapping
{
    public class SabtDriverMap : EntityTypeConfiguration<SabtDriver>
    {
        public SabtDriverMap()
        {
            // Primary Key
            this.HasKey(t => t.DriverPuID); 

            // Table & Column Mappings
            this.ToTable("SabtDriver");
            this.Property(t => t.DriverPuID).HasColumnName("DriverPuID"); 
            this.Property(t => t.DriverName).HasColumnName("DriverName");
            this.Property(t => t.DriverCodeMeli).HasColumnName("DriverCodeMeli");
            this.Property(t => t.DriverPNumber).HasColumnName("DriverPNumber");
            this.Property(t => t.DriverDesc).HasColumnName("DriverDesc");
            this.Property(t => t.DriverAddress).HasColumnName("DriverAddress");
            this.Property(t => t.DriverCode).HasColumnName("DriverCode");
            this.Property(t => t.DriverEnable).HasColumnName("DriverEnable");
            this.Property(t => t.DriverDateTime).HasColumnName("DriverDateTime");
            this.Property(t => t.DriverPuUser).HasColumnName("DriverPuUser");
            this.Property(t => t.DriverEdDateTime).HasColumnName("DriverEdDateTime");
            this.Property(t => t.DriverEdPuUser).HasColumnName("DriverEdPuUser");
            this.Property(t => t.DriverTagNumber).HasColumnName("DriverTagNumber");
            this.Property(t => t.CarPuID).HasColumnName("CarPuID");

        }
    }
}
