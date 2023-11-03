using FluentValidation;
using MediatR;
using SimpleCRUDApp.Models;

namespace SimpleCRUDApp.Queries
{
    public class GetUsersListQuery : IRequest<List<User>>
    {

        public GetUsersListQuery()
        {
        }
    }

    public class GetUsersListQueryValidator : AbstractValidator<GetUsersListQuery>
    {
        public GetUsersListQueryValidator()
        {
        }
    }
}
