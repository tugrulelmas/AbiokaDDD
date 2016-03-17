using AbiokaDDD.ApplicationService.ViewModel;
using System;

namespace AbiokaDDD.ApplicationService.Messaging
{
    public class UpdateBoardRequest : ServiceRequestBase
    {
        public BoardViewModel Board { get; set; }
    }
}
