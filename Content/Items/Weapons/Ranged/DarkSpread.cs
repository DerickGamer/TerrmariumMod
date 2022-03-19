using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.GameContent.Achievements;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.Exceptions;
using Terraria.ModLoader.Utilities;

namespace TerrmariumMod.Content.Items.Weapons.Ranged
{
    public class DarkSpread : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dark Spread");
            Tooltip.SetDefault("Fires a spread of 8 bullets with a shadow missile");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
			Item.width = 22;
			Item.height = 9;
			Item.rare = ItemRarityID.Lime;

			// Use Properties
			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.autoReuse = true;
			Item.UseSound = SoundID.Item36;

			// Weapon Properties
			Item.DamageType = DamageClass.Ranged;
			Item.damage = 120;
			Item.knockBack = 7f;
			Item.noMelee = true;

			// Gun Properties
			Item.shoot = ProjectileID.PurificationPowder;
			Item.shootSpeed = 20f;
			Item.useAmmo = AmmoID.Bullet;
		}

		public override bool Shoot(Player player, ProjectileSource_Item_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			const int NumProjectiles = 8; // The humber of projectiles that this gun will shoot.

			for (int i = 0; i < NumProjectiles; i++)
			{
				// Rotate the velocity randomly by 30 degrees at max.
				Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(15));

				// Decrease velocity randomly for nicer visuals.
				newVelocity *= 1f - Main.rand.NextFloat(0.3f);

				// Create a projectile.
				Projectile.NewProjectileDirect(source, position, newVelocity, type, damage, knockback, player.whoAmI);
			}

			Projectile.NewProjectileDirect(source, position, velocity, ModContent.ProjectileType<Projectiles.ShadowMissile>(), damage, knockback, player.whoAmI);

			return false; // Return false because we don't want tModLoader to shoot projectile
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-2f, -2f);
		}

        public override void AddRecipes()
        {
			CreateRecipe().
				AddIngredient(ItemID.OnyxBlaster).
				AddIngredient(ItemID.Ectoplasm, 30).
				AddIngredient(ItemID.SpookyWood, 600).
				AddRecipeGroup(RecipeGroupID.IronBar, 45).
				AddTile(TileID.MythrilAnvil).
				Register();
        }
    }
}
