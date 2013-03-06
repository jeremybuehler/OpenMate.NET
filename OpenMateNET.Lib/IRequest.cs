using OpenMateNET.Lib.ProcessEventService;
using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace OpenMateNET
{
    public abstract class IRequest<T>
    {
        /// <summary>
        /// The unique identifier for the dealership we're requesting data for.
        /// </summary>
        public int DealerEndpointId { get; set; }

        /// <summary>
        /// The type of OpenMate transaction being requested.
        /// </summary>
        public abstract transactionType TransactionType { get; }

        /// <summary>
        /// A property representing the XML content of a specific request.
        /// </summary>
        internal abstract String XML { get; }

        /// <summary>
        /// Process the xml response from the web service.
        /// </summary>
        internal virtual T ProcessResponse(String xml)
        {
            using (var reader = XmlReader.Create(new StringReader(xml)))
            {
                return (T)new XmlSerializer(typeof(T)).Deserialize(reader);
            }
        }
    }
}