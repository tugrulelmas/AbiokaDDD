using AbiokaDDD.ApplicationService.DTOs;
using System;

namespace AbiokaDDD.ApplicationService.Messaging
{
    public class AddLabelRequest : ServiceRequestBase
    {
        public Guid BoardId { get; set; }

        public Guid ListId { get; set; }

        public Guid CardId { get; set; }

        public LabelDTO Label { get; set; }
    }
}
