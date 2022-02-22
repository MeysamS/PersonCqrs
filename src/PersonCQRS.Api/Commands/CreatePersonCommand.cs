using System;
using CSharpFunctionalExtensions;
using MediatR;

namespace PersonCQRS.Api.Commands
{
    public sealed  partial class CreatePersonCommand:IRequest<Result>
    {
        public string FirstName { get; }
        public string LastName { get;  }
        public string Email { get;}
        public DateTime DateOfBirth { get; }
        public string PhoneNumber { get;}

        public CreatePersonCommand(string firstName, string lastName, string email, DateTime dateOfBirth, string phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            DateOfBirth = dateOfBirth;
            PhoneNumber = phoneNumber;
        }
    }
}