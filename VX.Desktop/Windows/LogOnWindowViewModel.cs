using System;
using System.Windows.Input;
using VX.Desktop.Infrastructure;
using VX.Desktop.ServiceFacade;

namespace VX.Desktop.Windows
{
    public class LogOnWindowViewModel
    {
        private RelayCommand skipCommand;
        private RelayCommand logonInputCommand;

        public event EventHandler RequestClose;

        public ICommand SkipCommand
        {
            get
            {
                return skipCommand ?? (skipCommand = new RelayCommand(param => Skip(), param => true));
            }
        }

        public ICommand LogonInputCommand
        {
            get { return logonInputCommand ?? (logonInputCommand = new RelayCommand(param => LogonNameInput((KeyEventArgs)param))); }
        }
        
        public string UserInput { get; set; }

        public string PasswordInput { get; set; }

        private void Skip()
        {
            CredentialsProvider.Instance.EmptyUser();
            RequestClose(this, null);
        }

        private void LogonNameInput(KeyEventArgs args)
        {
            if (args.Key == Key.Enter)
            {
                Logon();
            }
        }

        private void Logon()
        {
            if (!MembershipServiceFacade.Instance.ValidateUser(UserInput, PasswordInput))
            {
                return;
            }

            CredentialsProvider.Instance.User = UserInput;
            CredentialsProvider.Instance.Password = PasswordInput;
            RequestClose(this, null);
        }
    }
}
