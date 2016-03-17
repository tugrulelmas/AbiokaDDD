using System;

namespace AbiokaDDD.ApplicationService.Messaging
{
    public class GetBoardByIdRequest : ServiceRequestBase
    {
        public Guid BoardId { get; set; }
    }
}
