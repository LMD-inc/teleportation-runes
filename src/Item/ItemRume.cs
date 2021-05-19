using Vintagestory.API.Common;
using Vintagestory.GameContent;
using Vintagestory.API.MathTools;
using Vintagestory.API.Config;
using Vintagestory.API.Client;

using System.Text;

namespace TeleporatationRunes
{
    public class ItemRune : Item
    {

        private BlockPos _beaconPosition;
        private string _beaconName = null;

        public override void OnHeldInteractStart(ItemSlot slot, EntityAgent byEntity, BlockSelection blockSel, EntitySelection entitySel, bool firstEvent, ref EnumHandHandling handling)
        {
            if (blockSel?.Position == null || !(byEntity.World is IClientWorldAccessor))
            {
                return;
            }
            BEBeacon bec = byEntity.World.BlockAccessor.GetBlockEntity(blockSel.Position) as BEBeacon;

            if (bec == null)
            {
                return;
            }
            _beaconPosition = blockSel.Position;

            string prevName = _beaconName == null ? "" : _beaconName;
            GuiDialogBlockEntityTextInput dlg = new GuiDialogBlockEntityTextInput(Lang.Get("tprunes:beacon_location_name"), bec.Pos, prevName, bec.Api as ICoreClientAPI, 500);
            dlg.OnTextChanged = (text) => _beaconName = text;
            dlg.OnCloseCancel = () => _beaconName = prevName == "" ? null : _beaconName;
            dlg.TryOpen();
        }

        public override void GetHeldItemInfo(ItemSlot inSlot, StringBuilder dsc, IWorldAccessor world, bool withDebugInfo)
        {
            base.GetHeldItemInfo(inSlot, dsc, world, withDebugInfo);

            if (_beaconName != null)
            {
                dsc.AppendLine(Lang.Get("tprunes:rune_bound_to") + " " + _beaconName);
            }
        }

        public override WorldInteraction[] GetHeldInteractionHelp(ItemSlot inSlot)
        {
            string langCode = _beaconName == null ? Lang.Get("tprunes:bind_to_beacon") : (Lang.Get("tprunes:hold_to_teleport") + " " + _beaconName);

            WorldInteraction[] customInteractions = new WorldInteraction[] {
                new WorldInteraction()
                {
                    ActionLangCode = langCode,
                    MouseButton = EnumMouseButton.Right
                }
            };
            return customInteractions;
        }
    }
}