using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using TerrmariumMod.Content.Projectiles;

namespace TerrmariumMod.Content.Items.Weapons.Melee
{
	public class TrueTerraBlade : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("True Terra Blade"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("Wait, the other one was fake?");

			//Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(4, 16));
		}

		public override void SetDefaults() 
		{
			Item.damage = 163;
			Item.DamageType = DamageClass.Melee;
			Item.width = 100;
			Item.height = 100;
			Item.useTime = 8;
			Item.useAnimation = 40;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 12;
			Item.value = 100000000;
			Item.rare = ItemRarityID.Yellow;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<TrueTerraBeam>();
            Item.shootSpeed = 20;
		}

		public override void AddRecipes() 
		{
			CreateRecipe()
				.AddIngredient(ItemID.TerraBlade)
				.AddIngredient(Mod, "TrueHeroicSword")
				.AddTile(TileID.LunarCraftingStation)
				.Register();
		}
	}
}