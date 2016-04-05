using AbiokaDDD.ApplicationService.Messaging;

namespace AbiokaDDD.ApplicationService.Abstractions
{
    public interface IUserService
    {
        SignUpResponse SignUp(SignUpRequest request);
    }
}
