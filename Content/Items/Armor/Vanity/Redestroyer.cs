/*using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace TerrmariumMod.Content.Items.Armor.Vanity
{
    [AutoloadEquip(EquipType.Body)]
    public class RedestroyersCoredPlate : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Redestroyer's Cored Plate");
            Tooltip.SetDefault("The core shines strongly");
        }
        public override void SetDefaults()
        {
            Item.width = Item.height = 16;

            Item.rare = ItemRarityID.Master;
            Item.vanity = true;
            Item.maxStack = 1;
        }
        public override bool IsVanitySet(int head, int body, int legs)
        {
            return head == ModContent.ItemType<RedestroyersHeadgear>() && legs == ModContent.ItemType<RedestroyersHeavyPlates>();
        }
        public override void UpdateVanitySet(Player player)
        {
            player.AddBuff(ModContent.BuffType<RedestroyersWatcherB>(), 60);
        }
    }
    [AutoloadEquip(EquipType.Head)]
    public class RedestroyersHeadgear : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Redestroyer's Headgear");
            Tooltip.SetDefault("Seems to have a strong and sharp horn behind. A shame that we can't use it");
        }
        public override void SetDefaults()
        {
            Item.width = Item.height = 16;

            Item.rare = ItemRarityID.Master;
            Item.vanity = true;
            Item.maxStack = 1;
        }
    }
    [AutoloadEquip(EquipType.Legs)]
    public class RedestroyersHeavyPlates : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Redestroyer's Heavy Plates");
            Tooltip.SetDefault("Gives power to walk faster, but the plates makes you walk normally");
        }
        public override void SetDefaults()
        {
            Item.width = Item.height = 16;

            Item.rare = ItemRarityID.Master;
            Item.vanity = true;
            Item.maxStack = 1;
        }
    }
    public class RedestroyersWatcher : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Redestroyer's Watcher");

            Main.projFrames[Projectile.type] = 1;
            Main.projPet[Projectile.type] = false;
        }
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.ZephyrFish);
            AIType = ProjectileID.ZephyrFish;
        }
        public override bool PreAI()
        {
            Player player = Main.player[Projectile.owner];
            player.zephyrfish = false;
            return true;
        }
        public override void AI()
        {
            Player player = Main.player[Projectile.owner];
            if (!player.dead && player.HasBuff<RedestroyersWatcherB>())
            {
                Projectile.timeLeft = 2;
            }
        }
    }
    public class RedestroyersWatcherB : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Redestroyer's Watcher");
            Description.SetDefault("He will observe your progression");

            Main.buffNoTimeDisplay[Type] = true;
            Main.vanityPet[Type] = true;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.buffTime[buffIndex] = 18000;
            if (player.whoAmI == Main.myPlayer && player.ownedProjectileCounts[ModContent.ProjectileType<RedestroyersWatcher>()] <= 0)
            {
                Projectile.NewProjectile(player.GetProjectileSource_Buff(buffIndex), player.Center, Vector2.Zero, ModContent.ProjectileType<RedestroyersWatcher>(), 0, 0f, player.whoAmI);
            }
        }
    }
}
*/