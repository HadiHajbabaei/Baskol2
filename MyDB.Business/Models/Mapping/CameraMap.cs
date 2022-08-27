using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MyDB.BusinessLayer.Models.Mapping
{
    public class CameraMap : EntityTypeConfiguration<Camera>
    {
        public CameraMap()
        {
            // Primary Key
            this.HasKey(t => t.CameraPuID); 

            // Table & Column Mappings
            this.ToTable("Camera");
            this.Property(t => t.CameraPuID).HasColumnName("CameraPuID"); 
            this.Property(t => t.CameraURL).HasColumnName("CameraURL");
            this.Property(t => t.CameraSelectedPath).HasColumnName("CameraSelectedPath");
        }
    }
}
