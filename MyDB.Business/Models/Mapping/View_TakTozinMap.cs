using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MyDB.BusinessLayer.Models.Mapping
{
    public class View_TakTozinMap : EntityTypeConfiguration<View_TakTozin>
    {
        public View_TakTozinMap()
        {
            // Primary Key
            this.HasKey(t => new { t.CarPuID, t.SabtMahsolPuID, t.VahedPuID,t.DriverPuID,t.TakTozinPuID });

            this.Property(t => t.DriverPuID).HasColumnName("DriverPuID");
            this.Property(t => t.DriverName).HasColumnName("DriverName");
            this.Property(t => t.DriverCodeMeli).HasColumnName("DriverCodeMeli");
            this.Property(t => t.DriverPNumber).HasColumnName("DriverPNumber");
            this.Property(t => t.DriverDesc).HasColumnName("DriverDesc");
            this.Property(t => t.DriverAddress).HasColumnName("DriverAddress");
            this.Property(t => t.CustomerPuID).HasColumnName("CustomerPuID");
            this.Property(t => t.DriverCode).HasColumnName("DriverCode");
            this.Property(t => t.DriverEnable).HasColumnName("DriverEnable");
            this.Property(t => t.DriverDateTime).HasColumnName("DriverDateTime");
            this.Property(t => t.DriverPuUser).HasColumnName("DriverPuUser");
            this.Property(t => t.DriverEdDateTime).HasColumnName("DriverEdDateTime");
            this.Property(t => t.DriverEdPuUser).HasColumnName("DriverEdPuUser");
            this.Property(t => t.DriverTagNumber).HasColumnName("DriverTagNumber");
            this.Property(t => t.CarPuID).HasColumnName("CarPuID");
            this.Property(t => t.SabtMahsolPuID).HasColumnName("SabtMahsolPuID");
            this.Property(t => t.SabtMahsolName).HasColumnName("SabtMahsolName");
            this.Property(t => t.SabtMahsolVahed).HasColumnName("SabtMahsolVahed");
            this.Property(t => t.SabtMahsolCod).HasColumnName("SabtMahsolCod");
            this.Property(t => t.SabtMahsolDescription).HasColumnName("SabtMahsolDescription");
            this.Property(t => t.SabtMahsolPuUSER).HasColumnName("SabtMahsolPuUSER");
            this.Property(t => t.SabtMahsolEDdatetime).HasColumnName("SabtMahsolEDdatetime");
            this.Property(t => t.SabtMahsolEDPuUSER).HasColumnName("SabtMahsolEDPuUSER");
            this.Property(t => t.VahedPuID).HasColumnName("VahedPuID");
            this.Property(t => t.VahedName).HasColumnName("VahedName");
            this.Property(t => t.TakTozinPuID).HasColumnName("TakTozinPuID");
         

            this.Property(t => t.TakTozinGhabz).HasColumnName("TakTozinGhabz");
          
            this.Property(t => t.TakTozinTime).HasColumnName("TakTozinTime");
            this.Property(t => t.TakTozinWeighte).HasColumnName("TakTozinWeighte");
            this.Property(t => t.TakTozinDate).HasColumnName("TakTozinDate");
            this.Property(t => t.TakTozinDateTime).HasColumnName("TakTozinDateTime");
            this.Property(t => t.TakTozinPuUser).HasColumnName("TakTozinPuUser");
            this.Property(t => t.SabtMahsolPuID).HasColumnName("SabtMahsolPuID");
            this.Property(t => t.SabtMahsolName).HasColumnName("SabtMahsolName");
            this.Property(t => t.SabtMahsolVahed).HasColumnName("SabtMahsolVahed");
            this.Property(t => t.SabtMahsolCod).HasColumnName("SabtMahsolCod");
            this.Property(t => t.SabtMahsolDescription).HasColumnName("SabtMahsolDescription");
            this.Property(t => t.SabtMahsolPuUSER).HasColumnName("SabtMahsolPuUSER");
            this.Property(t => t.SabtMahsolEDdatetime).HasColumnName("SabtMahsolEDdatetime");
            this.Property(t => t.SabtMahsolEDPuUSER).HasColumnName("SabtMahsolEDPuUSER");
            this.Property(t => t.SabtMahsoldatetime).HasColumnName("SabtMahsoldatetime");
        }
    }
}
