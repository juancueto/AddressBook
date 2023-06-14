using System;
using AddressBook.Application.Contracts;
using AddressBook.Application.Features.Contacts.Commands.UpdateContact;
using AddressBook.Application.Mappings;
using AddressBook.Infrastructure.Tests.Mocks;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Moq;

namespace AddressBook.Application.Tests.Contacts.Commands
{
	public class UpdateContactCommandHandlerTests
	{
        private readonly Mock<IContactRepository> _mockRepo;
        private readonly IMapper _mapper;
        private readonly Mock<ILogger<UpdateContactCommandHandler>> _logger;

        public UpdateContactCommandHandlerTests()
        {
            _mockRepo = MockContactRepository.GetContactRepository();
            _logger = new Mock<ILogger<UpdateContactCommandHandler>>();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task Handle_SHould_UpdateContact()
        {
            // Arrange
            var initialQty = (await _mockRepo.Object.GetAsync(null)).ToList();

            var validContact = new UpdateContactCommand()
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

            // Act
            var handler = new UpdateContactCommandHandler(_mockRepo.Object, _mapper, _logger.Object);

            // Assert
            var result = await handler.Handle(validContact, CancellationToken.None);
            var finalQty = (await _mockRepo.Object.GetAsync()).ToList();
            Assert.IsType<Unit>(result);
        }
    }
}

