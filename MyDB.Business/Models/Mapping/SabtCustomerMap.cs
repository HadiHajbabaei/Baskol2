using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MyDB.BusinessLayer.Models.Mapping
{
    public class SabtCustomerMap : EntityTypeConfiguration<SabtCustomer>
    {
        public SabtCustomerMap()
        {
            // Primary Key
            this.HasKey(t => t.CustomerPuID); 

            // Table & Column Mappings
            this.ToTable("SabtCustomer");
            this.Property(t => t.CustomerPuID).HasColumnName("CustomerPuID"); 
            this.Property(t => t.CustomerCode).HasColumnName("CustomerCode");
            this.Property(t => t.CustomerName).HasColumnName("CustomerName");
            this.Property(t => t.CustomerCodeMeli).HasColumnName("CustomerCodeMeli");
            this.Property(t => t.CustomerDesc).HasColumnName("CustomerDesc");
            this.Property(t => t.CustomerAdress).HasColumnName("CustomerAdress");
            this.Property(t => t.CustomerTel).HasColumnName("CustomerTel");
            this.Property(t => t.CustomerAccountNumber1).HasColumnName("CustomerAccountNumber1");
            this.Property(t => t.CustomerDateTime).HasColumnName("CustomerDateTime");
            this.Property(t => t.CustomerPuUser).HasColumnName("CustomerPuUser");

        }
    }
}
