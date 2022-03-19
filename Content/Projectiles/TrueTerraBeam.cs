using Terraria;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace TerrmariumMod.Content.Projectiles
{
    class TrueTerraBeam : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("True Terra Beam");
        }
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.TerraBeam);
            AIType = ProjectileID.TerraBeam;

            Projectile.damage += 45;
            Projectile.penetrate += 7;
            Projectile.tileCollide = false;
            ProjectileID.Sets.CultistIsResistantTo[Projectile.type] = true;
        }

        #region Code from ExampleMod (https://github.com/tModLoader/tModLoader/blob/1.4/ExampleMod/Content/Projectiles files)
        public override void AI()
        {
            float maxDetectRadius = 400f; // The maximum radius at which a projectile can detect a target
            float projSpeed = 20f; // The speed at which the projectile moves towards the target

            // Trying to find NPC closest to the projectile 
            NPC closestNPC = FindClosestNPC(maxDetectRadius);
            if (closestNPC == null)
            {
                return;
            }

            Vector2 velocity = closestNPC.Center - Projectile.Center;
            velocity.Normalize();
            velocity *= projSpeed;

            // If found, change the velocity of the projectile and turn it in the direction of the target
            // Use the SafeNormalize extension method to avoid NaNs returned by Vector2.Normalize when the vector is zero 
            Projectile.velocity = ((Projectile.velocity * 2f + velocity) / 3f).SafeNormalize(Vector2.Zero) * projSpeed;
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.ToRadians(45f);
        }
        public NPC FindClosestNPC(float maxDetectDistance)
        {
            NPC closestNPC = null;

            // Using squared values in distance checks will let us skip square root calculations, drastically improving this method's speed.
            float sqrMaxDetectDistance = maxDetectDistance * maxDetectDistance;

            // Loop through all NPCs(max always 200)
            for (int k = 0; k < Main.maxNPCs; k++)
            {
                NPC target = Main.npc[k];
                // Check if NPC able to be targeted. It means that NPC is
                // 1. active (alive)
                // 2. chaseable (e.g. not a cultist archer)
                // 3. max life bigger than 5 (e.g. not a critter)
                // 4. can take damage (e.g. moonlord core after all it's parts are downed)
                // 5. hostile (!friendly)
                // 6. not immortal (e.g. not a target dummy)
                // 7. not immune
                if (target.CanBeChasedBy() && target.immune[Projectile.owner] == 0)
                {
                    // The DistanceSquared function returns a squared distance between 2 points, skipping relatively expensive square root calculations
                    float sqrDistanceToTarget = Vector2.DistanceSquared(target.Center, Projectile.Center);

                    // Check if it is within the radius
                    if (sqrDistanceToTarget < sqrMaxDetectDistance)
                    {
                        sqrMaxDetectDistance = sqrDistanceToTarget;
                        closestNPC = target;
                    }
                }
            }

            return closestNPC;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.immune[Projectile.owner] = 5;
        }
        #endregion
    }
}
