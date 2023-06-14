using System;
using AddressBook.Application.Contracts;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using AddressBook.Domain.Entities;
using AddressBook.Application.Exceptions;

namespace AddressBook.Application.Features.Contacts.Commands.UpdateContact
{
    public class UpdateContactCommandHandler : IRequestHandler<UpdateContactCommand>
    {
        private readonly IContactRepository _contactRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateContactCommandHandler> _logger;

        public UpdateContactCommandHandler(
            IContactRepository contactRepository,
            IMapper mapper,
            ILogger<UpdateContactCommandHandler> logger
            )
        {
            _contactRepository = contactRepository ?? throw new ArgumentNullException(nameof(contactRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Unit> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
        {
            var contactToUpdate = await _contactRepository.GetByIdAsync(request.Id);

            if (contactToUpdate == null)
                throw new NotFoundException(nameof(Contact), request.Id);

            _mapper.Map(request, contactToUpdate, typeof(UpdateContactCommand), typeof(Contact));
            
            await _contactRepository.UpdateAsync(contactToUpdate);

            _logger.LogInformation($"Contact {contactToUpdate.Id} is successfully updated.");

            return Unit.Value;
        }
    }
}

