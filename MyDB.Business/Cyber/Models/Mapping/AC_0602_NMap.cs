using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MyDB.BusinessLayer.Cyber.Models.Mapping
{
    public class AC_0602_NMap : EntityTypeConfiguration<AC_0602_N>
    {
        public AC_0602_NMap()
        {
            // Primary Key
            this.HasKey(t => t.JobId);

            // Properties

            this.Property(t => t.JobNumber)
                .HasMaxLength(50);

            this.Property(t => t.JobName)
                .HasMaxLength(50);

            this.Property(t => t.MelliCode)
                .HasMaxLength(25);

            this.Property(t => t.Tel1)
                .HasMaxLength(25);

            this.Property(t => t.Tel2)
                .HasMaxLength(25);

            this.Property(t => t.Add1)
                .HasMaxLength(300);

            this.Property(t => t.Add2)
                .HasMaxLength(300);

            this.Property(t => t.City)
                .HasMaxLength(25);

            this.Property(t => t.State)
                .HasMaxLength(25);

            this.Property(t => t.Country)
                .HasMaxLength(25);

            this.Property(t => t.Mobile)
                .HasMaxLength(25);

            // Table & Column Mappings
            this.ToTable("AC_0602_N");
            this.Property(t => t.JobId).HasColumnName("JobId");
            this.Property(t => t.JobNumber).HasColumnName("JobNumber");
            this.Property(t => t.JobName).HasColumnName("JobName");
            this.Property(t => t.MelliCode).HasColumnName("MelliCode");
            this.Property(t => t.Tel1).HasColumnName("Tel1");
            this.Property(t => t.Tel2).HasColumnName("Tel2");
            this.Property(t => t.Add1).HasColumnName("Add1");
            this.Property(t => t.Add2).HasColumnName("Add2");
            this.Property(t => t.City).HasColumnName("City");
            this.Property(t => t.State).HasColumnName("State");
            this.Property(t => t.Country).HasColumnName("Country");
            this.Property(t => t.Mobile).HasColumnName("Mobile");
            this.Property(t => t.accprompt).HasColumnName("accprompt"); 
        }
    }
}
