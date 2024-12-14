using BananaOS;
using BananaOS.Pages;
using System.Text;
using BepInEx.Configuration;
using BepInEx.Logging;

namespace PlayerJoinandLeaveBANANAOS.Mod
{
    public class Page : WatchPage
    {
        private const string NotisEnabledKey = "AnAusLoggerNotisEnabled";
        private const string LowercaseNamesKey = "AnAusLoggerLowercaseNames";

        public static bool NotisEnabled;
        public static bool LowercaseNames;

        private static ConfigFile config;

        private static readonly ManualLogSource logger = BepInEx.Logging.Logger.CreateLogSource("AnAusLogger");

        public override string Title => NotisEnabled ? "<color=green>AnAusLogger</color>" : "<color=red>AnAusLogger</color>";

        public override bool DisplayOnMainMenu => true;

        public override void OnPostModSetup()
        {
            config = new ConfigFile(System.IO.Path.Combine(BepInEx.Paths.ConfigPath, "AnAusLogger.cfg"), true);
            LoadConfigValues();

            selectionHandler.maxIndex = 1;
        }

        private void LoadConfigValues()
        {
            NotisEnabled = config.Bind("Settings", NotisEnabledKey, true, "Enable AnAusLogger").Value;
            LowercaseNames = config.Bind("Settings", LowercaseNamesKey, true, "Enable Lowercase Names").Value;
        }

        private void SaveConfigValues()
        {
            config.Bind("Settings", NotisEnabledKey, NotisEnabled, "Enable AnAusLogger").Value = NotisEnabled;
            config.Bind("Settings", LowercaseNamesKey, LowercaseNames, "Enable Lowercase Notifications").Value = LowercaseNames;
            config.Save();
        }

        public override string OnGetScreenContent()
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("<color=yellow>==</color> <color=green>AnAusLogger</color> <color=yellow>==</color>");

            stringBuilder.AppendLine(GetStatusText(0, NotisEnabled, "AnAusLogger"));
            stringBuilder.AppendLine(GetStatusText(1, LowercaseNames, "LowercaseNotis"));

            return stringBuilder.ToString();
        }

        private string GetStatusText(int index, bool isEnabled, string settingName)
        {
            string statusText = isEnabled
                ? $"<color=green>\n{settingName} is Enabled</color>\n"
                : $"<color=red>\n{settingName} is Disabled</color>\n";

            return selectionHandler.GetOriginalBananaOSSelectionText(index, statusText);
        }

        public override void OnButtonPressed(WatchButtonType buttonType)
        {
            switch (buttonType)
            {
                case WatchButtonType.Up:
                    selectionHandler.MoveSelectionUp();
                    break;

                case WatchButtonType.Down:
                    selectionHandler.MoveSelectionDown();
                    break;

                case WatchButtonType.Enter:
                    if (selectionHandler.currentIndex == 0)
                    {
                        NotisEnabled = !NotisEnabled;
                        SaveConfigValues(); 
                        return;
                    }

                    if (selectionHandler.currentIndex == 1)
                    {
                        LowercaseNames = !LowercaseNames;
                        SaveConfigValues();
                        return;
                    }
                    break;

                case WatchButtonType.Back:
                    ReturnToMainMenu();
                    break;
            }
        }
    }
}