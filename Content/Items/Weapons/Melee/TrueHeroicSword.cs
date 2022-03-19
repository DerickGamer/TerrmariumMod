using Terraria.ID;
using Terraria.ModLoader;
using TerrmariumMod;

namespace TerrmariumMod.Content.Items.Weapons.Melee
{
	public class TrueHeroicSword : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("True Hero's Sword"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("May be the true sword!");
		}

		public override void SetDefaults() 
		{
			Item.damage = 81;
			Item.DamageType = DamageClass.Melee;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 11;
			Item.useAnimation = 11;
			Item.useStyle = 1;
			Item.knockBack = 6;
			Item.value = 5000000;
			Item.rare = 8;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
            Item.shoot = ProjectileID.TerraBeam;
            Item.shootSpeed = 12;
		}

		public override void AddRecipes() 
		{
			CreateRecipe()
				.AddIngredient(Mod, "HeroicSword")
				.AddIngredient(ItemID.BeetleHusk, 30)
				.AddTile(TileID.MythrilAnvil)
				.Register();
		}
	}
}