using System;
namespace AddressBook.Application.Features.Contacts.Queries.GetContactById
{
	public class ContactVm
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

