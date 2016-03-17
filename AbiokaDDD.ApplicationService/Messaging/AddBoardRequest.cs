using AbiokaDDD.ApplicationService.ViewModel;
using System;

namespace AbiokaDDD.ApplicationService.Messaging
{
    public class AddBoardRequest : ServiceRequestBase
    {
        public BoardViewModel Board { get; set; }
    }
}
