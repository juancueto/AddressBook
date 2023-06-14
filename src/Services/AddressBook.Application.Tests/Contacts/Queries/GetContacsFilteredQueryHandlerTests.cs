using System;
using AddressBook.Application.Contracts;
using AddressBook.Application.Features.Contacts.Queries.GetContacsFiltered;
using AddressBook.Application.Mappings;
using AddressBook.Infrastructure.Tests.Mocks;
//using AddressBook.Application.Tests.Mocks;
using AutoMapper;
using Moq;

namespace AddressBook.Application.Tests.Contacts.Queries
{
	public class GetContacsFilteredQueryHandlerTests
	{
        private readonly Mock<IContactRepository> _mockRepo;
        private readonly IMapper _mapper;

        public GetContacsFilteredQueryHandlerTests()
        {
            _mockRepo = MockContactRepository.GetContactRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task Handle_Should_GetContactsFiltered()
        {
            // Arrange
            var contact = "";

            var allContacts = await _mockRepo.Object.GetAsync(null);

            var handler = new GetContacsFilteredQueryHandler(_mockRepo.Object, _mapper);

            // Act
            var result = await handler.Handle(new GetContacsFilteredQuery() { Contact = contact }, CancellationToken.None);

            // Assert
            Assert.NotNull(result);            
            Assert.IsAssignableFrom<IEnumerable<ContactSearchItemResultVm>>(result);
            Assert.Equal(allContacts.Count(), result.Count());
        }
    }
}

