using Vintagestory.API.Client;
using Vintagestory.API.Common;
using Vintagestory.API.Server;

[assembly: ModInfo( "TeleportationRunes",
	Description = "Mod that simplifies traveling in the world using gothic-like teleportation stones.",
	Website     = "https://github.com/LMD-inc/teleportation-runes",
	Version     = "0.1.0",
	Authors     = new []{ "LMD-inc" } )]

namespace TeleporatationRunes
{
	public class TeleporatationRunesMod : ModSystem
	{
		public override void Start(ICoreAPI api)
		{
			api.RegisterBlockClass("BlockBeacon", typeof(BlockBeacon));
			api.RegisterBlockEntityClass("Beacon", typeof(Beacon));
		}
		
		public override void StartClientSide(ICoreClientAPI api)
		{
			
		}
		
		public override void StartServerSide(ICoreServerAPI api)
		{
			
		}
	}

	public class BlockBeacon : Block 
	{
		
	}

	public class Beacon : BlockEntity 
	{

	}
}