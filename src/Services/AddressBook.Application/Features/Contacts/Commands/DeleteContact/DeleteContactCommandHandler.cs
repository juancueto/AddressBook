using System;
using AddressBook.Application.Contracts;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using AddressBook.Domain.Entities;
using AddressBook.Application.Exceptions;

namespace AddressBook.Application.Features.Contacts.Commands.DeleteContact
{
    public class DeleteContactCommandHandler : IRequestHandler<DeleteContactCommand>
    {
        private readonly IContactRepository _contactRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteContactCommandHandler> _logger;

        public DeleteContactCommandHandler(
            IContactRepository contactRepository,
            IMapper mapper,
            ILogger<DeleteContactCommandHandler> logger
            )
        {
            _contactRepository = contactRepository ?? throw new ArgumentNullException(nameof(contactRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Unit> Handle(DeleteContactCommand request, CancellationToken cancellationToken)
        {
            var contactToDelete = await _contactRepository.GetByIdAsync(request.Id);

            if (contactToDelete == null)
                throw new NotFoundException(nameof(Contact), request.Id);

            await _contactRepository.DeleteAsync(contactToDelete);

            _logger.LogInformation($"Contact {contactToDelete.Id} is successfully deleted.");

            return Unit.Value;
        }
    }
}

