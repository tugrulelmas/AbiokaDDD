using AbiokaDDD.ApplicationService.DTOs;

namespace AbiokaDDD.ApplicationService.Messaging
{
    public class SignUpResponse : ServiceResponseBase
    {
        public UserDTO User { get; set; }
    }
}
