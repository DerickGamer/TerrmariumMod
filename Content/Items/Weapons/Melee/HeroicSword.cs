using Terraria.ID;
using Terraria.ModLoader;
using TerrmariumMod.Content.Projectiles;

namespace TerrmariumMod.Content.Items.Weapons.Melee
{
	public class HeroicSword : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Hero's Sword");
			Tooltip.SetDefault("A sword that a giant creature ate, now recovered");
		}

		public override void SetDefaults() 
		{
			Item.damage = 100;
			Item.DamageType = DamageClass.Melee;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 17;
			Item.useAnimation = 20;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 3;
			Item.value = 1000000;
			Item.rare = ItemRarityID.Lime;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<HeroicBeam>();
			Item.shootSpeed = 15;
		}

		public override void AddRecipes() 
		{
			CreateRecipe()
				.AddIngredient(ItemID.BrokenHeroSword)
				.AddIngredient(ItemID.ChlorophyteBar, 18)
				.AddTile(TileID.MythrilAnvil)
				.Register();
		}
	}
}