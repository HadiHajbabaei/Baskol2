using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MyDB.BusinessLayer.Cyber.Models.Mapping
{
    public class AC_0701_NMap : EntityTypeConfiguration<AC_0701_N>
    {
        public AC_0701_NMap()
        {
            // Primary Key
            this.HasKey(t => t.DeptGroupId);

            // Properties
            this.Property(t => t.DeptGroupNumber)
                .HasMaxLength(10);
            this.Property(t => t.DeptGroupName)
                .HasMaxLength(50);


            // Table & Column Mappings
            this.ToTable("AC_0701_N");
            this.Property(t => t.DeptGroupId).HasColumnName("DeptGroupId");
            this.Property(t => t.DeptGroupNumber).HasColumnName("DeptGroupNumber");
            this.Property(t => t.DeptGroupName).HasColumnName("DeptGroupName");

        }
    }
}
