using FluentValidation;
using MediatR;

namespace SimpleCRUDApp.Commands
{
    public class DeleteUserCommand : IRequest<bool>
    {
        public int UserId { get; private set; }

        public DeleteUserCommand(int userId)
        {
            UserId = userId;
        }
    }

    public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
    {
        public DeleteUserCommandValidator()
        {
            RuleFor(command => command.UserId)
                .NotEmpty()
                .WithMessage("UserId is required.");
        }
    }
}
