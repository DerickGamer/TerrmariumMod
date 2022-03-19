using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;
using TerrmariumMod;

namespace TerrmariumMod.Content.Items.Materials
{
    public class CoreOfTerra : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Core of Terra");
            Tooltip.SetDefault("The source of all the balance in the world" +
                "\nUsed to craft Terra weapons");

            ItemID.Sets.ItemNoGravity[Type] = true;
        }
        public override void SetDefaults()
        {
            Item.width = Item.height = 64;
            Item.maxStack = 999;
            Item.value = 0; // To be changed
            Item.rare = ItemRarityID.LightPurple;
        }
        public override void PostUpdate()
        {
            Lighting.AddLight(Item.Center, Color.LimeGreen.ToVector3() * 0.55f * Main.essScale);
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(Mod, "HarvestFlames", 20)
                .AddIngredient(Mod, "FrostbiteEssence", 20)
                .AddIngredient(Mod, "LunarianEclipseRocks", 50)
                .AddIngredient(Mod, "NightShadeAlloy", 10)
                .AddIngredient(ItemID.HallowedBar, 10)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}
