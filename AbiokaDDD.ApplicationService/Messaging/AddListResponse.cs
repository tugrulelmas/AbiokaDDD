using AbiokaDDD.ApplicationService.DTOs;

namespace AbiokaDDD.ApplicationService.Messaging
{
    public class AddListResponse : ServiceResponseBase
    {
        public ListDTO List { get; set; }
    }
}
