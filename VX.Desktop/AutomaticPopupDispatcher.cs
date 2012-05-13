using System;
using System.Windows.Threading;

namespace VX.Desktop
{
    public sealed class AutomaticPopupDispatcher : IAutomaticPopupDispatcher
    {
        private AutomaticPopupDispatcher()
        {
            showTimer = new DispatcherTimer();
            showTimer.Tick += ShowTimerTick;
            hideTimer = new DispatcherTimer();
            hideTimer.Tick += HideTimerTick;
        }

        static AutomaticPopupDispatcher()
        {
            Instance = new AutomaticPopupDispatcher();
        }

        public static IAutomaticPopupDispatcher Instance { get; set; }

        private readonly DispatcherTimer showTimer = new DispatcherTimer();

        private readonly DispatcherTimer hideTimer = new DispatcherTimer();

        public DispatcherTimer ShowTimer
        {
            get { return showTimer; }
        }

        public DispatcherTimer HideTimer
        {
            get { return hideTimer; }
        }

        public event EventHandler Show;
        public event EventHandler Hide;
        public void StartCountForShow()
        {
            ShowTimer.Start();
            HideTimer.Stop();
        }

        public void StartCountForHide()
        {
            ShowTimer.Stop();
            HideTimer.Start();
        }

        public void Stop()
        {
            ShowTimer.Stop();
            HideTimer.Stop();
        }

        public bool IsTriggeredAutomatically { get; set; }

        private void ShowTimerTick(object sender, EventArgs e)
        {
            IsTriggeredAutomatically = true;
            Show(sender, e);
            StartCountForHide();
        }

        private void HideTimerTick(object sender, EventArgs e)
        {
            if (IsTriggeredAutomatically)
            {
                Hide(sender, e);
            }

            IsTriggeredAutomatically = false;
            StartCountForShow();
        }
    }
}
