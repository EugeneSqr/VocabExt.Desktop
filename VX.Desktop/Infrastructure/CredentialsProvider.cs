using System;
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

        public Guid CurrentToken
        {
            get
            {
                return (Guid)Application.Current.Properties["Token"];
            }
            set
            {
                Application.Current.Properties["Token"] = value;
            }
        }
    }
}
