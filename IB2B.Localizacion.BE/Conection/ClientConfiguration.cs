using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IB2B.Localizacion.BE.Conection
{
    public partial class ClientConfiguration
    {
        public static ClientConfiguration Default { get { return ClientConfiguration.OneBox; } }

        public static ClientConfiguration OneBox = new ClientConfiguration()
        {
            UriString = "https://demo365v2dcfd3f856d1b6072aos.cloudax.dynamics.com/",
            ActiveDirectoryResource = "https://demo365v2dcfd3f856d1b6072aos.cloudax.dynamics.com",
            ActiveDirectoryTenant = "https://login.windows.net/insideb2b.com",
            ActiveDirectoryClientAppId = "7c9efebd-d6fc-4ec8-b689-a4398b695ee4",
        };

        public string UriString { get; set; }
        public string ActiveDirectoryResource { get; set; }
        public String ActiveDirectoryTenant { get; set; }
        public String ActiveDirectoryClientAppId { get; set; }
        public string ODataEndpointUri { get; set; }
    }
}
