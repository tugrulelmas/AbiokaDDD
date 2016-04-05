using AbiokaDDD.ApplicationService.Abstractions;
using AbiokaDDD.ApplicationService.Map;
using AbiokaDDD.ApplicationService.Messaging;
using AbiokaDDD.Domain;
using AbiokaDDD.Domain.Repositories;
using System;

namespace AbiokaDDD.ApplicationService.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository) {
            this.userRepository = userRepository;
        }

        public SignUpResponse SignUp(SignUpRequest request) {
            var user =  userRepository.GetByEmail(request.Email);
            if (user != null)
                throw new Exception("User is already registered.");

            user = new User
            {
                Name = request.Name,
                Email = request.Email.ToLowerInvariant(),
                AuthProvider = AuthProvider.Local,
                ProviderToken = Guid.NewGuid().ToString(),
                Password = request.Password,
                ImageUrl = request.ImageUrl
            };
            user.Password = user.GetHashedPassword();
            user.Initials = user.GetInitials();
            userRepository.Add(user);

            return new SignUpResponse
            {
                User = user.ToDTO()
            };
        }
    }
}
