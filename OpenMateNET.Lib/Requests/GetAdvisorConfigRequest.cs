using OpenMateNET.Lib.ProcessEventService;
using System;

namespace OpenMateNET.Lib.Requests
{
    public class GetAdvisorConfigRequest : IRequest<LaborOperationCodes>
    {
        public override transactionType TransactionType { get { return transactionType.GetAdvisorConfig; } }

        internal override String Payload { get { return String.Empty; } }
    }

    public class GetSalespersonConfigRequest : IRequest<LaborOperationCodes>
    {
        public override transactionType TransactionType { get { return transactionType.GetSalespersonConfig; } }

        internal override String Payload { get { return String.Empty; } }
    }

    public class GetServiceCatalogRequest : IRequest<LaborOperationCodes>
    {
        public override transactionType TransactionType { get { return transactionType.GetServiceCatalog; } }

        internal override String Payload { get { return String.Empty; } }
    }
}