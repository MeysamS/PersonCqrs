using FluentValidation;
using PersonCQRS.Api.DTOs;

namespace PersonCQRS.Api.Validations
{
    public class CreatePersonCommandValidator:AbstractValidator<PersonDto>
    {
        public CreatePersonCommandValidator()
        {
            RuleFor(command => command.FirstName).NotEmpty();
            RuleFor(Commands => Commands.LastName).NotEmpty();
            RuleFor(Commands => Commands.Email).NotEmpty();
            RuleFor(Commands => Commands.DateOfBirth).NotEmpty();
            RuleFor(Commands => Commands.PhoneNumber).NotEmpty();
        }
    }
}