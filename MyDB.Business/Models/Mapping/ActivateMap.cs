using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MyDB.BusinessLayer.Models.Mapping
{
    public class ActivateMap : EntityTypeConfiguration<Activate>
    {
        public ActivateMap()
        {
            // Primary Key
            this.HasKey(t => t.ActivatePuID);

            // Table & Column Mappings
            this.ToTable("Activate");
            this.Property(t => t.ActivatePuID).HasColumnName("ActivatePuID");
            this.Property(t => t.ActiveCrack).HasColumnName("ActiveCrack");
            this.Property(t => t.ActiveCPU).HasColumnName("ActiveCPU");
            this.Property(t => t.ActiveDateTime).HasColumnName("ActiveDateTime");
        }
    }
}
