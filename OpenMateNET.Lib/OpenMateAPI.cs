using OpenMateNET.Lib.ProcessEventService;
using OpenMateNET.Lib.Requests;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace OpenMateNET.Lib
{
    /// <summary>
    /// Basic implementation for pulling data from the web service and parsing it into the correct, usable objects.
    /// </summary>
    public class OpenMateAPI : IOpenMateAPI
    {
        // What version of the STAR standard we use.
        public const String PAYLOAD_VERSION = "STAR-5.5.4";

        /// <summary>
        /// The Url of the web service end point
        /// </summary>
        public String Url { get; private set; }

        /// <summary>
        /// The username to authenticate with the web service.
        /// </summary>
        public int ThirdPartySourceId { get; private set; }

        /// <summary>
        /// The password to authenticate with the web service.
        /// </summary>
        public String Password { get; private set; }

        public OpenMateAPI(String Url, int ThirdPartySourceId, String Password, int ThirdPartyId)
        {
            this.Url = Url;
            this.ThirdPartySourceId = ThirdPartySourceId;
            this.Password = Password;
        }

        public IEnumerable<Star5.RepairOrderType> GetOpenRepairOrders(int DealerEndpointId)
        {
            var request = new GetRepairOrderRequest()
            {
                DealerEndpointId = DealerEndpointId
            };

            return Request(request);
        }

        public virtual T Request<T>(IRequest<T> request)
        {
            using (var svc = GetService())
            {
                processEventResult response = svc.processEvent(

                    // Add in the authentication info
                    new authenticationToken()
                    {
                        userName = this.ThirdPartySourceId.ToString(),
                        password = this.Password
                    },
                    this.ThirdPartySourceId,

                    // Which dealership to target
                    request.DealerEndpointId,

                    // Which transaction to run
                    request.TransactionType,

                    // The data to be processed
                    request.XML,

                    // Payload versioning information
                    PAYLOAD_VERSION
                );

                // Check the response for errors and handle them as necessary.
                CheckErrors(response);

                // Process the response.
                return request.ProcessResponse(response.response);
            }
        }

        internal virtual void CheckErrors(processEventResult result)
        {
            /*
                <ns2:processEventResult>
                <!-- Response Payload -->
                <response>Request unauthorized</response>
                <!-- Was the event rejected due to a business validation problem? -->
                <businessError>true</businessError>
                <!-- Was the event rejected due to a system problem? -->
                <systemError>false</systemError>
                <!-- Should this event be reposted? -->
                <retryable>false</retryable>
                <!-- What was the specific problem with the event? SUCCESS if none. -->
                <statusCode>PERMISSION_DENIED</statusCode>
                </ns2:processEventResult>
            */

            // Check the status codes.
            if (result.statusCode == processEventStatusCode.ENDPOINT_FAILURE)
            {
            }

            // Check for a system error.
            if (result.systemError)
            {
            }

            // Check for a business error.
            if (result.businessError)
            {
            }

            if (result.retryable)
            {
                // Re-send it.
            }

            // Otherwise the request was successful, move on.
        }

        internal virtual ProcessEventClient GetService()
        {
            var binding = new BasicHttpBinding()
            {
                // We could be getting back a lot of data, let's just max it out.
                MaxReceivedMessageSize = int.MaxValue
            };

            return new ProcessEventClient(binding, new EndpointAddress(this.Url));
        }
    }
}