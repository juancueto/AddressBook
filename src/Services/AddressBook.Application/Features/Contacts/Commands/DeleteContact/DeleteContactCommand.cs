using System;
using MediatR;

namespace AddressBook.Application.Features.Contacts.Commands.DeleteContact
{
	public class DeleteContactCommand : IRequest
	{
        public int Id { get; set; }
        public DeleteContactCommand(int id)
        {
            this.Id = id;
        }
    }
}

