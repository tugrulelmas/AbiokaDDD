namespace AbiokaDDD.ApplicationService.Messaging
{
    public class SignUpRequest : ServiceRequestBase
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string ImageUrl { get; set; }

        public string Password { get; set; }
    }
}
