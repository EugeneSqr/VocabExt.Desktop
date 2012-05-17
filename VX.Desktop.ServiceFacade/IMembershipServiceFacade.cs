using VX.Desktop.ServiceFacade.AccountMembershipService;

namespace VX.Desktop.ServiceFacade
{
    public interface IMembershipServiceFacade
    {
        int GetMinPasswordLength();
     
        bool ValidateUser(string userName, string password);
        
        MembershipCreateStatus CreateUser(string userName, string password, string email);
        
        bool ChangePassword(string userName, string oldPassword, string newPassword);
        
        int[] GetVocabBanks(string username, string password);
    }
}
