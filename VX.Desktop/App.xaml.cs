using VX.Desktop.Infrastructure;
using VX.Desktop.ServiceFacade;

namespace VX.Desktop
{
    public partial class App
    {
        public App()
        {
            InitializeComponent();
            CredentialsProvider.Instance.CurrentToken = 
                AuthServiceFacade.Instance.Login("Femel", "femel1");
        }
    }
}