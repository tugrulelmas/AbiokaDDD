using AbiokaDDD.ApplicationService.ViewModel;

namespace AbiokaDDD.ApplicationService.Messaging
{
    public class AddBoardResponse : ServiceResponseBase
    {
        public BoardViewModel Board { get; set; }
    }
}
