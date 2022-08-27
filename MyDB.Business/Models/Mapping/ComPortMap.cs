using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MyDB.BusinessLayer.Models.Mapping
{
    public class PortMap : EntityTypeConfiguration<Port>
    {
        public PortMap()
        {
            // Primary Key
            this.HasKey(t => t.PortPuID); 

            // Table & Column Mappings
            this.ToTable("Port");
            this.Property(t => t.PortPuID).HasColumnName("PortPuID"); 
            this.Property(t => t.DeviceName).HasColumnName("DeviceName");
            this.Property(t => t.DeviceLocation).HasColumnName("DeviceLocation");
            this.Property(t => t.PortNumber).HasColumnName("PortNumber");
            this.Property(t => t.PortBaudrate).HasColumnName("PortBaudrate");
            this.Property(t => t.PortStopbit).HasColumnName("PortStopbit");
            this.Property(t => t.PortDatabit).HasColumnName("PortDatabit");
            this.Property(t => t.PortFlowcontrol).HasColumnName("PortFlowcontrol");

        }
    }
}
