using System;
using System.Windows;
using System.Windows.Threading;
using VX.Desktop.Windows;
using log4net;

namespace VX.Desktop
{
    public partial class App
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(App));
        
        private readonly LogOnWindow logOnWindow;
        private readonly MainNotifyWindow mainNotifyWindow;
        
        public App()
        {
            Logger.Info("Application start. Initializing components.");
            InitializeComponent();

            Logger.Info("Creating logon window");
            logOnWindow = new LogOnWindow();
            Logger.Info("Creating main notify window");
            mainNotifyWindow = new MainNotifyWindow();
            mainNotifyWindow.Closing += CloseAllWindowsHandler;

            var logOnViewModel = new LogOnWindowViewModel();
            logOnWindow.DataContext = logOnViewModel;
            logOnViewModel.RequestClose += CloseLogonWindowHandler;
            Logger.Info("Show logon window");
            logOnWindow.Show();
        }

        private void CloseLogonWindowHandler(object sender, EventArgs e)
        {
            Logger.Info("Hide logon window");
            Dispatcher.Invoke(
                DispatcherPriority.Normal, 
                new Action<Window>(window => window.Hide()), 
                logOnWindow);
        }

        private void CloseAllWindowsHandler(object sender, EventArgs e)
        {
            Logger.Info("Close all windows method has been invoked");
            logOnWindow.Close();
        }
    }
}