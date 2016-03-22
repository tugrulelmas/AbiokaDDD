using AbiokaDDD.ApplicationService.DTOs;

namespace AbiokaDDD.ApplicationService.Messaging
{
    public class AddCardResponse : ServiceResponseBase
    {
        public CardDTO Card { get; set; }
    }
}
