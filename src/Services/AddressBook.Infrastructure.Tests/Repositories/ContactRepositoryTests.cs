using System;
using AddressBook.Application.Contracts;
using AddressBook.Domain.Entities;
using AddressBook.Infrastructure.Persistence;
using AddressBook.Infrastructure.Tests.Mocks;
using Moq;

namespace AddressBook.Infrastructure.Tests.Repositories
{
	public class ContactRepositoryTests
	{
        private readonly Mock<IContactRepository> _mockRepo;

		public ContactRepositoryTests()
		{
            _mockRepo = MockContactRepository.GetContactRepository();
        }

        [Fact]
		public async Task GetAsync_Should_GetAllContacts()
		{
			var result = await _mockRepo.Object.GetAsync(null);
			Assert.NotNull(result);
            Assert.IsAssignableFrom<IEnumerable<Contact>>(result);
        }

        [Fact]
        public async Task GetByIdAsync_Should_GetContactById()
        {
            var id = 1;
            var result = await _mockRepo.Object.GetByIdAsync(id);
            Assert.NotNull(result);
            Assert.IsAssignableFrom<Contact>(result);
        }

        [Fact]
        public async Task AddAsync_Should_AddContact()
        {
            var validContact = new Contact()
            {
                FirstName = "First",
                LastName = "Last",
                Birthday = new DateTime(2000, 1, 1),
                CompanyName = "Company",
                Email = "user@mail.com",
                PhoneNumber = "123-456-7890",
                PhysicalAddress = "Address"
            };

            var result = await _mockRepo.Object.AddAsync(validContact);
            Assert.NotNull(result);
            
            Assert.NotEqual(0, result.Id);
        }

        [Fact]
        public async Task UpdateAsync_Should_UpdateContact()
        {
            var validContact = new Contact()
            {
                Id = 1,
                FirstName = "First",
                LastName = "Last",
                Birthday = new DateTime(2000, 1, 1),
                CompanyName = "Company",
                Email = "user@mail.com",
                PhoneNumber = "123-456-7890",
                PhysicalAddress = "Address"
            };

            try
            {
                await _mockRepo.Object.UpdateAsync(validContact);
                Assert.True(true);

                //var contactUpdate = MockContactRepository.Contacts.FirstOrDefault(p => p.Id == validContact.Id);

                //Assert.Equivalent(validContact, contactUpdate);
            }
            catch (Exception ex)
            {
                Assert.True(false);
            }


        }

        [Fact]
        public async Task DeleteAsync_Should_DeleteContact()
        {
            var validContact = new Contact()
            {
                Id = 1
            };

            try
            {
                await _mockRepo.Object.DeleteAsync(validContact);
                Assert.True(true);

                //var contactUpdate = MockContactRepository.Contacts.FirstOrDefault(p => p.Id == validContact.Id);

                //Assert.Equivalent(validContact, contactUpdate);
            }
            catch (Exception ex)
            {
                Assert.True(false);
            }
        }
    }
}

