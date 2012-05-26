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
    }
}
