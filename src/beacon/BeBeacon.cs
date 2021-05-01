using Vintagestory.API.Common;
using Vintagestory.GameContent;
using Vintagestory.API.MathTools;

namespace TeleporatationRunes
{
    public class BeBeacon : BlockEntity
    {
        public override void Initialize(ICoreAPI api)
        {
            base.Initialize(api);

			BEBehaviorAnimatable animUtil = GetBehavior<BEBehaviorAnimatable>();

			if (api.World.Side == EnumAppSide.Client)
			{
                System.Console.WriteLine("Rotate: " + Block.Shape.rotateY);
				animUtil.animUtil.InitializeAnimator("lmd:rune-beacon", new Vec3f(0, Block.Shape.rotateY, 0));
				animUtil.animUtil.StartAnimation(new AnimationMetaData() { Animation = "Idle", Code = "idle", Weight = 1});
			}
        }
    }
}