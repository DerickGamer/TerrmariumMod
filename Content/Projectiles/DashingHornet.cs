using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.GameContent.Generation;
using Terraria.ID;
using Terraria.IO;
using Terraria.ModLoader;
using Terraria.WorldBuilding;
using Mono.Cecil.Cil;
using MonoMod.Cil;

namespace TerrmariumMod.Content.Projectiles
{
    public class DashingHornet : ModProjectile
    {
        public override string Texture => "Terraria/Images/NPC_42";
        ref float StingerCooldown => ref Projectile.ai[0];
        public override void SetStaticDefaults()
        {
            
        }
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.GiantBee);
            Projectile.damage = (int)(Projectile.damage * 1.25);
            Projectile.width = 42;
            Projectile.height = 32;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.Poisoned, 600);
        }
        public override void OnHitPvp(Player target, int damage, bool crit)
        {
            target.AddBuff(BuffID.Poisoned, 600);
        }
        public override void AI()
        {
            base.AI();
            NPC FindClosestNPC(float maxDetectDistance)
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
            NPC target = FindClosestNPC(500);
            if (target == null) return;
            Projectile.NewProjectile(Projectile.GetProjectileSource_FromThis(), Projectile.position, new Vector2(0, 0), ProjectileID.Stinger, (int)(Projectile.damage * 0.2), Projectile.knockBack);
        }
    }
}
