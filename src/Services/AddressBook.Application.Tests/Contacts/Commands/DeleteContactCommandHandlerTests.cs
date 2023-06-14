using System;
using AddressBook.Application.Contracts;
using AddressBook.Application.Features.Contacts.Commands.DeleteContact;
using AddressBook.Application.Features.Contacts.Queries.GetContacsFiltered;
using AddressBook.Application.Mappings;
using AddressBook.Domain.Entities;
using AddressBook.Infrastructure.Tests.Mocks;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Moq;

namespace AddressBook.Application.Tests.Contacts.Commands
{
	public class DeleteContactCommandHandlerTests
	{
        private readonly Mock<IContactRepository> _mockRepo;
        private readonly IMapper _mapper;
        private readonly Mock<ILogger<DeleteContactCommandHandler>> _logger;

        public DeleteContactCommandHandlerTests()
		{
            _mockRepo = MockContactRepository.GetContactRepository();
            _logger = new Mock<ILogger<DeleteContactCommandHandler>>();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task Handle_Should_DeleteContact()
        {
            // Arrange
            var allContacts = await _mockRepo.Object.GetAsync();
            var contactToDelete = allContacts.FirstOrDefault(p => !p.IsDeleted);
            var handler = new DeleteContactCommandHandler(_mockRepo.Object, _mapper, _logger.Object);

            // Act
            var result = await handler.Handle(new DeleteContactCommand(contactToDelete!.Id), CancellationToken.None);

            // Assert
            Assert.IsType<Unit>(result);
        }

    }
}

