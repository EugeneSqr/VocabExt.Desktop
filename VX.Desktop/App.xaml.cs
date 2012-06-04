using System;
using System.Windows;
using System.Windows.Threading;
using VX.Desktop.Windows;

namespace VX.Desktop
{
    public partial class App
    {
        private readonly LogOnWindow logOnWindow;
        
        public App()
        {
            InitializeComponent();

            logOnWindow = new LogOnWindow();
            var logOnViewModel = new LogOnWindowViewModel();
            logOnWindow.DataContext = logOnViewModel;
            logOnViewModel.RequestClose += CloseWindowHandler;
            logOnWindow.Show();
        }

        private void CloseWindowHandler(object sender, EventArgs e)
        {
            Dispatcher.Invoke(
                DispatcherPriority.Normal, 
                new Action<Window>(window => window.Hide()), 
                logOnWindow);
        }
    }
}