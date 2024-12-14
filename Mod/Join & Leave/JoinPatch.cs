using BananaOS;
using HarmonyLib;
using Photon.Pun;
using Photon.Realtime;
using PlayerJoinandLeaveBANANAOS.Mod;
using System;
using UnityEngine;

namespace PlayerJoinandLeaveBANANAOS.Join___Leave
{
    [HarmonyPatch(typeof(MonoBehaviourPunCallbacks), "OnPlayerEnteredRoom")]
    public class JoinPatch
    {
        private static void Postfix(ref Player newPlayer)
        {
            try
            {
                if (newPlayer != lastJoinedPlayer)
                {
                    if (Page.NotisEnabled)
                    {
                        if (Page.LowercaseNames)
                        {
                            BananaNotifications.DisplayNotification("<align=center><size=4>"
                                + newPlayer.NickName.ToLower()
                                + " has joined!", Color.green, Color.white, .7f);
                        }
                        else
                        {
                            BananaNotifications.DisplayNotification("<align=center><size=4>"
                                + newPlayer.NickName
                                + " HAS JOINED!", Color.green, Color.white, .7f);
                        }

                    }
                    lastJoinedPlayer = newPlayer;
                }
            }
            catch (Exception e)
            {
                Main.Logger.LogError(e);
            }
        }

        private static Player lastJoinedPlayer;
    }
}