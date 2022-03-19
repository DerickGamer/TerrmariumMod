using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;
using TerrmariumMod;

namespace TerrmariumMod.Content.Items.Materials
{
    public class LunarianEclipseRocks : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Seems like they started to petrify..." +
                "\nUsed to craft the Core of Terra");

            Main.RegisterItemAnimation(Type, new DrawAnimationVertical(60 / 8, 8));
            ItemID.Sets.ItemNoGravity[Type] = true;
            ItemID.Sets.ItemIconPulse[Type] = false;
        }
        public override void SetDefaults()
        {
            Item.width = Item.height = 32;
            Item.maxStack = 999;
            Item.value = 0; // To be changed
            Item.rare = ItemRarityID.LightPurple;
        }
        public override void PostUpdate()
        {
            Lighting.AddLight(Item.Center, new Color(193, 114, 26).ToVector3() * 0.55f * Main.essScale);
        }
    }
}
