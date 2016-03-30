using AbiokaDDD.ApplicationService.DTOs;

namespace AbiokaDDD.ApplicationService.Messaging
{
    public class AddLabelResponse : ServiceResponseBase
    {
        public LabelDTO Label { get; set; }
    }
}
