using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Storage;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Achievements;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;
using TerrmariumMod;

namespace TerrmariumMod.Content.Projectiles
{
    public class Derroplosion : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Derroplosion");
            Main.projFrames[Type] = 5;
        }
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.SolarWhipSwordExplosion);
            Projectile.damage = 100000000; // Absurd
            Projectile.hostile = true;
            Projectile.width = Projectile.height = 104;
			Projectile.timeLeft = 30;
            AIType = ProjectileID.SolarWhipSwordExplosion;
        }
        public override void PostAI()
        {
            Projectile.scale *= 1.1f;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.Dazed, 600);
        }
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            target.AddBuff(BuffID.Dazed, 600);
        }
        public override void Kill(int timeLeft)
        {
			int explosionRadius = 25;
			//if (projectile.type == 29 || projectile.type == 470 || projectile.type == 637)
			/*{
				explosionRadius = 7;
			}*/
			int minTileX = (int)(Projectile.position.X / 16f - explosionRadius);
			int maxTileX = (int)(Projectile.position.X / 16f + explosionRadius);
			int minTileY = (int)(Projectile.position.Y / 16f - explosionRadius);
			int maxTileY = (int)(Projectile.position.Y / 16f + explosionRadius);
			if (minTileX < 0)
			{
				minTileX = 0;
			}
			if (maxTileX > Main.maxTilesX)
			{
				maxTileX = Main.maxTilesX;
			}
			if (minTileY < 0)
			{
				minTileY = 0;
			}
			if (maxTileY > Main.maxTilesY)
			{
				maxTileY = Main.maxTilesY;
			}
			bool canKillWalls = true;
			for (int i = 0; i < Main.player.Length; i++)
			{
				if (!Main.player[i].active) continue;
				if (Projectile.position.Distance(Main.player[i].position) / 16 < explosionRadius)
				{
					Main.player[i].Hurt(PlayerDeathReason.ByCustomReason($"{Main.player[i].name} had too many light."), 1000000000, 1, true, false, true);
					Main.player[i].AddBuff(BuffID.Dazed, 600);
				}
			}
			for (int i = 0; i < Main.maxNPCs; i++)
            {
				if (!Main.npc[i].active) continue;
                if (Projectile.position.Distance(Main.npc[i].position) / 16 < explosionRadius)
                {
					Main.npc[i].life -= 1000000000;
                }
            }
			for (int x = minTileX; x <= maxTileX; x++)
			{
				for (int y = minTileY; y <= maxTileY; y++)
				{
					float diffX = Math.Abs(x - Projectile.position.X / 16f);
					float diffY = Math.Abs(y - Projectile.position.Y / 16f);
					double distance = Math.Sqrt(diffX * diffX + diffY * diffY);
					if (distance < explosionRadius && Main.tile[x, y] != null && Main.tile[x, y].WallType == (ushort)0)
					{
						canKillWalls = true;
						break;
					}
				}
			}
			AchievementsHelper.CurrentlyMining = true;
			for (int i = minTileX; i <= maxTileX; i++)
			{
				for (int j = minTileY; j <= maxTileY; j++)
				{
					float diffX = Math.Abs(i - Projectile.position.X / 16f);
					float diffY = Math.Abs(j - Projectile.position.Y / 16f);
					double distanceToTile = Math.Sqrt(diffX * diffX + diffY * diffY);
					if (distanceToTile < explosionRadius)
					{
						bool canKillTile = true;
						if (Main.tile[i, j] != null && Main.tile[i, j].HasTile)
						{
							canKillTile = true;
							if (Main.tileDungeon[Main.tile[i, j].TileType] || Main.tile[i, j].TileType == 88 || Main.tile[i, j].TileType == 21 || Main.tile[i, j].TileType == 26 || Main.tile[i, j].TileType == 107 || Main.tile[i, j].TileType == 108 || Main.tile[i, j].TileType == 111 || Main.tile[i, j].TileType == 226 || Main.tile[i, j].TileType == 237 || Main.tile[i, j].TileType == 221 || Main.tile[i, j].TileType == 222 || Main.tile[i, j].TileType == 223 || Main.tile[i, j].TileType == 211 || Main.tile[i, j].TileType == 404)
							{
								canKillTile = false;
							}
							if (!Main.hardMode && Main.tile[i, j].TileType == 58)
							{
								canKillTile = false;
							}
							if (!TileLoader.CanExplode(i, j))
							{
								canKillTile = false;
							}
							if (canKillTile)
							{
								WorldGen.KillTile(i, j, false, false, false);
								if (!Main.tile[i, j].HasTile && Main.netMode != NetmodeID.SinglePlayer)
								{
									NetMessage.SendData(MessageID.TileManipulation, -1, -1, null, 0, i, j, 0f, 0, 0, 0);
								}
							}
						}
						if (canKillTile)
						{
							for (int x = i - 1; x <= i + 1; x++)
							{
								for (int y = j - 1; y <= j + 1; y++)
								{
									if (Main.tile[x, y] != null && Main.tile[x, y].WallType > 0 && canKillWalls && WallLoader.CanExplode(x, y, Main.tile[x, y].WallType))
									{
										WorldGen.KillWall(x, y, false);
										if (Main.tile[x, y].WallType == 0 && Main.netMode != NetmodeID.SinglePlayer)
										{
											NetMessage.SendData(MessageID.TileManipulation, -1, -1, null, 2, x, y, 0f, 0, 0, 0);
										}
									}
								}
							}
						}
					}
				}
			}
			AchievementsHelper.CurrentlyMining = false;
			base.Kill(timeLeft);
        }
    }
}
