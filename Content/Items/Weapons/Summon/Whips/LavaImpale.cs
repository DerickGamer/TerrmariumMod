using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace TerrmariumMod.Content.Items.Weapons.Summon.Whips
{
    public class LavaImpale : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lava Impale");
            Tooltip.SetDefault("Impale your enemies on fire!");
        }
        public override void SetDefaults()
        {
            Item.autoReuse = false;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = Item.useAnimation = 25;
            Item.width = Item.height = 18;
            Item.shoot = ModContent.ProjectileType<LavaImpaleP>();
            Item.UseSound = SoundID.Item152;
            Item.noMelee = true;
            Item.DamageType = DamageClass.Summon;
            Item.noUseGraphic = true;
            Item.damage = 30;
            Item.shootSpeed = 5f;
            Item.knockBack = 3;
            Item.value = Item.sellPrice(silver: 90);
            Item.rare = ItemRarityID.Green;
        }
        public override bool? CanAutoReuseItem(Player player)
        {
            return player.autoReuseGlove;
        }
    }

    public class LavaImpaleP : WhipProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lava Impale");
        }
        public override void WhipDefaults()
        {
            originalColor = new Color(245, 12, 2);
            whipRangeMultiplier = 1.5f;
            fallOff = 0.05f;
            tag = BuffID.OnFire;
        }
    }
}
