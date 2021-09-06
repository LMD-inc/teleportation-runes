using System.Text;
using System.IO;
using System.Collections.Generic;

using Vintagestory.API.Server;
using Vintagestory.API.Common;
using Vintagestory.GameContent;
using Vintagestory.API.MathTools;
using Vintagestory.API.Config;

namespace TeleporatationRunes
{
    public class BEBeacon : BlockEntity
    {

        private ICoreServerAPI _sapi;
        private ItemSlot _rune;
        private Dictionary<string, IPlayer> _players = new Dictionary<string, IPlayer>();

        public override void Initialize(ICoreAPI api)
        {
            base.Initialize(api);

            BEBehaviorAnimatable animUtil = GetBehavior<BEBehaviorAnimatable>();

            if (api.World.Side == EnumAppSide.Client && animUtil != null)
            {
                animUtil.animUtil.InitializeAnimator("lmd:rune-beacon", new Vec3f(0, Block.Shape.rotateY, 0));
                animUtil.animUtil.StartAnimation(new AnimationMetaData() { Animation = "Idle", Code = "idle", Weight = 10 });
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

        public void RunAnimation(State state)
        {
            BEBehaviorAnimatable animUtil = GetBehavior<BEBehaviorAnimatable>();
            animUtil?.animUtil.StartAnimation(new AnimationMetaData() { Animation = state.Name, Code = state.Code, Weight = 1 });
        }

        public override void OnReceivedClientPacket(IPlayer player, int packetid, byte[] data)
        {
            string text = "";
            if (packetid == (int)EnumSignPacketId.SaveText)
            {
                if (data != null)
                {
                    using (MemoryStream ms = new MemoryStream(data))
                    {
                        BinaryReader reader = new BinaryReader(ms);
                        text = reader.ReadString();
                        if (text == null) text = "";
                    }
                    if (text == null) text = "";
                }
                if (_rune != null)
                {
                    _rune.Itemstack.Attributes.SetString("name", text);
                }
            }
        }

        public void setRune(ItemSlot rune)
        {
            _rune = rune;
        }

        public class State
        {
            public static State BIND_RUNE = new State("BindRune", "bindrune");
            public static State TELEPORT = new State("Teleport", "teleport");

            private State(string name, string code)
            {
                this._name = name;
                this._code = code;
            }

            private string _name;
            private string _code;

            public string Name
            {
                get
                {
                    return _name;
                }
            }

            public string Code
            {
                get
                {
                    return _code;
                }
            }
        }
    }
}
