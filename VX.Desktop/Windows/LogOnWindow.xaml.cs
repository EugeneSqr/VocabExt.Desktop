namespace VX.Desktop.Windows
{
    public partial class LogOnWindow
    {
        public LogOnWindow()
        {
            InitializeComponent();
        }

        private void LogonInput(object sender, System.Windows.Input.KeyEventArgs e)
        {
            ((LogOnWindowViewModel)DataContext).LogonInputCommand.Execute(e);
        }
    }
}
