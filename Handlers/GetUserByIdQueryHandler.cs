using MediatR;
using SimpleCRUDApp.Models;
using SimpleCRUDApp.Queries;
using SimpleCRUDApp.Repositories;

namespace SimpleCRUDApp.Handlers
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, User>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByIdQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            User? userById = await _userRepository.GetUserById(request.UserId);

            if(userById == null)
            {
                throw new Exception($"User with id = {request.UserId} does not exist!");
            }

            return userById!;
        }
    }

}
