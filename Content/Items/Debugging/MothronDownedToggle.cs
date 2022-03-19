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
            Tooltip.SetDefault("[c/FF0000:======DEBUG ITEM======\nIf you somehow achieved to get this item with no cheats, report it as a probable bug]\nToggles downedMothron");
        }
        public override void SetDefaults()
        {
            Item.width = Item.height = 20;
            Item.rare = ItemRarityID.Blue;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.useTime = Item.useAnimation = 1;
        }
        public override bool? CanAutoReuseItem(Player player)
        {
            return false;
        }
        public override void UseAnimation(Player player)
        {
            MainSystem.downedMothron = !MainSystem.downedMothron;
            Ultilities.SendInChat(string.Format("The wariable downedMothron has been set to {0}", MainSystem.downedMothron), Color.Red);
        }
    }
}
