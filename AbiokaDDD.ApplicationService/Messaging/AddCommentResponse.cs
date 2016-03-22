using AbiokaDDD.ApplicationService.DTOs;

namespace AbiokaDDD.ApplicationService.Messaging
{
    public class AddCommentResponse : ServiceResponseBase
    {
        public CommentDTO Comment { get; set; }
    }
}
