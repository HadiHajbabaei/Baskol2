using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MyDB.BusinessLayer.Models.Mapping
{
    public class AppMap : EntityTypeConfiguration<App>
    {
        public AppMap()
        {
            // Primary Key
            this.HasKey(t => t.AppPuID);

            // Table & Column Mappings
            this.ToTable("App");
            this.Property(t => t.AppPuID).HasColumnName("AppPuID");
            this.Property(t => t.AppName).HasColumnName("AppName");
        }
    }
}
