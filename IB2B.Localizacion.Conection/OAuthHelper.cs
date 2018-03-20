using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IB2B.Localizacion.Conection
{
    public class OAuthHelper
    {
        /// <summary>
        /// The header to use for OAuth.
        /// </summary>
        public const string OAuthHeader = "Authorization";

        /// <summary>
        /// Retrieves an authentication header from the service.
        /// </summary>
        /// <returns>The authentication header for the Web API call.</returns>
        public static string GetAuthenticationHeader(bool useWebAppAuthentication = false)
        {
            try
            {
                string aadTenant = ClientConfiguration.Default.ActiveDirectoryTenant;
                string aadClientAppId = ClientConfiguration.Default.ActiveDirectoryClientAppId;
                string aadResource = ClientConfiguration.Default.ActiveDirectoryResource;

                AuthenticationResult authenticationResult;

                var authenticationContext = new AuthenticationContext(aadTenant, TokenCache.DefaultShared);

                authenticationResult = authenticationContext.AcquireTokenAsync(aadResource, aadClientAppId, new Uri("https://demo365v2dcfd3f856d1b6072aos.cloudax.dynamics.com/"), new PlatformParameters(PromptBehavior.Auto)).Result;

                // Create and get JWT token
                return authenticationResult.CreateAuthorizationHeader();
            }
            catch (Exception eee)
            {
                String msj = eee.InnerException.Message;
                return msj;
            }
        }
    }
}
