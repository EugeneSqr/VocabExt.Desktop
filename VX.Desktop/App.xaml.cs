using System;
using System.Windows;
using System.Windows.Threading;
using VX.Desktop.Windows;

namespace VX.Desktop
{
    public partial class App
    {
        private readonly LogOnWindow logOnWindow;
        private readonly MainNotifyWindow mainNotifyWindow;
        
        public App()
        {
            InitializeComponent();

            logOnWindow = new LogOnWindow();
            mainNotifyWindow = new MainNotifyWindow();
            mainNotifyWindow.Closing += CloseAllWindowsHandler;

            var logOnViewModel = new LogOnWindowViewModel();
            logOnWindow.DataContext = logOnViewModel;
            logOnViewModel.RequestClose += CloseLogonWindowHandler;
            logOnWindow.Show();
        }

        private void CloseLogonWindowHandler(object sender, EventArgs e)
        {
            Dispatcher.Invoke(
                DispatcherPriority.Normal, 
                new Action<Window>(window => window.Hide()), 
                logOnWindow);
        }

        private void CloseAllWindowsHandler(object sender, EventArgs e)
        {
            logOnWindow.Close();
        }
    }
}