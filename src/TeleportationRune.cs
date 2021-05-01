using Vintagestory.API.Client;
using Vintagestory.API.Common;
using Vintagestory.API.Server;
using Vintagestory.GameContent;
using Vintagestory.API.MathTools;

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

    public class Beacon : Block
    {

    }

    public class BeBeacon : BlockEntity
    {
        public override void Initialize(ICoreAPI api)
        {
            base.Initialize(api);

			BEBehaviorAnimatable animUtil = GetBehavior<BEBehaviorAnimatable>();

			if (api.World.Side == EnumAppSide.Client)
			{
				animUtil.animUtil.InitializeAnimator("lmd:rune-beacon", new Vec3f(0, Block.Shape.rotateY, 0));
				animUtil.animUtil.StartAnimation(new AnimationMetaData() { Animation = "Idle", Code = "idle", Weight = 1});
			}
        }
    }
}