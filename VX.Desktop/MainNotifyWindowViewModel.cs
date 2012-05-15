using System;
using System.Windows;
using System.Windows.Media.Animation;
using ExtendedWindowsControls;
using VX.Desktop.Infrastructure;

namespace VX.Desktop
{
    public class MainNotifyWindowViewModel
    {
        private readonly ExtendedNotifyIcon extendedNotifyIcon; // global class scope for the icon as it needs to exist foer the lifetime of the window
        
        private const double Epsilon = .0000000001;
        
        public double Opacity { get; set; }

        public double GridOpacity { get; set; }

        public bool Topmost { get; set; }

        private readonly Storyboard fadeIn;
        private readonly Storyboard fadeOut;

        private bool alreadyMoving;

        public MainNotifyWindowViewModel(Storyboard fadeOut, Storyboard fadeIn)
        {
            this.fadeIn = fadeIn;
            this.fadeOut = fadeOut;
            fadeOut.Completed += GridFadeOutStoryBoardCompleted;
            fadeIn.Completed += GridFadeInStoryBoardCompleted;

            // Create a manager (ExtendedNotifyIcon) for handling interaction with the notification icon and wire up events. 
            extendedNotifyIcon = new ExtendedNotifyIcon();
            extendedNotifyIcon.MouseLeave += extendedNotifyIcon_OnHideWindow;
            extendedNotifyIcon.MouseMove += extendedNotifyIcon_OnMouseMove;
            extendedNotifyIcon.MouseMove += extendedNotifyIcon_OnShowWindow;

            InitTimers();
            // TODO: localize
            extendedNotifyIcon.targetNotifyIcon.Text = "Vocabulary Extender";
            SetNotifyIcon();
        }


        /// <summary>
        /// Once the grid fades out, set the backing window to "not visible"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void GridFadeOutStoryBoardCompleted(object sender, EventArgs e)
        {
            Opacity = 0;
            /*alreadyMoving = false;*/
        }

        /// <summary>
        /// Once the grid fades out, set the backing window to "visible"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void GridFadeInStoryBoardCompleted(object sender, EventArgs e)
        {
            Opacity = 1;
        }

        /// <summary>
        /// When the notification manager requests the popup to be displayed through this event, perform the below actions
        /// </summary>
        private void extendedNotifyIcon_OnShowWindow()
        {
            fadeOut.Stop();
            Opacity = 1; // Show the window (backing)
            Topmost = true; // Very rarely, the window seems to get "buried" behind others, this seems to resolve the problem
            if (GridOpacity > 0 && GridOpacity < 1) // If its animating, just set it directly to visible (avoids flicker and keeps the UX slick)
            {
                GridOpacity = 1;
            }
            else if (Math.Abs(GridOpacity - 0) < Epsilon)
            {
                if (alreadyMoving)
                {
                    return;
                }
                
                alreadyMoving = true;
                fadeIn.Begin();  // If it is in a fully hidden state, begin the animation to show the window
            }
        }

        /// <summary>
        /// When the notification manager requests the popup to be hidden through this event, perform the below actions
        /// </summary>
        void extendedNotifyIcon_OnHideWindow()
        {
            fadeIn.Stop(); // Stop the fade in storyboard if running.

            // Only start fading out if fully faded in, otherwise you get a flicker effect in the UX because the animation resets the opacity
            if (Math.Abs(GridOpacity - 1) < Epsilon && Math.Abs(Opacity - 1) < Epsilon)
                fadeOut.Begin();
            else // Just hide the window and grid
            {
                GridOpacity = 0;
                Opacity = 0;
                alreadyMoving = false;
            }
        }

        private void extendedNotifyIcon_OnMouseMove()
        {
            if (AutomaticPopupDispatcher.Instance.IsTriggeredAutomatically)
            {
                AutomaticPopupDispatcher.Instance.IsTriggeredAutomatically = false;
            }
        }

        private void InitTimers()
        {
            AutomaticPopupDispatcher.Instance.Hide += (sender, args) => extendedNotifyIcon_OnHideWindow();
            AutomaticPopupDispatcher.Instance.Show += (sender, args) => extendedNotifyIcon_OnShowWindow();
            // todo : to config
            AutomaticPopupDispatcher.Instance.ShowTimer.Interval = TimeSpan.FromSeconds(10);
            AutomaticPopupDispatcher.Instance.HideTimer.Interval = TimeSpan.FromSeconds(5);
            AutomaticPopupDispatcher.Instance.StartCountForShow();
        }

        /// <summary>
        /// Pulls an icon from the packed resource and applies it to the NotifyIcon control
        /// </summary>
        private void SetNotifyIcon()
        {
            var resourceInfo = Application.GetResourceStream(new Uri("pack://application:,,/Icons/tray.ico"));
            if (resourceInfo == null)
                throw new ArgumentException("Resource not found", "iconPrefix"); // TODO: localize

            var iconStream = resourceInfo.Stream;
            extendedNotifyIcon.targetNotifyIcon.Icon = new System.Drawing.Icon(iconStream);
        }

        /// <summary>
        /// When the mouse enters the popup window's bounds, cancel any pending closing actions and immediately show the popup. 
        /// This is primarily to handle the case where the mouse termporarily leaves the popup window and returns again - 
        /// a UX / usability enhancement.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void UiWindowMainNotificationMouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            // Cancel the mouse leave event from firing, stop the fade out storyboard from running and enusre the grid is fully visible
            extendedNotifyIcon.StopMouseLeaveEventFromFiring();
            fadeOut.Stop();
            GridOpacity = 1;
            AutomaticPopupDispatcher.Instance.Stop();
        }

        /// <summary>
        /// If the mouse leaves the popup, start the process to close the window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void UiWindowMainNotificationMouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            extendedNotifyIcon_OnHideWindow();
            AutomaticPopupDispatcher.Instance.StartCountForHide();
        }

        /*/// <summary>
        /// Shut down the popup window and dispose the notify icon (otherwise it hangs around in the task bar until you mouse over) 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseButtonClick(object sender, RoutedEventArgs e)
        {
            extendedNotifyIcon.Dispose();
            Close();
        }*/

        /*private void HandleLoadingDelay()
        {
            MainContent.Children.Clear();
            if (currentTask.Refresh())
            {
                MainContent.Children.Add(currentTask);
            }
            else
            {
                MainContent.Children.Add(loadingAnimation);
            }
        }*/
    }
}
