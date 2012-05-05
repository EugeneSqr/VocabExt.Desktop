using VX.Desktop.ServiceFacade.AuthService;

namespace VX.Desktop.ServiceFacade
{
    public sealed class AuthServiceFacade : IAuthServiceFacade
    {
        private AuthServiceFacade()
        {
        }

        static AuthServiceFacade()
        {
            Instance = new AuthServiceFacade();
            ServiceClient = new AuthenticationServiceClient();
        }

        public static IAuthServiceFacade Instance { get; set; }

        private static readonly AuthenticationServiceClient ServiceClient;

        private static bool isLoggenOn;

        public bool IsLoggedOn()
        {
            return isLoggenOn;
        }

        public bool LogOn()
        {
            isLoggenOn = ServiceClient.Login("testuser", "testuser", null, true);
            return isLoggenOn;
        }

        public bool LogOut()
        {
            ServiceClient.Logout();
            isLoggenOn = false;
            return isLoggenOn;
        }
    }
}
