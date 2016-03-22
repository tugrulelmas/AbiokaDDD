using AbiokaDDD.ApplicationService.DTOs;
using System;

namespace AbiokaDDD.ApplicationService.Messaging
{
    public class AddCardRequest : ServiceRequestBase
    {
        public Guid BoardId { get; set; }

        public Guid ListId { get; set; }

        public CardDTO Card { get; set; }
    }
}
