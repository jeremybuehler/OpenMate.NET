using OpenMateNET.Lib;
using System;
using System.Configuration;

namespace OpenMateNET.TestApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var Url = ConfigurationManager.AppSettings["Url"];
            var Password = ConfigurationManager.AppSettings["Password"];
            var ThirdPartySourceId = int.Parse(ConfigurationManager.AppSettings["ThirdPartySourceId"]);

            var DealerEndPointId = 2;

            IOpenMateAPI api = new OpenMateAPI(Url, ThirdPartySourceId, Password);

            var result = api.GetServiceCatalog(DealerEndPointId);

            foreach (var r in result)
            {
                Console.WriteLine("{0} - {1}", r.MajorGroupID, r.MajorGroupDescription);
            }

            Console.ReadKey();
        }
    }
}