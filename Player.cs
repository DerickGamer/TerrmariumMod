using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace TerrmariumMod
{
    public class GlobalPlayer : ModPlayer
    {
        public bool CrystalineChestplate { get; set; }
        public bool CrystalineHeadgear { get; set; }
        public bool CrystalineLeggings { get; set; }
        public bool CrystalineSet { get; set; }
        public bool DayBreakersStone { get; set; }
        public bool ThearnorFloaEquiped { get; set; }
        public override void ResetEffects()
        {
            CrystalineChestplate = CrystalineHeadgear = CrystalineLeggings = CrystalineSet = DayBreakersStone = false;
        }
        public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
        {
            if (proj.DamageType == DamageClass.Throwing)
            {
                if (CrystalineSet || (CrystalineChestplate && Main._rand.NextBool(7, 100)))
                {
                    target.AddBuff(BuffID.Confused, 60 * Main.rand.Next(4, 7));
                }
                if (CrystalineSet || (CrystalineHeadgear && Main._rand.NextBool(12, 100)))
                {
                    target.AddBuff(BuffID.OnFire3, 60 * Main.rand.Next(2, 5));
                }
                if (CrystalineSet || (CrystalineLeggings && Main._rand.NextBool(42, 100)))
                {
                    target.AddBuff(BuffID.Ichor, 60 * Main.rand.Next(6, 8));
                }
                if (DayBreakersStone)
                {
                    target.AddBuff(BuffID.Daybreak, 60 * 15);
                }
            }
            
        }
    }
}
