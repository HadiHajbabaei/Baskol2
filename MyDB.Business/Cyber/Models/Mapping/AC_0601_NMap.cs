using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MyDB.BusinessLayer.Cyber.Models.Mapping
{
    public class AC_0601_NMap : EntityTypeConfiguration<AC_0601_N>
    {
        public AC_0601_NMap()
        {
            // Primary Key
            this.HasKey(t => t.DepartmentId);

            // Properties 
            this.Property(t => t.DepartmentNumber)
                .HasMaxLength(50);
            this.Property(t => t.DepartmentName)
                .HasMaxLength(50);



            // Table & Column Mappings
            this.ToTable("AC_0601_N");
            this.Property(t => t.DepartmentNumber).HasColumnName("DepartmentNumber");
            this.Property(t => t.DeptGroupId).HasColumnName("DeptGroupId");
            this.Property(t => t.DepartmentName).HasColumnName("DepartmentName"); 
        }
    }
}
