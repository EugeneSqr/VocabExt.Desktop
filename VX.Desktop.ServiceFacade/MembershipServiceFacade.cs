using System;
using VX.Desktop.ServiceFacade.AccountMembershipService;
using log4net;

namespace VX.Desktop.ServiceFacade
{
    public sealed class MembershipServiceFacade : IMembershipServiceFacade
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(MembershipServiceFacade));

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
            try
            {
                Logger.InfoFormat("Validing user {0}", userName);
                var userValid = serviceClient.ValidateUser(userName, password);
                Logger.InfoFormat("User {0} valid: {1}", userName, userValid);
                return userValid;
            }
            catch (Exception exception)
            {
                Logger.Error("Error validating user", exception);
                return false;
            }
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
            return serviceClient.GetVocabBanks(username, password);
        }
    }
}
