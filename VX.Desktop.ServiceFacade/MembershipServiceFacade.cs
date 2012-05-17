using VX.Desktop.ServiceFacade.AccountMembershipService;

namespace VX.Desktop.ServiceFacade
{
    public sealed class MembershipServiceFacade : IMembershipServiceFacade
    {
        private MembershipServiceFacade()
        {
            serviceClient = new MembershipServiceClient();
        }

        static MembershipServiceFacade()
        {
            Instance = new MembershipServiceFacade();
        }

        public static IMembershipServiceFacade Instance { get; set; }

        private readonly MembershipServiceClient serviceClient;

        public int GetMinPasswordLength()
        {
            return serviceClient.GetMinPasswordLength();
        }

        public bool ValidateUser(string userName, string password)
        {
            return serviceClient.ValidateUser(userName, password);
        }

        public MembershipCreateStatus CreateUser(string userName, string password, string email)
        {
            return serviceClient.CreateUser(userName, password, email);
        }

        public bool ChangePassword(string userName, string oldPassword, string newPassword)
        {
            return serviceClient.ChangePassword(userName, oldPassword, newPassword);
        }

        public int[] GetVocabBanks(string username, string password)
        {
            /*try
            {*/
                return serviceClient.GetVocabBanks(username, password);
            /*}
            catch (FaultException)
            {
                return new int[] { };
            }*/
        }
    }
}
