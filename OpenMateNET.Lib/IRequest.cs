using OpenMateNET.Lib.ProcessEventService;
using System;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace OpenMateNET
{
    public abstract class IRequest<T>
    {
        internal static readonly XmlSerializer Serializer = new XmlSerializer(typeof(T));

        public abstract transactionType TransactionType { get; }

        /// <summary>
        /// A property representing the XML content of a specific request.
        /// </summary>
        internal abstract String XML { get; }

        /// <summary>
        /// Process the xml response from the web service.
        /// </summary>
        internal virtual T ProcessResponse(XmlElement xml)
        {
            using (var reader = XmlReader.Create(new StringReader(xml.OuterXml)))
            {
                return (T)Serializer.Deserialize(reader);
            }
        }
    }

    public class GetRepairOrderRequest : IRequest<Star5.RepairOrderType>
    {
        public override transactionType TransactionType { get { return transactionType.GetRepairOrders; } }

        internal override String XML
        {
            get { throw new NotImplementedException(); }
        }
    }
}