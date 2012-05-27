using System.Windows.Controls;
using System.Windows.Input;

namespace VX.Desktop.Windows
{
    public partial class LogOnWindow
    {
        public LogOnWindow()
        {
            InitializeComponent();
        }

        private void LogonInput(object sender, KeyEventArgs e)
        {
            ((LogOnWindowViewModel)DataContext).LogonInputCommand.Execute(e);
        }

        private void PasswordChanged(object sender, System.Windows.RoutedEventArgs e)
        {
            ((LogOnWindowViewModel)DataContext).PasswordInput = ((PasswordBox)sender).Password;
        }

        private void RegisterHandler(object sender, System.Windows.RoutedEventArgs e)
        {
            ((LogOnWindowViewModel)DataContext).RegisterCommand.Execute(null);
        }
    }
}
