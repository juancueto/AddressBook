using System;
using AddressBook.Application.Contracts;
using AddressBook.Application.Features.Contacts.Commands.CreateContact;
using AddressBook.Application.Features.Contacts.Commands.DeleteContact;
using AddressBook.Application.Mappings;
using AddressBook.Infrastructure.Tests.Mocks;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Moq;

namespace AddressBook.Application.Tests.Contacts.Commands
{
	public class CreateContactCommandHandlerTests
	{
        private readonly Mock<IContactRepository> _mockRepo;
        private readonly IMapper _mapper;
        private readonly Mock<ILogger<CreateContactCommandHandler>> _logger;

        public CreateContactCommandHandlerTests()
        {
            _mockRepo = MockContactRepository.GetContactRepository();
            _logger = new Mock<ILogger<CreateContactCommandHandler>>();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task Handle_Should_CreateContact()
        {
            // Arrange
            var initialQty = (await _mockRepo.Object.GetAsync()).ToList();

            var validContact = new CreateContactCommand() {
                FirstName = "First",
                LastName = "Last",
                Birthday = new DateTime(2000, 1, 1),
                CompanyName = "Company",
                Email = "user@mail.com",
                PhoneNumber = "123-456-7890",
                PhysicalAddress = "Address"
            };

            // Act
            var handler = new CreateContactCommandHandler(_mockRepo.Object, _mapper, _logger.Object);
            var result = await handler.Handle(validContact, CancellationToken.None);

            // Assert
            var finalQty = (await _mockRepo.Object.GetAsync()).ToList();

            Assert.NotEqual(0, result);

            Assert.Equal(finalQty.Count(), initialQty.Count() + 1);
        }
    }
}

