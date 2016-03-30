using System;

namespace AbiokaDDD.ApplicationService.Messaging
{
    public class GetCardRequest : ServiceRequestBase
    {
        public Guid BoardId { get; set; }

        public Guid ListId { get; set; }

        public Guid CardId { get; set; }
    }
}
