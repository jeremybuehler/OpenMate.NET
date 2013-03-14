using OpenMateNET.Lib.ProcessEventService;
using System;
using System.Collections.Generic;

namespace OpenMateNET.Lib.Requests
{
    public class GetAdvisorConfigRequest : IRequest<IEnumerable<Star5.RepairOrderType>>
    {
        public override transactionType TransactionType { get { return transactionType.GetAdvisorConfig; } }

        internal override String Payload
        {
            get { return String.Empty; }
        }
    }
}