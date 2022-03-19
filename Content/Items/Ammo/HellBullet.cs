using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.ID;

namespace TerrmariumMod.Content.Items.Ammo
{
    public class HellBullet : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hell's Fire");
            Tooltip.SetDefault("Bullets ricochets onto 3 enemies\n'Fire! Barrage of bullets!'");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 999;
        }

        public override void SetDefaults()
        {
            Item.damage = 12;
            Item.DamageType = DamageClass.Ranged;
            Item.scale = 1f;
            Item.maxStack = 999;
            Item.consumable = true; // This marks the item as consumable, making it automatically be consumed when it's used as ammunition, or something else, if possible.
            Item.knockBack = 1.5f;
            Item.value = 10;
            Item.rare = ItemRarityID.LightRed;
            Item.shoot = ModContent.ProjectileType<Projectiles.HellBullet>();
            Item.shootSpeed = 10f;
            Item.ammo = AmmoID.Bullet;
        }

        public override void AddRecipes()
        {
            CreateRecipe(150).
                AddIngredient(ItemID.MusketBall, 150).
                AddIngredient(ItemID.HellstoneBar).
                AddTile(TileID.Anvils).
                Register();
        }
    }
}
