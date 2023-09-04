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
    public class ExamMap : IEntityTypeConfiguration<Exam>
    {
        public void Configure(EntityTypeBuilder<Exam> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.Property(p => p.ExamName).HasMaxLength(70).IsRequired();
            builder.Property(p => p.ExamYear).IsRequired();
            builder.Property(p => p.DownloadCount);
            builder.Property(p => p.FileName);
            builder.Property(p => p.Teacher).HasMaxLength(50).IsRequired();
            builder.Property(p => p.Link).HasMaxLength(500).IsRequired();
            builder.Property(p => p.IsActive).IsRequired();
            builder.Property(p => p.IsDeleted).IsRequired();
            builder.Property(p => p.ModifiedByName).HasMaxLength(50).IsRequired();
            builder.Property(p => p.CreatedByName).HasMaxLength(50).IsRequired();
            builder.Property(p => p.CreatedDate).IsRequired();
            builder.Property(p => p.ModifiedDate).IsRequired();

            builder.HasOne<ExamCategory>(p => p.Examcategory).WithMany(p => p.Exams).HasForeignKey(p => p.ExamCategoryId);

            builder.ToTable("Exams");
        }
    }
}
