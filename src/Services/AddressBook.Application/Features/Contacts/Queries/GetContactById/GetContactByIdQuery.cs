using System;
using MediatR;

namespace AddressBook.Application.Features.Contacts.Queries.GetContactById
{
	public class GetContactByIdQuery: IRequest<ContactVm>
	{
		public int Id
		{
			get;
			private set;
		}
		public GetContactByIdQuery(int id)
		{
			this.Id = id;
		}
	}
}

