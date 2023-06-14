using System;
using AddressBook.Application.Contracts;
using AddressBook.Application.Exceptions;
using AddressBook.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AddressBook.Application.Features.Contacts.Queries.GetContactById
{
	public class GetContactByIdQueryHandler : IRequestHandler<GetContactByIdQuery, ContactVm>
	{
        private readonly IContactRepository _contactRepository;
        private readonly IMapper _mapper;

        public GetContactByIdQueryHandler(IContactRepository contactRepository, IMapper mapper)
        {
            this._contactRepository = contactRepository ?? throw new ArgumentNullException(nameof(contactRepository));
            this._mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<ContactVm> Handle(GetContactByIdQuery request, CancellationToken cancellationToken)
        {
            var contactEntity = await _contactRepository.GetByIdAsync(request.Id);
            if (contactEntity == null)
                return null;

            return _mapper.Map<ContactVm>(contactEntity);
        }
    }
}

