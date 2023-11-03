using MediatR;
using SimpleCRUDApp.Commands;
using SimpleCRUDApp.Models;
using SimpleCRUDApp.Repositories;

namespace SimpleCRUDApp.Handlers
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, bool>
    {
        private readonly IUserRepository _userRepository;

        public DeleteUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            User userToDelete = await GetAndValidateUser(request.UserId);

            userToDelete.Delete();

            return (await _userRepository.SaveChangesAsync());
        }

        public async Task<User> GetAndValidateUser(int userId)
        {
            User? userToDelete = await _userRepository.GetUserById(userId);

            if (userToDelete == null)
            {
                throw new Exception($"User with id = {userId} does not exist!");
            }

            return userToDelete!;
        }
    }

}
