using AbiokaDDD.ApplicationService.DTOs;

namespace AbiokaDDD.ApplicationService.Messaging
{
    public class UpdateBoardRequest : ServiceRequestBase
    {
        public BoardDTO Board { get; set; }
    }
}
