using FluentValidation;
using MediatR;

namespace SimpleCRUDApp.Commands
{
    public class UpdateUserCommand : IRequest<bool>
    {
        public int UserId { get; private set; }
        public string Name { get; private set; }
        public string Phone { get; private set; }
        public string Email { get; private set; }

        public UpdateUserCommand(int userId, string name, string phone, string email)
        {
            UserId = userId;
            Name = name;
            Phone = phone;
            Email = email;
        }
    }

    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(command => command.Name)
                .NotEmpty()
                .WithMessage("Name is required.")
                .Length(ConstValues.MinNameLength, ConstValues.MaxNameLength)
                .WithMessage($"Name length should be between {ConstValues.MinNameLength} and {ConstValues.MaxNameLength}");

            RuleFor(command => command.Phone)
                .NotEmpty()
                .WithMessage("Phone is required.")
                .Length(ConstValues.MinPhoneNumberLength, ConstValues.MaxPhoneNumberLength)
                .WithMessage($"Phone number length should be between {ConstValues.MinPhoneNumberLength} and {ConstValues.MaxPhoneNumberLength}")
                .Matches("^[0-9]+$")
                .WithMessage("Phone number must contain only digits.");

            RuleFor(command => command.Email)
                .NotEmpty()
                .WithMessage("Email is required.")
                .Length(ConstValues.MinEmailLength, ConstValues.MaxEmailLength)
                .WithMessage($"Email length should be between {ConstValues.MinEmailLength} and {ConstValues.MaxEmailLength}")
                .EmailAddress()
                .WithMessage("Invalid email format.");
        }
    }
}
