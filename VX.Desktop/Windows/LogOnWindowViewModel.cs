using System;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Windows.Input;
using System.Windows.Threading;
using VX.Desktop.Infrastructure;
using VX.Desktop.ServiceFacade;

namespace VX.Desktop.Windows
{
    public class LogOnWindowViewModel : INotifyPropertyChanged
    {
        private RelayCommand skipCommand;
        private RelayCommand logonInputCommand;
        private RelayCommand logonCommand;
        private RelayCommand registerCommand;

        private bool isLogonInProgress;

        public event EventHandler RequestClose;

        public event PropertyChangedEventHandler PropertyChanged;

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

        public ICommand LogonCommand
        {
            get { return logonCommand ?? (logonCommand = new RelayCommand(param => Logon())); }
        }

        public ICommand RegisterCommand
        {
            get { return registerCommand ?? (registerCommand = new RelayCommand(param => FollowRegisterUrl())); }
        }

        private void FollowRegisterUrl()
        {
            Process.Start(new ProcessStartInfo(RegisterUrl));
        }

        public string UserInput { get; set; }

        public string PasswordInput { get; set; }

        public bool IsLogonInProgress
        {
            get
            {
                return isLogonInProgress;
            }
            set 
            { 
                isLogonInProgress = value;
                PropertyChanged(this, new PropertyChangedEventArgs("IsLogonInProgress"));
            }
        }

        public string RegisterUrl 
        { 
            get
            {
                // TODO: dependency injection and settings caching
                return ConfigurationManager.AppSettings["RegisterUrl"];
            }
        }

        public string RegisterText
        {
            get
            {
                //TODO: localize
                return "Register";
            }
        }

        public string LogonText
        {
            get
            {
                //TODO: localize
                return "Logon";
            }
        }

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
            ValidationRequestDelegate validationMethod = MembershipServiceFacade.Instance.ValidateUser;
            IsLogonInProgress = true;
            validationMethod.BeginInvoke(UserInput, PasswordInput, ValidationCallbackMethod, validationMethod);
            
        }

        private void ValidationCallbackMethod(IAsyncResult asyncResult)
        {
            var asyncDelegate = (ValidationRequestDelegate)asyncResult.AsyncState;

            Dispatcher.CurrentDispatcher.Invoke(
                DispatcherPriority.Normal, 
                new Action<bool>(ProcessValidationResult), 
                asyncDelegate.EndInvoke(asyncResult));
        }

        private void ProcessValidationResult(bool isValid)
        {
            if (!isValid)
            {
                IsLogonInProgress = false;
                return;
            }

            CredentialsProvider.Instance.User = UserInput;
            CredentialsProvider.Instance.Password = PasswordInput;
            RequestClose(this, null);
        }

        private delegate bool ValidationRequestDelegate(string userInput, string passwordInput);
    }
}
