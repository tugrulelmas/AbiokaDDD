using AbiokaDDD.ApplicationService.DTOs;
using System;

namespace AbiokaDDD.ApplicationService.Messaging
{
    public class AddCommentRequest : ServiceRequestBase
    {
        public Guid BoardId { get; set; }

        public Guid ListId { get; set; }

        public Guid CardId { get; set; }

        public CommentDTO Comment { get; set; }
    }
}
