using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.Chat;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using TerrmariumMod;

namespace TerrmariumMod.Content.Items
{
    public class MothronDownedToggle : ModItem
    {
        public override string Texture => "Terraria/Images/Item_1";
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("[c/FF0000:======DEBUG ITEM======]\nToggles downedMothron");
        }
        public override void SetDefaults()
        {
            Item.width = Item.height = 20;
            Item.rare = ItemRarityID.Blue;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.useTime = Item.useAnimation = 1;
            Item.autoReuse = false;
        }
        public override void UseAnimation(Player player)
        {
            MainSystem.downedMothron = !MainSystem.downedMothron;
            if (Main.netMode == NetmodeID.SinglePlayer)
            {
                Main.NewText(string.Format("The wariable downedMothron has been set to {0}", MainSystem.downedMothron), 255, 0, 0);
            }
            else
            {
                NetworkText text = NetworkText.FromFormattable("The wariable downedMothron has been set to {0}", MainSystem.downedMothron);
                ChatHelper.BroadcastChatMessage(text, new Color(255, 0, 0));
            }
        }
    }
}
