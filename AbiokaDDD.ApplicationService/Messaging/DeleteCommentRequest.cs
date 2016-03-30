using System;

namespace AbiokaDDD.ApplicationService.Messaging
{
    public class DeleteCommentRequest : ServiceRequestBase
    {
        public Guid BoardId { get; set; }

        public Guid ListId { get; set; }

        public Guid CardId { get; set; }

        public Guid CommentId { get; set; }
    }
}
