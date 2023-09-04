using Fizika.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fizika.Data.Concrete.EntityFramework.Mappings
{
    public class BusinessMap : IEntityTypeConfiguration<Business>
    {
        public void Configure(EntityTypeBuilder<Business> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).ValueGeneratedOnAdd();

            builder.Property(b => b.Header).HasMaxLength(70).IsRequired();
            builder.Property(b => b.Duration).HasMaxLength(10).IsRequired();
            builder.Property(b => b.Language).HasMaxLength(30).IsRequired();
            builder.Property(b => b.Lectures).HasMaxLength(10).IsRequired();
            builder.Property(b => b.Price).HasMaxLength(10).IsRequired();
            builder.Property(b => b.Description).HasMaxLength(500);
            builder.Property(b => b.Link).HasMaxLength(500);
            builder.Property(b => b.IsActive).IsRequired();
            builder.Property(b => b.IsDeleted).IsRequired();
            builder.Property(b => b.ModifiedByName).HasMaxLength(50).IsRequired();
            builder.Property(b => b.CreatedByName).HasMaxLength(50).IsRequired();
            builder.Property(b => b.CreatedDate).IsRequired();
            builder.Property(b => b.ModifiedDate).IsRequired();

            builder.ToTable("Businesses");
        }
    }
}
