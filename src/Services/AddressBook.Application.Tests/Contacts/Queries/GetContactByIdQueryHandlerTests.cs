using System;
using AddressBook.Application.Contracts;
using AddressBook.Application.Features.Contacts.Queries.GetContactById;
using AddressBook.Application.Mappings;
using AddressBook.Infrastructure.Tests.Mocks;
//using AddressBook.Application.Tests.Mocks;
using AutoMapper;
using Moq;

namespace AddressBook.Application.Tests.Contacts.Queries
{
	public class GetContactByIdQueryHandlerTests
	{
		private readonly Mock<IContactRepository> _mockRepo;
		private readonly IMapper _mapper;

		public GetContactByIdQueryHandlerTests()
		{
			_mockRepo = MockContactRepository.GetContactRepository();

			var mapperConfig = new MapperConfiguration(c =>
			{
				c.AddProfile<MappingProfile>();
			});

			_mapper = mapperConfig.CreateMapper();
		}

		[Fact]
		public async Task Handle_Should_GetContactById()
		{
			// Arrange
			var contactId = 1;
			var handler = new GetContactByIdQueryHandler(_mockRepo.Object, _mapper);

			// Act
			var result = await handler.Handle(new GetContactByIdQuery(contactId), CancellationToken.None);

			// Assert
			Assert.IsType<ContactVm>(result);
			Assert.Equal(result.Id, contactId);
		}
	}
}

