using AbiokaDDD.ApplicationService.DTOs;

namespace AbiokaDDD.ApplicationService.Messaging
{
    public class GetCardResponse : ServiceResponseBase
    {
        public CardDTO Card { get; set; }
    }
}
