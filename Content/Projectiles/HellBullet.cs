using Terraria;
using Terraria.Audio;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;

namespace TerrmariumMod.Content.Projectiles
{
    public class HellBullet : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hell's Fire");
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
        }

		public override void SetDefaults()
		{
			Projectile.width = 8;
			Projectile.height = 8;
			Projectile.aiStyle = 1;
			Projectile.friendly = true;
			Projectile.hostile = false;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.penetrate = 3;
			Projectile.timeLeft = 600;
			Projectile.alpha = 255;
			Projectile.light = 0.25f;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = true;
			Projectile.extraUpdates = 1;

			AIType = ProjectileID.Bullet;
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			Projectile.penetrate--;
			if (Projectile.penetrate <= 0)
			{
				Projectile.Kill();
				return true;
			}
			else
			{
				NPC closestNPC = FindClosestNPC(400);
				if (closestNPC != null)
                {
					Projectile.velocity = (closestNPC.Center - Projectile.Center).SafeNormalize(Vector2.Zero) * 12;
					Projectile.rotation = Projectile.velocity.ToRotation();
				}
				else
				{ 
					Collision.HitTiles(Projectile.position, Projectile.velocity, Projectile.width, Projectile.height);
					SoundEngine.PlaySound(SoundID.Item10, Projectile.position);

					if (Math.Abs(Projectile.velocity.X - oldVelocity.X) > float.Epsilon)
					{
						Projectile.velocity.X = -oldVelocity.X;
					}

					if (Math.Abs(Projectile.velocity.Y - oldVelocity.Y) > float.Epsilon)
					{
						Projectile.velocity.Y = -oldVelocity.Y;
					}
				}
			}

			return false;
		}

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
			if (Main.rand.NextFloat() <= 0.1425f)
            {
                if (Main.LocalPlayer.ZoneTowerSolar || Main.LocalPlayer.ZoneTowerVortex || Main.LocalPlayer.ZoneTowerNebula || Main.LocalPlayer.ZoneTowerStardust)
                {
					target.AddBuff(BuffID.Daybreak, Main.rand.Next(60, 180));
				}
				else if (Main.LocalPlayer.ZoneCorrupt || Main.LocalPlayer.ZoneCrimson)
				{
					target.AddBuff(BuffID.CursedInferno, Main.rand.Next(60, 180));
				}
				else if (Main.LocalPlayer.ZoneSnow)
				{
					target.AddBuff(BuffID.Frostburn2, Main.rand.Next(60, 180));
				}
				else
				{
					float chance = Main.rand.NextFloat();
					if (chance <= 0.0568f && Main.hardMode)
                    {
						target.AddBuff(BuffID.Burning, Main.rand.Next(60, 120));
					}
					else if (chance <= 0.0568f || Main.hardMode)
					{
						target.AddBuff(BuffID.OnFire3, Main.rand.Next(30, 120));
					}
					else
					{
						target.AddBuff(BuffID.OnFire, Main.rand.Next(60, 180));
					}
				}
            }
			
			NPC closestNPC = FindClosestNPC(400);
			if (closestNPC != null)
			{
				Projectile.velocity = (closestNPC.Center - Projectile.Center).SafeNormalize(Vector2.Zero) * 12;
				Projectile.rotation = Projectile.velocity.ToRotation();
			}
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
	}
}
