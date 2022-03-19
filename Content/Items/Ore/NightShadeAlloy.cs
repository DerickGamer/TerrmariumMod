using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace TerrmariumMod.Content.Items.Ore
{
    public class NightShadeAlloy : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Forged with the materials of the worst places...\nUsed to craft night weapons.");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 999;
        }
        public override void SetDefaults()
        {
            Item.width = Item.height = 32;
            Item.value = 0; // To be changed
            Item.rare = ItemRarityID.Green;
            Item.maxStack = 999;
        }
        public override void AddRecipes()
        {
            CreateRecipe(2).
                AddRecipeGroup("AnyOres:EvilBar", 5).
                AddIngredient(ItemID.JungleSpores, 5).
                AddIngredient(ItemID.Bone, 30).
                AddIngredient(ItemID.HellstoneBar, 5).
                AddTile(TileID.DemonAltar).
                Register();
        }
    }
}
