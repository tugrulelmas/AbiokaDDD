using AbiokaDDD.ApplicationService.DTOs;

namespace AbiokaDDD.ApplicationService.Messaging
{
    public class AddBoardResponse : ServiceResponseBase
    {
        public BoardDTO Board { get; set; }
    }
}
