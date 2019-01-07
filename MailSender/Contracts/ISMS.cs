using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageSender.Contracts
{
    public interface ISMS
    {
        string TwilioRestSID { get; }
        string TwilioRestPassword { get; }
        string DestinationNumber { get; }
        string MessageBody { get; set; }
    }
}
