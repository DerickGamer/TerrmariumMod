using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;
using TerrmariumMod;

namespace TerrmariumMod.Content.Items.Materials
{
    public class FrostbiteEssence : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Killing the Everscream, Santa-NK1 & Ice Queen made the frost moon creatures lose their essence on death." +
                "\nUsed to craft the Core of Terra");

            ItemID.Sets.ItemNoGravity[Type] = true;
            ItemID.Sets.ItemIconPulse[Type] = true;
        }
        public override void SetDefaults()
        {
            Item.width = Item.height = 16;
            Item.maxStack = 999;
            Item.value = 0; // To be changed
            Item.rare = ItemRarityID.LightPurple;
        }
        public override void PostUpdate()
        {
            Lighting.AddLight(Item.Center, Color.DarkCyan.ToVector3() * 0.55f * Main.essScale);
        }
    }
}
