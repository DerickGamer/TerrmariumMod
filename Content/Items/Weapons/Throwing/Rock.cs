using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;


namespace TerrmariumMod.Content.Items.Weapons.Throwing
{
    public class Rock : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rock");
            Tooltip.SetDefault("Strong rocky one");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 999;
        }
        public override void SetDefaults()
        {
            Item.width = Item.height = 16;
            Item.damage = 15;
            Item.DamageType = DamageClass.Throwing;
            Item.useTime = Item.useAnimation = 10;
            Item.knockBack = 2;
            Item.ammo = Type;
            Item.consumable = true;
            Item.maxStack = 999;
            Item.rare = ItemRarityID.Blue;
            Item.value = 25;
            Item.shoot = ModContent.ProjectileType<RockP>();
            Item.useStyle = ItemUseStyleID.Swing;
        }

        
    }
    public class RockP : ModProjectile
    {
        public override string Texture => "TerrmariumMod/Content/Items/Weapons/Throwing/Rock";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rock");
        }

        public override void SetDefaults()
        {
            Projectile.friendly = true;
            Projectile.width = Projectile.height = 8;

            Projectile.aiStyle = ProjAIStyleID.ThrownProjectile;
        }
    }
}
