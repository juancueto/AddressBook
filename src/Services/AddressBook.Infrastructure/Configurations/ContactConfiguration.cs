using System;
using AddressBook.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AddressBook.Infrastructure.Configurations
{
    public class ContactConfiguration : EntityBaseConfiguration<Contact>
    {
        public override void Configure(EntityTypeBuilder<Contact> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.FirstName).HasMaxLength(50).IsRequired().HasColumnType("varchar");
            builder.Property(p => p.LastName).HasMaxLength(50).IsRequired().HasColumnType("varchar");
            builder.Property(p => p.PhysicalAddress).HasMaxLength(250).HasColumnType("varchar");
            builder.Property(p => p.PhoneNumber).HasMaxLength(50).IsRequired().HasColumnType("varchar");
            builder.Property(p => p.Email).HasMaxLength(100).HasColumnType("varchar");
            builder.Property(p => p.CompanyName).HasMaxLength(100).HasColumnType("varchar");
            builder.Property(p => p.Birthday).HasColumnType("date");
        }
    }
}

