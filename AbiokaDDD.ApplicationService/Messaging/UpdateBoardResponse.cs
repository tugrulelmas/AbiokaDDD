using AbiokaDDD.ApplicationService.ViewModel;
using System;

namespace AbiokaDDD.ApplicationService.Messaging
{
    public class UpdateBoardResponse : ServiceResponseBase
    {
        public BoardViewModel Board { get; set; }
    }
}
