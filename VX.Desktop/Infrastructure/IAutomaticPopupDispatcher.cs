using System;
using System.Windows.Threading;

namespace VX.Desktop.Infrastructure
{
    public interface IAutomaticPopupDispatcher
    {
        DispatcherTimer ShowTimer { get; }

        DispatcherTimer HideTimer { get; }

        event EventHandler Show;

        event EventHandler Hide;

        void StartCountForShow();

        void StartCountForHide();

        void Stop();

        bool IsTriggeredAutomatically { get;set; }
    }
}
