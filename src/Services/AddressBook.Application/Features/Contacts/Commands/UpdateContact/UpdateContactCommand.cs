using System;
using MediatR;

namespace AddressBook.Application.Features.Contacts.Commands.UpdateContact
{
	public class UpdateContactCommand : IRequest
	{
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? Birthday { get; set; }
        public string PhoneNumber { get; set; }
        public string PhysicalAddress { get; set; }
        public string Email { get; set; }
        public string CompanyName { get; set; }
    }
}

