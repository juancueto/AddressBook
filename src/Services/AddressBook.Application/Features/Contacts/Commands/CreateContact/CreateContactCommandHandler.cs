using System;
using AddressBook.Application.Contracts;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using AddressBook.Domain.Entities;

namespace AddressBook.Application.Features.Contacts.Commands.CreateContact
{
    public class CreateContactCommandHandler : IRequestHandler<CreateContactCommand, int>
    {
        private readonly IContactRepository _contactRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateContactCommandHandler> _logger;

        public CreateContactCommandHandler(
            IContactRepository contactRepository,
            IMapper mapper,
            ILogger<CreateContactCommandHandler> logger
            )
        {
            _contactRepository = contactRepository ?? throw new ArgumentNullException(nameof(contactRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<int> Handle(CreateContactCommand request, CancellationToken cancellationToken)
        {
            var newContact = _mapper.Map<Contact>(request);
            var contactEntity = await _contactRepository.AddAsync(newContact);

            _logger.LogInformation($"Contact {contactEntity.Id} is successfully created.");
            return contactEntity.Id;
        }
    }
}

