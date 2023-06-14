using AddressBook.API.Controllers;
using MediatR;
using Microsoft.Extensions.Logging;
using Moq;

namespace AddressBook.API.Tests;

public class ContactTest
{
    private readonly ContactController _controller;
    private readonly Mock<IMediator> _mediator;
    private readonly Mock<ILogger<ContactController>> _logger;
    public ContactTest()
    {
        _mediator = new Mock<IMediator>();
        _logger = new Mock<ILogger<ContactController>>();
        _controller = new ContactController(_mediator.Object, _logger.Object);
    }

    [Fact]
    public async Task GetById_GivenId_ReturnContact()
    {
        //Arrange
        var contactID = 1;
        //Act
        var result = await _controller.GetById(contactID);
        //Assert
        Assert.NotNull(result.Value);
        Assert.Equal(result.Value?.Id, contactID);

    }
}
