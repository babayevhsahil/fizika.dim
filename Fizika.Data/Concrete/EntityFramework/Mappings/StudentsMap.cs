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
    public class StudentsMap : IEntityTypeConfiguration<Students>
    {
        public void Configure(EntityTypeBuilder<Students> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t =>t.Id).ValueGeneratedOnAdd();

            builder.Property(t => t.Fullname).HasMaxLength(70).IsRequired();
            builder.Property(t => t.Photo).HasMaxLength(300).IsRequired();
            builder.Property(t => t.Point).HasMaxLength(10);
            builder.Property(t => t.University).HasMaxLength(60);
            builder.Property(t => t.PointPhysic).HasMaxLength(10);
            builder.Property(t => t.IsActive).IsRequired();
            builder.Property(t => t.IsDeleted).IsRequired();
            builder.Property(t => t.ModifiedByName).HasMaxLength(50).IsRequired();
            builder.Property(t => t.CreatedByName).HasMaxLength(50).IsRequired();
            builder.Property(t => t.CreatedDate).IsRequired();
            builder.Property(t => t.ModifiedDate).IsRequired();

            builder.ToTable("Students");
        }
    }
}
