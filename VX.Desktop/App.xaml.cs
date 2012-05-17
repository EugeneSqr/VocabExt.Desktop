using VX.Desktop.Infrastructure;

namespace VX.Desktop
{
    public partial class App
    {
        public App()
        {
            InitializeComponent();
            Current.Properties[CredentialsProvider.Instance.UserKey] = "Femel";
            Current.Properties[CredentialsProvider.Instance.PasswordKey] = "femel1";
        }
    }
}