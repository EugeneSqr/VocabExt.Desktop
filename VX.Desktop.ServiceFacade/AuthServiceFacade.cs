using VX.Desktop.ServiceFacade.AuthService;

namespace VX.Desktop.ServiceFacade
{
    public class AuthServiceFacade : IAuthServiceFacade
    {
        private readonly AuthenticationServiceClient serviceClient;

        public AuthServiceFacade()
        {
            serviceClient = new AuthenticationServiceClient();
        }

        public bool IsLoggedOn()
        {
            // only for debugg locally
            var aaa = serviceClient.Login("testuser", "testuser", null, true);
            return serviceClient.IsLoggedIn();
        }

        public bool LogOn()
        {
            throw new System.NotImplementedException();
        }
    }
}
