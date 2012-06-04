using System.Configuration;
using VX.Desktop.ServiceFacade;

namespace VX.Desktop.Infrastructure
{
    public sealed class ApplicationSettings : IApplicationSettings
    {
        private const string PopupIntervalMinutesKey = "PopupIntervalMinutes";
        
        private ApplicationSettings()
        {
        }

        static ApplicationSettings()
        {
            Instance = new ApplicationSettings();
        }

        public static IApplicationSettings Instance { get; set; }

        public int PoputIntervalMinutes
        {
            get { return int.Parse(ConfigurationManager.AppSettings.Get(PopupIntervalMinutesKey)); }
        }
    }
}
