using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MyDB.BusinessLayer.Models.Mapping
{
    public class View_AppCrackMap : EntityTypeConfiguration<View_AppCrack>
    {
        public View_AppCrackMap()
        {
            // Primary Key
            this.HasKey(t => new { t.ActivatePuID, t.AppPuID, t.CrackPuID });

            // Table & Column Mappings Activate
            this.ToTable("View_AppCrack");
            this.Property(t => t.ActivatePuID).HasColumnName("ActivatePuID"); 
            this.Property(t => t.ActiveDateTime).HasColumnName("ActiveDateTime");

            // Table & Column Mappings App
            this.Property(t => t.AppPuID).HasColumnName("AppPuID");
            this.Property(t => t.AppName).HasColumnName("AppName");

            // Table & Column Mappings App
            this.Property(t => t.CrackPuID).HasColumnName("CrackPuID");
            this.Property(t => t.CrackUserNumber).HasColumnName("CrackUserNumber");
            this.Property(t => t.CrackCompanyName).HasColumnName("CrackCompanyName"); 
            this.Property(t => t.CrackCode).HasColumnName("CrackCode");

            // Table & Column Mappings App
            this.Property(t => t.AppPuID).HasColumnName("AppPuID");
            this.Property(t => t.AppName).HasColumnName("AppName");
        }
    }
}
