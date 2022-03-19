using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.ObjectData;
using TerrmariumMod;

namespace TerrmariumMod.Content.Items.Placeables
{
    public class DerrotForge : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Derrot Forge");
            Tooltip.SetDefault("The devouring darkness will endarken the metals for a use to you.");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
		public override void SetDefaults()
		{
			Item.createTile = ModContent.TileType<DerrotForgeT>(); // This sets the id of the tile that this item should place when used.

			Item.width = 28; // The item texture's width
			Item.height = 14; // The item texture's height

			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useTime = 10;
			Item.useAnimation = 15;

			Item.maxStack = 99;
			Item.consumable = true;
			Item.value = 150;
		}
        public override void AddRecipes()
        {
            CreateRecipe().
                AddRecipeGroup(Ultilities.RecipeGroups.PreHardmodeAnvil).
                AddIngredient(ItemID.Furnace).
                AddRecipeGroup(Ultilities.RecipeGroups.EvilRemains).
                AddIngredient<Ore.DerrotOre>(40).
                AddTile(TileID.WorkBenches).
                Register();
        }
    }
	public class DerrotForgeT : ModTile
    {
        
    }
}
