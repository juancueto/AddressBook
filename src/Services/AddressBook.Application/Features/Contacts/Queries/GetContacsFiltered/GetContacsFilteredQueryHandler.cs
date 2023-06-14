using System;
using AddressBook.Application.Contracts;
using AddressBook.Application.Features.Contacts.Queries.GetContactById;
using AddressBook.Domain.Entities;
using AutoMapper;
using MediatR;
using LinqKit;
using System.Linq.Expressions;

namespace AddressBook.Application.Features.Contacts.Queries.GetContacsFiltered
{
	public class GetContacsFilteredQueryHandler : IRequestHandler<GetContacsFilteredQuery, IEnumerable<ContactSearchItemResultVm>>
    {
        private readonly IContactRepository _contactRepository;
        private readonly IMapper _mapper;

        public GetContacsFilteredQueryHandler(IContactRepository contactRepository, IMapper mapper)
        {
            this._contactRepository = contactRepository ?? throw new ArgumentNullException(nameof(contactRepository));
            this._mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<ContactSearchItemResultVm>> Handle(GetContacsFilteredQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Contact, bool>> filters = PredicateBuilder.New<Contact>(true);

            if (!string.IsNullOrEmpty(request.Contact)) {
                filters = filters.And(p => p.FirstName.Contains(request.Contact));
                filters = filters.Or(p => p.LastName.Contains(request.Contact));
                filters = filters.Or(p => p.PhoneNumber.Contains(request.Contact));
            }

            var searchResult = await _contactRepository.GetAsync (filters);

            return _mapper.Map<IEnumerable<ContactSearchItemResultVm>>(searchResult.OrderBy(p => p.FirstName).ThenBy(p => p.LastName));
        }
    }
}

