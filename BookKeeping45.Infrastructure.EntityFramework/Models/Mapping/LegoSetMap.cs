using BookKeeping45.Domain.Model;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace BookKeeping45.Infrastructure.EntityFramework.Models.Mapping
{
    public class LegoSetMap : EntityTypeConfiguration<LegoSet>
    {
        public LegoSetMap()
        {
            // Primary Key
            //this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(256);

            //// Table & Column Mappings
            this.ToTable("LegoSet"); 
            //this.Property(t => t.Id).HasColumnName("Id");
            //this.Property(t => t.Number).HasColumnName("Number");
            //this.Property(t => t.Name).HasColumnName("Name");
            //this.Property(t => t.IsSold).HasColumnName("IsSold");
            //this.Property(t => t.PurchasePrice).HasColumnName("PurchasePrice");
            //this.Property(t => t.SellPrice).HasColumnName("SellPrice");
        }
    }
}
