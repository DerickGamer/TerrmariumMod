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

namespace TerrmariumMod.Content.Projectiles
{
    public class ShadowMissile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shadow Missile");
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 10;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
        }

        public override void SetDefaults()
        {
            Projectile.CloneDefaults(661);
            
            Projectile.width = 20;
            Projectile.height = 42;
            Projectile.penetrate = 3;
            Projectile.timeLeft = 600;
            Projectile.alpha = 255;
            Projectile.light = 0.25f;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
            Projectile.extraUpdates = 1;

            AIType = ProjectileID.BlackBolt; // Onyx Blaster's projectile has this name for some reason. Explain this, Mirsario
            DrawOffsetX = -10;
        }
    }
}
