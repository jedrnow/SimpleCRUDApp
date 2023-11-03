using MediatR;
using SimpleCRUDApp.Commands;
using SimpleCRUDApp.Models;
using SimpleCRUDApp.Repositories;

namespace SimpleCRUDApp.Handlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            User newUser = new(request.Name,request.Phone,request.Email);

            await _userRepository.Add(newUser);
            await _userRepository.SaveChangesAsync();

            return newUser.Id;
        }
    }

}
