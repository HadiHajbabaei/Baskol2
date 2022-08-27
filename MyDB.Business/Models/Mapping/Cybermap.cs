using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MyDB.BusinessLayer.Models.Mapping
{
    public class CyberMap : EntityTypeConfiguration<Cyber>
    {
        public CyberMap()
        {
            // Primary Key
            this.HasKey(t => t.CyberPuID);



            // Table & Column Mappings
            this.ToTable("Cyber");
            this.Property(t => t.CyberPuID).HasColumnName("CyberPuID");
            this.Property(t => t.CyberSelect).HasColumnName("CyberSelect");
            this.Property(t => t.CyberSelect).HasColumnName("CyberSelect");
            this.Property(t => t.CyberServer).HasColumnName("CyberServer");
            this.Property(t => t.CyberUsername).HasColumnName("CyberUsername");
            this.Property(t => t.CyberPassword).HasColumnName("CyberPassword");
            this.Property(t => t.CyberKholase).HasColumnName("CyberKholase");
            this.Property(t => t.CyberDore).HasColumnName("CyberDore");
            this.Property(t => t.CyberDateTime).HasColumnName("CyberDateTime");
            this.Property(t => t.CyberPuUser).HasColumnName("CyberPuUser");
            this.Property(t => t.CyberEdDateTime).HasColumnName("CyberEdDateTime");
            this.Property(t => t.CyberEdPuUser).HasColumnName("CyberEdPuUser");
        }
    }
}
