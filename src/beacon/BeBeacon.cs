using System.Text;

using Vintagestory.API.Common;
using Vintagestory.GameContent;
using Vintagestory.API.MathTools;
using Vintagestory.API.Config;

namespace TeleporatationRunes
{
    public class BeBeacon : BlockEntity
    {
        public override void Initialize(ICoreAPI api)
        {
            base.Initialize(api);

            BEBehaviorAnimatable animUtil = GetBehavior<BEBehaviorAnimatable>();

            if (api.World.Side == EnumAppSide.Client && animUtil != null)
            {
                animUtil.animUtil.InitializeAnimator("lmd:rune-beacon", new Vec3f(0, Block.Shape.rotateY, 0));
                animUtil.animUtil.StartAnimation(new AnimationMetaData() { Animation = "Idle", Code = "idle", Weight = 1 });
            }
        }

        public override void GetBlockInfo(IPlayer forPlayer, StringBuilder dsc)
        {
            base.GetBlockInfo(forPlayer, dsc);
            dsc.AppendLine(Lang.Get("game:blockmaterial-Stone") + ": "
                + Lang.Get("game:block-rock-" + this.Block.Variant["stone"]));
            dsc.AppendLine(Lang.Get("game:blockmaterial-Metal") + ": "
                + Lang.Get("game:material-" + this.Block.Variant["metal"]));
        }
    }
}