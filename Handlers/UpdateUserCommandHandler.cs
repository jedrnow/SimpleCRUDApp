using MediatR;
using SimpleCRUDApp.Commands;
using SimpleCRUDApp.Models;
using SimpleCRUDApp.Repositories;

namespace SimpleCRUDApp.Handlers
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, bool>
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            User userToUpdate = await GetAndValidateUser(request.UserId);

            userToUpdate.Update(request.Name, request.Phone, request.Email);

            await _userRepository.SaveChangesAsync();

            return (await _userRepository.SaveChangesAsync());
        }

        public async Task<User> GetAndValidateUser(int userId)
        {
            User? userToUpdate = await _userRepository.GetUserById(userId);

            if (userToUpdate == null)
            {
                throw new Exception($"User with id = {userId} does not exist!");
            }

            return userToUpdate!;
        }
    }
}
