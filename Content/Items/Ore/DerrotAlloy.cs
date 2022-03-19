using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace TerrmariumMod.Content.Items.Ore
{
    public class DerrotAlloy : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Interesting metal... What can I use it for?");
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
            CreateRecipe(9).
                AddIngredient(Mod, "DerrotOre", 27).
                AddIngredient(Mod, "DerrotShard", 1).
                AddTile(TileID.Furnaces).
                Register();
        }
    }
}
