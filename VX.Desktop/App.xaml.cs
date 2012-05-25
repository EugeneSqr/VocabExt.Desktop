using VX.Desktop.Windows;

namespace VX.Desktop
{
    public partial class App
    {
        public App()
        {
            InitializeComponent();

            var logOnViewModel = new LogOnWindowViewModel();
            var logOnWindow = new LogOnWindow
                                  {
                                      DataContext = logOnViewModel
                                  };

            logOnViewModel.RequestClose += (sender, args) => logOnWindow.Close();
            logOnWindow.Show();
        }
    }
}