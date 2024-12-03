using BananaOS;
using HarmonyLib;
using Photon.Pun;
using Photon.Realtime;
using PlayerJoinandLeaveBANANAOS.Mod;
using UnityEngine;

namespace PlayerJoinandLeaveBANANAOS.Join___Leave
{
    [HarmonyPatch(typeof(MonoBehaviourPunCallbacks), "OnPlayerLeftRoom")]
    public class LeavePatch
    {
        private static void Prefix(Player otherPlayer)
        {
            if (otherPlayer != PhotonNetwork.LocalPlayer && otherPlayer != lastLeftPlayer)
            {
                if (Page.NotisEnabled)
                {
                    BananaNotifications.DisplayNotification("<align=center><size=4>"
                        + otherPlayer.NickName.ToLower()
                        + " has left.", Color.red, Color.white, .7f);
                }
                lastLeftPlayer = otherPlayer;
            }
        }

        private static Player lastLeftPlayer;
    }
}
