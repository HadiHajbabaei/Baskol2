using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MyDB.BusinessLayer.Models.Mapping
{
    public class FactorMap : EntityTypeConfiguration<Factor>
    {
        public FactorMap()
        {
            // Primary Key
            this.HasKey(t => t.FactorPuID);

            // Table & Column Mappings
            this.ToTable("Factor");
            this.Property(t => t.FactorPuID).HasColumnName("FactorPuID");
            this.Property(t => t.Tozin2PuID).HasColumnName("Tozin2PuID");
            this.Property(t => t.FactorDateTime).HasColumnName("FactorDateTime");
            this.Property(t => t.FactorPuUSer).HasColumnName("FactorPuUSer");
        }
    }
}
