using System.Windows;

namespace VX.Desktop.Infrastructure
{
    public sealed class CredentialsProvider : ICredentialsProvider
    {
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
        }

        public string Password
        {
            get { return (string)Application.Current.Properties[PasswordKey]; }
        }
    }
}
