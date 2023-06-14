using System;
using System.Linq.Expressions;
using AddressBook.Application.Contracts;
using AddressBook.Domain.Entities;
using Moq;

namespace AddressBook.Infrastructure.Tests.Mocks
{
	public static class MockContactRepository
	{
        private static List<Contact> contacts = new List<Contact>
        {
            new Contact
            {
                Id = 1,
                FirstName = "Lettie",
                LastName = "Sidwick",
                Birthday = new DateTime(2000,05,14),
                PhoneNumber = "637-909-2569",
                PhysicalAddress = "Apt 736",
                Email = "lsidwick0@163.com",
                CompanyName = "Swift, Treutel and Hauck",
                IsDeleted = false,
            },
            new Contact
            {
                Id = 2,
                FirstName = "Demetri",
                LastName = "Kochl",
                Birthday = new DateTime(1996,04,28),
                PhoneNumber = "834-687-3322",
                PhysicalAddress = "4th Floor",
                Email = "dkochl1@1688.com",
                CompanyName = "Heaney-Leuschke",
                IsDeleted = false,
            },
        };

        public static List<Contact> Contacts
        {
            get {
                return contacts;
            }
        }
        
		public static Mock<IContactRepository> GetContactRepository()
		{
            var mockRepo = new Mock<IContactRepository>();

            mockRepo.Setup(r => r.GetAsync(null))
                .ReturnsAsync(contacts);

            mockRepo.Setup(r => r
                .GetAsync(It.IsAny<Expression<Func<Contact, bool>>>()))
                .ReturnsAsync(
                    (Expression<Func<Contact, bool>> filters) =>
                    {
                        if (filters != null)
                            return contacts.Where(filters.Compile()).ToList();
                        else
                            return contacts;
                    });

            mockRepo.Setup(r => r
                .GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync((int id) => contacts.FirstOrDefault(p => p.Id == id)
            );

            //mockRepo.Setup(r => r
            //    .AddAsync(It.IsAny<Contact>()))
            //    .ReturnsAsync((Contact contact) => {
            //        contact.Id = contacts.Max(p => p.Id) + 1;
            //        contacts.Add(contact);
            //        return contact;
            //    });

            mockRepo.Setup(r => r.DeleteAsync(It.IsAny<Contact>()));

            mockRepo.Setup(r => r.UpdateAsync(It.IsAny<Contact>()));

            mockRepo.Setup(r => r.AddAsync(It.IsAny<Contact>()))
                .ReturnsAsync((Contact contact) => {
                    var newId = contacts.Max(p => p.Id) + 1;
                    contact.Id = newId;
                    Contacts.Add(contact);
                    return contact;
                });

            return mockRepo;
        }
    }
}

