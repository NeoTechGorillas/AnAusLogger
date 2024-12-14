using BananaOS;
using HarmonyLib;
using Photon.Pun;
using Photon.Realtime;
using PlayerJoinandLeaveBANANAOS.Mod;
using System;
using UnityEngine;

namespace PlayerJoinandLeaveBANANAOS.Join___Leave
{
    [HarmonyPatch(typeof(MonoBehaviourPunCallbacks), "OnPlayerLeftRoom")]
    class LeavePatch
    {
        private static void Postfix(ref Player otherPlayer)
        {
            try
            {
                if (otherPlayer != PhotonNetwork.LocalPlayer && otherPlayer != lastLeftPlayer)
                {
                    if (Page.NotisEnabled)
                    {
                        if (Page.LowercaseNames)
                        {
                            BananaNotifications.DisplayNotification("<align=center><size=4>"
                                + otherPlayer.NickName.ToLower()
                                + " has left.", Color.red, Color.white, .7f);
                        }
                        else
                        {
                            BananaNotifications.DisplayNotification("<align=center><size=4>"
                                + otherPlayer.NickName
                                + " HAS LEFT.", Color.red, Color.white, .7f);
                        }

                    }
                    lastLeftPlayer = otherPlayer;
                }
            }
            catch (Exception e)
            {
                Main.Logger.LogError(e);
            }
        }

        private static Player lastLeftPlayer;
    }
}