using System.Collections.Generic;

namespace OpenMateNET.Lib
{
    /// <summary>
    /// Provides a clean, easy-to-use interface for retrieving data from the Open/Mate API
    /// </summary>
    public interface IOpenMateAPI
    {
        /// <summary>
        /// Returns a list of configured services for the dealer
        /// </summary>
        IEnumerable<LaborOperationCodesMajorGroup> GetServiceCatalog(int DealerEndpointId);
    }
}