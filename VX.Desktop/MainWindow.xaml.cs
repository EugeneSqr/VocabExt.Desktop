using System;
using System.Windows.Threading;
using VX.Desktop.ServiceFacade;

namespace VX.Desktop
{
    public partial class MainWindow
    {
        private const int DefaultTimerIntervalMinutes = 15;
        private readonly DispatcherTimer notifyTimer = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();
            InitTimer();
            Hide();
        }

        private void InitTimer()
        {
            notifyTimer.Tick += Notify;
            notifyTimer.Interval = new TimeSpan(0, DefaultTimerIntervalMinutes, 0);
            notifyTimer.Start();
        }

        private void Notify(object sender, EventArgs e)
        {
            taskbarIcon.ShowBalloonTip("VocabExt", "Time to learn English", taskbarIcon.Icon);
        }

        private void MenuExitClick(object sender, System.Windows.RoutedEventArgs e)
        {
            Close();
        }

        private void MenuConfigureClick(object sender, System.Windows.RoutedEventArgs e)
        {
            AuthServiceFacade facade = new AuthServiceFacade();
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            taskbarIcon.Dispose();
            base.OnClosing(e);
        }
    }
}