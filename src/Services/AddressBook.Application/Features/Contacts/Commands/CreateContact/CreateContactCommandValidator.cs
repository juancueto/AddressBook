using System;
using FluentValidation;

namespace AddressBook.Application.Features.Contacts.Commands.CreateContact
{
	public class CreateContactCommandValidator : AbstractValidator<CreateContactCommand>
	{
		public CreateContactCommandValidator()
		{
            RuleFor(p => p.FirstName)
                .NotEmpty().WithMessage("{FirstName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{FirstName} must not exceed 50 characters.");

            RuleFor(p => p.LastName)
                .NotEmpty().WithMessage("{LastName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{LastName} must not exceed 50 characters.");

            RuleFor(p => p.PhoneNumber)
                .NotEmpty().WithMessage("{PhoneNumber} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PhoneNumber} must not exceed 50 characters.");

            RuleFor(p => p.PhysicalAddress)
                .MaximumLength(250).WithMessage("{PhysicalAddress} must not exceed 250 characters.");

            RuleFor(p => p.Email)
                .MaximumLength(250).WithMessage("{Email} must not exceed 100 characters.");

            RuleFor(p => p.CompanyName)
                .MaximumLength(250).WithMessage("{CompanyName} must not exceed 100 characters.");

        }
	}
}

