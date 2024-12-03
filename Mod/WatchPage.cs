using BananaOS;
using BananaOS.Pages;
using System.Text;

namespace PlayerJoinandLeaveBANANAOS.Mod
{
    public class Page : WatchPage
    {
        public override string Title => NotisEnabled ? "<color=green>AnAusLogger</color>" : "<color=red>AnAusLogger</color>";

        public static bool NotisEnabled = true;
        public override bool DisplayOnMainMenu => true;

        public override void OnPostModSetup()
        {
            selectionHandler.maxIndex = 0;
        }

        public override string OnGetScreenContent()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("<color=yellow>==</color> <color=green>AnAusLogger</color> <color=yellow>==</color>");
            stringBuilder.AppendLine(selectionHandler.GetOriginalBananaOSSelectionText(0, NotisEnabled ? "<color=green>AnAusLogger is Enabled</color>\n" : "<color=red>AnAusLogger is Disabled</color>\n"));
            return stringBuilder.ToString();
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