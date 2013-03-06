using OpenMateNET.Lib.ProcessEventService;
using System;
using System.Collections.Generic;

namespace OpenMateNET.Lib.Requests
{
    public class GetRepairOrderRequest : IRequest<IEnumerable<Star5.RepairOrderType>>
    {
        public override transactionType TransactionType { get { return transactionType.GetRepairOrders; } }

        internal override String Payload
        {
            get { throw new NotImplementedException(); }
        }
    }
}