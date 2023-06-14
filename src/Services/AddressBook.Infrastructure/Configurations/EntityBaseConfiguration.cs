using System;
using AddressBook.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AddressBook.Infrastructure.Configurations
{	
	public class EntityBaseConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>
        where TEntity: EntityBase
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(p => p.IsDeleted).IsRequired();            
        }
    }
}

