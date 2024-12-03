using BepInEx;
using PlayerJoinandLeaveBANANAOS.Patches;

namespace PlayerJoinandLeaveBANANAOS.Mod
{
    [BepInPlugin(ModInfo.GUID, ModInfo.Name, ModInfo.Version)]
    public class Main : BaseUnityPlugin
    {
        private static BepInEx.Logging.ManualLogSource _logger = new BepInEx.Logging.ManualLogSource(ModInfo.Name);
        public static bool IsModdedRoom;

        void Start()
        {
            GorillaTagger.OnPlayerSpawned(Initialized);
            HarmonyPatches.ApplyHarmonyPatches();
            _logger.LogInfo($"{ModInfo.Name}, v{ModInfo.Version} has been Initialized");
        }

        void Initialized()
        {
            _logger.LogInfo("Game Initialized");
        }

        private void Update()
        {
            if (IsModdedRoom)
            {
                _logger.LogInfo("Player Has Entered a Modded Lobby");
            }
        }

        public static new BepInEx.Logging.ManualLogSource Logger => _logger;
    }
}