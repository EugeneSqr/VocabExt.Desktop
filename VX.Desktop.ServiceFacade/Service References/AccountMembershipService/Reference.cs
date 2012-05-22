﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.261
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VX.Desktop.ServiceFacade.AccountMembershipService {
    using System.Runtime.Serialization;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="MembershipCreateStatus", Namespace="http://schemas.datacontract.org/2004/07/System.Web.Security")]
    public enum MembershipCreateStatus : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Success = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        InvalidUserName = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        InvalidPassword = 2,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        InvalidQuestion = 3,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        InvalidAnswer = 4,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        InvalidEmail = 5,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        DuplicateUserName = 6,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        DuplicateEmail = 7,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        UserRejected = 8,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        InvalidProviderUserKey = 9,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        DuplicateProviderUserKey = 10,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        ProviderError = 11,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="AccountMembershipService.IMembershipService")]
    public interface IMembershipService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMembershipService/GetMinPasswordLength", ReplyAction="http://tempuri.org/IMembershipService/GetMinPasswordLengthResponse")]
        int GetMinPasswordLength();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMembershipService/ValidateUser", ReplyAction="http://tempuri.org/IMembershipService/ValidateUserResponse")]
        bool ValidateUser(string userName, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMembershipService/CreateUser", ReplyAction="http://tempuri.org/IMembershipService/CreateUserResponse")]
        VX.Desktop.ServiceFacade.AccountMembershipService.MembershipCreateStatus CreateUser(string userName, string password, string email);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMembershipService/ChangePassword", ReplyAction="http://tempuri.org/IMembershipService/ChangePasswordResponse")]
        bool ChangePassword(string userName, string oldPassword, string newPassword);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMembershipService/GetVocabBanks", ReplyAction="http://tempuri.org/IMembershipService/GetVocabBanksResponse")]
        int[] GetVocabBanks(string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMembershipService/GetVocabBanksCurrentUser", ReplyAction="http://tempuri.org/IMembershipService/GetVocabBanksCurrentUserResponse")]
        int[] GetVocabBanksCurrentUser();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMembershipService/PostVocabBanks", ReplyAction="http://tempuri.org/IMembershipService/PostVocabBanksResponse")]
        bool PostVocabBanks(System.IO.Stream data);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IMembershipServiceChannel : VX.Desktop.ServiceFacade.AccountMembershipService.IMembershipService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class MembershipServiceClient : System.ServiceModel.ClientBase<VX.Desktop.ServiceFacade.AccountMembershipService.IMembershipService>, VX.Desktop.ServiceFacade.AccountMembershipService.IMembershipService {
        
        public MembershipServiceClient() {
        }
        
        public MembershipServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public MembershipServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MembershipServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MembershipServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public int GetMinPasswordLength() {
            return base.Channel.GetMinPasswordLength();
        }
        
        public bool ValidateUser(string userName, string password) {
            return base.Channel.ValidateUser(userName, password);
        }
        
        public VX.Desktop.ServiceFacade.AccountMembershipService.MembershipCreateStatus CreateUser(string userName, string password, string email) {
            return base.Channel.CreateUser(userName, password, email);
        }
        
        public bool ChangePassword(string userName, string oldPassword, string newPassword) {
            return base.Channel.ChangePassword(userName, oldPassword, newPassword);
        }
        
        public int[] GetVocabBanks(string username, string password) {
            return base.Channel.GetVocabBanks(username, password);
        }
        
        public int[] GetVocabBanksCurrentUser() {
            return base.Channel.GetVocabBanksCurrentUser();
        }
        
        public bool PostVocabBanks(System.IO.Stream data) {
            return base.Channel.PostVocabBanks(data);
        }
    }
}
