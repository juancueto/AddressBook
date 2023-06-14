using System;
using AutoMapper;
using AddressBook.Domain.Entities;
using AddressBook.Application.Features.Contacts.Commands.CreateContact;
using AddressBook.Application.Features.Contacts.Commands.UpdateContact;
using AddressBook.Application.Features.Contacts.Queries.GetContactById;
using AddressBook.Application.Features.Contacts.Queries.GetContacsFiltered;
using AddressBook.Application.Contracts;

namespace AddressBook.Application.Mappings
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<Contact, CreateContactCommand>().ReverseMap();
            CreateMap<Contact, UpdateContactCommand>().ReverseMap();
            CreateMap<Contact, ContactVm>().ReverseMap();
            CreateMap<Contact, ContactSearchItemResultVm>().ReverseMap();
            CreateMap<DataCollection<Contact>, DataCollection<ContactSearchItemResultVm>>().ReverseMap();
        }
	}
}

