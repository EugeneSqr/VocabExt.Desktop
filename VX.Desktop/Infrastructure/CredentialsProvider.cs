using System.Windows;

namespace VX.Desktop.Infrastructure
{
    public sealed class CredentialsProvider : ICredentialsProvider
    {
        private const string EmptyUserString = "";
        private const string EmptyPasswordString = "";
        
        private CredentialsProvider()
        {
        }

        static CredentialsProvider()
        {
            Instance = new CredentialsProvider();
        }

        public static ICredentialsProvider Instance { get; set; }

        public string UserKey
        {
            get { return "user"; }
        }

        public string PasswordKey
        {
            get { return "pass"; }
        }

        public string User
        {
            get { return (string)Application.Current.Properties[UserKey]; }
            set { Application.Current.Properties[UserKey] = value; }
        }

        public string Password
        {
            get { return (string)Application.Current.Properties[PasswordKey]; }
            set { Application.Current.Properties[PasswordKey] = value; }
        }

        public void EmptyUser()
        {
            User = EmptyUserString;
            Password = EmptyPasswordString;
        }
    }
}
