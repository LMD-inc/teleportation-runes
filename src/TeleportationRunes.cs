using Vintagestory.API.Client;
using Vintagestory.API.Common;
using Vintagestory.API.Server;

[assembly: ModInfo("TeleportationRunes",
    Description = "Mod that simplifies traveling in the world using gothic-like teleportation stones.",
    Website = "https://github.com/LMD-inc/teleportation-runes",
    Version = "0.1.0",
    Authors = new[] { "LMD-inc" })]
namespace TeleporatationRunes
{
    public class TeleporatationRunesMod : ModSystem
    {
        public override void Start(ICoreAPI api)
        {
            api.RegisterBlockClass("Beacon", typeof(Beacon));
            api.RegisterBlockEntityClass("BeBeacon", typeof(BeBeacon));
        }

        public override void StartClientSide(ICoreClientAPI api)
        {

        }

        public override void StartServerSide(ICoreServerAPI api)
        {

        }
    }
}