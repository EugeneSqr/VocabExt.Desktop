using VX.Desktop.ServiceFacade.ProfileService;

namespace VX.Desktop.ServiceFacade
{
    public class ProfileServiceFacade : IProfileServiceFacade
    {
        private ProfileServiceFacade()
        {
        }

        static ProfileServiceFacade()
        {
            Instance = new ProfileServiceFacade();
            ServiceClient = new ProfileServiceClient();
        }

        public static IProfileServiceFacade Instance { get; set; }

        private static readonly ProfileServiceClient ServiceClient;

        public void GetProperties()
        {
            var aaa = ServiceClient.GetVocabBanks("Femel");
        }
    }
}
