using BananaOS;
using HarmonyLib;
using Photon.Pun;
using Photon.Realtime;
using PlayerJoinandLeaveBANANAOS.Mod;
using UnityEngine;

namespace PlayerJoinandLeaveBANANAOS.Join___Leave
{
    [HarmonyPatch(typeof(MonoBehaviourPunCallbacks), "OnPlayerEnteredRoom")]
    public class JoinPatch
    {
        private static void Prefix(Player newPlayer)
        {
            if (newPlayer != lastJoinedPlayer)
            {
                if (Page.NotisEnabled)
                {
                    BananaNotifications.DisplayNotification("<align=center><size=4>"
                        + newPlayer.NickName.ToLower()
                        + " has joined!", Color.green, Color.white, .7f);
                }
                lastJoinedPlayer = newPlayer;
            }
        }

        private static Player lastJoinedPlayer;
    }
}
