﻿using System;
using FluentValidation.Results;

namespace AddressBook.Application.Exceptions
{
	public class ValidationException : ApplicationException
	{
        public IDictionary<string, string[]> Errors { get; }

        public ValidationException()
			: base("One or more validation failures have ocurred")
		{
			Errors = new Dictionary<string, string[]>();
		}

        public ValidationException(IEnumerable<ValidationFailure> failures)
            : this()
        {
            Errors = failures
                .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
                .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());
        }
    }
}

