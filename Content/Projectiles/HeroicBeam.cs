using Terraria;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace TerrmariumMod.Content.Projectiles
{
    class HeroicBeam : ModProjectile
    {
        int framesPostBirth = 0;
        int invFrames = 0;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Heroic Slash");
        }

        public override void SetDefaults()
        {
            //Projectile.CloneDefaults(ProjectileID.NightBeam);
            Projectile.aiStyle = -1;

            Projectile.width = 88;
            Projectile.height = 96;
            Projectile.damage = 120;
            Projectile.DamageType = DamageClass.Melee;
            /*DrawOffsetX = -47;
            DrawOriginOffsetX = 10;
            DrawOriginOffsetY = -40;*/
        }

        public override bool PreAI()
        {
            if (Main.rand.Next(5) <= 4) // only spawn 80% of the time
            {
                int choice = Main.rand.Next(3); // choose a random number: 0, 1, or 2
                if (choice == 0) // use that number to select dustID: 15, 57, or 58
                {
                    choice = 15;
                }
                else if (choice == 1)
                {
                    choice = 57;
                }
                else
                {
                    choice = 58;
                }
                // Spawn the dust
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, choice, Projectile.velocity.X * 0.25f, Projectile.velocity.Y * 0.25f, 150, new Color(32, 254, 91), 0.7f);
            }
            if (framesPostBirth >= 45)
            {
                Projectile.rotation += MathHelper.ToRadians(22.5f / 1.5f) * Projectile.direction;
                return false;
            }
            if (framesPostBirth < 1)
            {
                Projectile.spriteDirection = Projectile.direction;
            }
            Projectile.rotation += MathHelper.ToRadians(22.5f) * Projectile.direction;
            return true;
        }

        public override void AI()
        {
            framesPostBirth++;
            if (framesPostBirth == 45)
            {
                Projectile.velocity /= 1.5f;
                Projectile.penetrate = 2;
                invFrames = 7;
            }
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.immune[Projectile.owner] = invFrames;
        }
    }
}