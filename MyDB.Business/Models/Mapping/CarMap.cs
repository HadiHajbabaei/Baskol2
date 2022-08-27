using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MyDB.BusinessLayer.Models.Mapping
{
    public class CarMap : EntityTypeConfiguration<Car>
    {
        public CarMap()
        {
            // Primary Key
            this.HasKey(t => t.CarPuID); 

            // Table & Column Mappings
            this.ToTable("Car");
            this.Property(t => t.CarPuID).HasColumnName("CarPuID"); 
            this.Property(t => t.CarName).HasColumnName("CarName");
            this.Property(t => t.CarDescription).HasColumnName("CarDescription");
            this.Property(t => t.CarEnable).HasColumnName("CarEnable");
            this.Property(t => t.CarDateTime).HasColumnName("CarDateTime");
            this.Property(t => t.CarPuUser).HasColumnName("CarPuUser");
            this.Property(t => t.CarEdDateTime).HasColumnName("CarEdDateTime");
            this.Property(t => t.CarEdPuUser).HasColumnName("CarEdPuUser");

        }
    }
}
