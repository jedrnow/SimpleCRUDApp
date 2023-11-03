using MediatR;
using SimpleCRUDApp.Models;
using SimpleCRUDApp.Queries;
using SimpleCRUDApp.Repositories;

namespace SimpleCRUDApp.Handlers
{
    public class GetUsersListQueryHandler : IRequestHandler<GetUsersListQuery, List<User>>
    {
        private readonly IUserRepository _userRepository;

        public GetUsersListQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<User>> Handle(GetUsersListQuery request, CancellationToken cancellationToken)
        {
            List<User> usersList = await _userRepository.GetUsersList();

            return usersList;
        }
    }

}
