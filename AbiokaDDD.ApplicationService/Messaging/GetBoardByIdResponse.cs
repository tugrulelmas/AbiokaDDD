using AbiokaDDD.ApplicationService.DTOs;

namespace AbiokaDDD.ApplicationService.Messaging
{
    public class GetBoardByIdResponse : ServiceResponseBase
    {
        public BoardDTO Board { get; set; }
    }
}
