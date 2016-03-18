using AbiokaDDD.ApplicationService.DTOs;

namespace AbiokaDDD.ApplicationService.Messaging
{
    public class UpdateBoardResponse : ServiceResponseBase
    {
        public BoardDTO Board { get; set; }
    }
}
