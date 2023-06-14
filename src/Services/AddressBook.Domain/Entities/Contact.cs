using System;
using AddressBook.Domain.Common;

namespace AddressBook.Domain.Entities
{
	public class Contact : EntityBase
	{
		public string FirstName { get; set; }
        public string LastName { get; set; }
		public DateTime? Birthday { get; set; }
		public string PhoneNumber { get; set; }
		public string PhysicalAddress { get; set; }
		public string Email { get; set; }
		public string CompanyName { get; set; }
	}
}

