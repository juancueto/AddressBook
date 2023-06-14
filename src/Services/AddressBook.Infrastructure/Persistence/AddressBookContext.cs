using System;
using AddressBook.Domain.Entities;
using AddressBook.Domain.Common;
using Microsoft.EntityFrameworkCore;
using AddressBook.Infrastructure.Configurations;

namespace AddressBook.Infrastructure.Persistence
{
	public class AddressBookContext: DbContext
	{
		public AddressBookContext(DbContextOptions<AddressBookContext> options): base(options)
		{
            
		}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Contact>(new ContactConfiguration());
            modelBuilder.Entity<Contact>().HasQueryFilter(p => !p.IsDeleted);
        }

        public DbSet<Contact> Contacts { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<EntityBase>())
            {
                switch (entry.State)
                {
                    // Audit Fields
                    case EntityState.Added:                        
                        entry.Entity.IsDeleted = false;
                        break;                    
                    case EntityState.Deleted:
                        entry.Entity.IsDeleted = true;
                        entry.State = EntityState.Modified;
                        break;
                    default:
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}

