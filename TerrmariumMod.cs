using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using TerrmariumMod.Content.Items.Ore;

namespace TerrmariumMod
{
	public class TerrmariumMod : Mod
	{
		public override void AddRecipeGroups()
        {
			
        }
        public override void PostAddRecipes()
		{
            for (int i = 0; i < Recipe.numRecipes; i++) {
                Recipe recipe = Main.recipe[i];

                
				if (recipe.HasResult(ItemID.NightsEdge))
                {
					recipe.AddIngredient(ModContent.GetInstance<NightShadeAlloy>(), 10);
                }
				if (recipe.HasResult(ItemID.TerraBlade) && recipe.TryGetIngredient(ItemID.BrokenHeroSword, out Item r)) {
					recipe.RemoveIngredient(r);
					recipe.AddIngredient(this, "CoreOfTerra");
				}
				if (recipe.HasResult(ItemID.Zenith) && recipe.TryGetIngredient(ItemID.TerraBlade, out r))
				{
					recipe.RemoveIngredient(r);
					recipe.AddIngredient(this, "TrueTerraBlade");
				}
                if (recipe.HasResult(ItemID.SpectreBoots) && recipe.TryGetIngredient(ItemID.SandBoots, out r))
                {
					recipe.RemoveIngredient(r);
                }
			}
            CreateRecipe(ItemID.BoosterTrack, 60)
				.AddIngredient(ItemID.MinecartTrack, 60)
				.AddIngredient(ItemID.Wire)
				.AddTile(TileID.Anvils)
				.Register();
		}
	}
}