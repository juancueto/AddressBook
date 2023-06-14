using System;
using AddressBook.Application.Contracts;
using MediatR;

namespace AddressBook.Application.Features.Contacts.Queries.GetContacsFiltered
{
	public class GetContacsFilteredQuery: IRequest<IEnumerable<ContactSearchItemResultVm>>
	{
		public string Contact { get; set; }

        public GetContacsFilteredQuery()
		{
		}
    }
}

