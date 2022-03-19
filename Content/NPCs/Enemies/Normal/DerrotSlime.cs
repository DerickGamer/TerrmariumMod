using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Storage;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;
using TerrmariumMod.Content.Projectiles;

namespace TerrmariumMod.Content.NPCs.Enemies.Normal
{
    public class DerrotSlime : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Derrot Slime");
            Main.npcFrameCount[Type] = 2;
            NPCID.Sets.DebuffImmunitySets.Add(Type, new NPCDebuffImmunityData
            {
                ImmuneToWhips = true,
                SpecificallyImmuneTo = new int[]
                {
                    BuffID.OnFire, BuffID.Poisoned, BuffID.Slow, BuffID.Confused, BuffID.BoneJavelin, BuffID.TentacleSpike // Bone javelin & tentacle spike cuz he absorve it
                }
            });
        }
        public override void SetDefaults()
        {
            NPC.width = 44;
            NPC.height = 32;
            NPC.aiStyle = 0;
            NPC.damage = 100000000; // Absurd
            NPC.defense = 100;
            NPC.lifeMax = 500;
            NPC.lifeRegen = 1;
            NPC.HitSound = SoundID.NPCDeath21; // Blood Zombie death SFX
            NPC.DeathSound = SoundID.NPCDeath5; // Hellhound death SFX
            NPC.aiStyle = NPCAIStyleID.Herpling;
        }
        public override void ModifyHitPlayer(Player target, ref int damage, ref bool crit)
        {
            target.AddBuff(BuffID.Dazed, 60);
        }
        public override void OnKill()
        {
            Projectile.NewProjectile(NPC.GetProjectileSpawnSource(), NPC.position, new Vector2(0, 0), ModContent.GetInstance<Derroplosion>().Type, 250, 50);
        }
    }
}
