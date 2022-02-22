using System;
using CSharpFunctionalExtensions;
using MediatR;

namespace PersonCQRS.Api.Commands
{
    public sealed  partial class UpdatePersonCommand:IRequest<Result>
    {
        public string FirstName { get; }
        public string LastName { get;  }
        public DateTime DateOfBirth { get; }
        public string PhoneNumber { get;}

        public UpdatePersonCommand(string firstName, string lastName, DateTime dateOfBirth, string phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            PhoneNumber = phoneNumber;
        }
    }
}