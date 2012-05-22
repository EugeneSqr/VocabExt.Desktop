using System;
using VX.Desktop.ServiceFacade.AuthService;

namespace VX.Desktop.ServiceFacade
{
    public sealed class AuthServiceFacade : IAuthServiceFacade
    {
        private AuthServiceFacade()
        {
            serviceClient = new AuthServiceClient();
        }

        static AuthServiceFacade()
        {
            Instance = new AuthServiceFacade();
        }

        public static IAuthServiceFacade Instance { get; set; }

        private readonly AuthServiceClient serviceClient;

        public Guid Login(string userName, string password)
        {
            return serviceClient.Login(userName, password);
        }
    }
}
