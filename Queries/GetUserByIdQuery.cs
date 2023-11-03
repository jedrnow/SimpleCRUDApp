using FluentValidation;
using MediatR;
using SimpleCRUDApp.Models;

namespace SimpleCRUDApp.Queries
{
    public class GetUserByIdQuery : IRequest<User>
    {
        public int UserId { get; private set; }
        public GetUserByIdQuery(int userId)
        {
            UserId = userId;
        }
    }

    public class GetUserByIdQueryValidator : AbstractValidator<GetUserByIdQuery>
    {
        public GetUserByIdQueryValidator()
        {
            RuleFor(x=>x.UserId)
                .NotEmpty()
                .WithMessage("UserId is required.");
        }
    }
}
