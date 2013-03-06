using System.Collections.Generic;

namespace OpenMateNET.Lib
{
    /// <summary>
    /// Provides a clean, easy-to-use interface for retrieving data from the Open/Mate API
    /// </summary>
    public interface IOpenMateAPI
    {
        /// <summary>
        /// Retrieves a list of open repair orders for the given dealer id.
        /// </summary>
        IEnumerable<Star5.RepairOrderType> GetOpenRepairOrders(int DealerEndpointId);
    }
}