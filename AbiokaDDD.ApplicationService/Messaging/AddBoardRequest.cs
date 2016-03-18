using AbiokaDDD.ApplicationService.DTOs;

namespace AbiokaDDD.ApplicationService.Messaging
{
    public class AddBoardRequest : ServiceRequestBase
    {
        public BoardDTO Board { get; set; }
    }
}
