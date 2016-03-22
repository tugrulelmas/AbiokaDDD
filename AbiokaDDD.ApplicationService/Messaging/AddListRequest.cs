using AbiokaDDD.ApplicationService.DTOs;
using System;

namespace AbiokaDDD.ApplicationService.Messaging
{
    public class AddListRequest : ServiceRequestBase
    {
        public Guid BoardId { get; set; }

        public ListDTO List { get; set; }
    }
}
