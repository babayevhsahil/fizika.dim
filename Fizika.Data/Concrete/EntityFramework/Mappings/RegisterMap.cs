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
    public class RegisterMap : IEntityTypeConfiguration<Register>
    {
        public void Configure(EntityTypeBuilder<Register> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.Property(p => p.Fullname).HasMaxLength(50).IsRequired();
            builder.Property(p => p.Email).HasMaxLength(70).IsRequired();
            builder.Property(p => p.Message).HasMaxLength(500).IsRequired();
            builder.Property(p => p.Number).HasMaxLength(16).IsRequired();
            builder.Property(p => p.IsActive).IsRequired();
            builder.Property(p => p.IsDeleted).IsRequired();
            builder.Property(p => p.ModifiedByName).HasMaxLength(50).IsRequired();
            builder.Property(p => p.CreatedByName).HasMaxLength(50).IsRequired();
            builder.Property(p => p.CreatedDate).IsRequired();
            builder.Property(p => p.ModifiedDate).IsRequired();

            builder.ToTable("Registers");
            builder.HasData(
            new Register
            {
                Id = 1,
                Fullname = "Tural Abdulxaliqov",
                Message = "C# Programlama Dili ile İlgili En Güncel Bilgiler",
                Number = "050 365 33 19",
                Email = "tural@mail.ru",
                IsActive = true,
                IsDeleted = false,
                CreatedByName = "InitialCreate",
                CreatedDate = DateTime.Now,
                ModifiedByName = "InitialCreate",
                ModifiedDate = DateTime.Now,

            });
        }
    }
}
