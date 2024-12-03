﻿using System.Reflection;
using HarmonyLib;

namespace PlayerJoinandLeaveBANANAOS.Patches
{
    public class HarmonyPatches
    {
        private static readonly Harmony instance = new Harmony(ModInfo.GUID);

        public static bool IsPatched { get; private set; }

        internal static void ApplyHarmonyPatches()
        {
            if (IsPatched) return;

            instance.PatchAll(Assembly.GetExecutingAssembly());
            IsPatched = true;
        }

        internal static void RemoveHarmonyPatches()
        {
            if (!IsPatched) return;

            instance.UnpatchSelf();
            IsPatched = false;
        }
    }
}