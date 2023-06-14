using System;
using AddressBook.Domain.Entities;
using AddressBook.Application.Contracts;
using AddressBook.Infrastructure.Persistence;

namespace AddressBook.Infrastructure.Repositories
{
	public class ContactRepository: BaseRepository<Contact>, IContactRepository
	{
		public ContactRepository(AddressBookContext dbContext) : base(dbContext)
		{
		}
	}
}

