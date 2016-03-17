using AbiokaDDD.ApplicationService.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbiokaDDD.ApplicationService.Messaging
{
    public class GetBoardByIdResponse : ServiceResponseBase
    {
        public BoardViewModel Board { get; set; }
    }
}
