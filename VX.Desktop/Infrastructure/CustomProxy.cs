using System;
using System.Configuration;
using System.Net;
using log4net;

namespace VX.Desktop.Infrastructure
{
    public class CustomProxy : IWebProxy
    {
        private const string CustomProxyAddressKey = "CustomProxyAddress";
        private const string CustomProxyUserKey = "CustomProxyUser";
        private const string CustomProxyPassword = "CustomProxyPassword";

        private readonly ILog logger = LogManager.GetLogger(typeof (CustomProxy));
        
        public Uri GetProxy(Uri destination)
        {
            var proxyAddress = string.Empty;
            try
            {
                proxyAddress = ConfigurationManager.AppSettings[CustomProxyAddressKey];
                logger.InfoFormat("Proxy address: {0}", proxyAddress);
            }
            catch (Exception)
            {
                logger.Error("Error retrieving CustomProxyAddress from configuration file. Make sure you have a corresponding key in appSettings section of application config file.");
            }
            
            return new Uri(proxyAddress);
        }

        public bool IsBypassed(Uri host)
        {
            logger.InfoFormat("IsBypassed for host: {0} is false", host);
            return false;
        }

        public ICredentials Credentials
        {
            get
            {
                var userName = string.Empty;
                var password = string.Empty;
                try
                {
                    logger.InfoFormat("Getting proxy credentials");
                    userName = ConfigurationManager.AppSettings[CustomProxyUserKey];
                    password = ConfigurationManager.AppSettings[CustomProxyPassword];
                    logger.InfoFormat("Done. {0}", userName);
                }
                catch (Exception)
                {
                    logger.Error("Error retrieving proxy credentials from configuration file. Make sure you have corresponding keys in appSettings section of application config file.");
                }

                return new NetworkCredential(userName, password);
            }
            set { }
        }
    }
}
