using System;
using AddressBook.Domain.Entities;
namespace AddressBook.Application.Contracts
{
	public interface IContactRepository : IAsyncRepository<Contact>
	{
	}
}

