using Terraria;
using Terraria.GameContent.Creative;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using TerrmariumMod;
using TerrmariumMod.Content.Items.Materials;
using TerrmariumMod.Content.NPCs.DropRulesConditions;
using System.Collections.Generic;

namespace TerrmariumMod.Content.NPCs
{
    public class DropLoots : GlobalNPC
    {
        static readonly int[] EclipseEnemies = { NPCID.Eyezor, NPCID.Fritz, NPCID.Frankenstein, NPCID.ThePossessed, NPCID.CreatureFromTheDeep, NPCID.SwampThing, NPCID.Vampire, NPCID.Reaper,
            NPCID.Mothron, NPCID.MothronSpawn, NPCID.Butcher, NPCID.DeadlySphere, NPCID.Psycho, NPCID.DrManFly, NPCID.Nailhead };
        static readonly int[] FrostMoonEnemies = { NPCID.PresentMimic, NPCID.Flocko, NPCID.GingerbreadMan, NPCID.ZombieElf, NPCID.ZombieElfBeard, NPCID.ZombieElfGirl, NPCID.ElfArcher,
            NPCID.Nutcracker, NPCID.NutcrackerSpinning, NPCID.Yeti, NPCID.ElfCopter, NPCID.Krampus, NPCID.Everscream, NPCID.SantaNK1, NPCID.IceQueen };
        static readonly int[] HarvestMoonEnemies = { NPCID.Scarecrow1, NPCID.Scarecrow2, NPCID.Scarecrow3, NPCID.Scarecrow4, NPCID.Scarecrow5, NPCID.Scarecrow6, NPCID.Scarecrow7, NPCID.Scarecrow8,
            NPCID.Scarecrow9, NPCID.Scarecrow10, NPCID.Splinterling, NPCID.Hellhound, NPCID.Poltergeist, NPCID.HeadlessHorseman, NPCID.MourningWood, NPCID.Pumpking };
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            #region All enemies
            if (true) // Change to check if NPC is not Derrot Slime
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.GetInstance<DerrotShard>().Type, Main.rand.Next(7500, 12500)));
            }
            #endregion
            #region Multiple Enemies
            if (EclipseEnemies.HasValue(npc.type))
            {
                npcLoot.Add(new LeadingConditionRule(new DropWhenMothronDown()).OnSuccess(new CommonDrop(ModContent.GetInstance<LunarianEclipseRocks>().Type, 5, 1, 3, 2)));
            }
            if (FrostMoonEnemies.HasValue(npc.type))
            {
                npcLoot.Add(new LeadingConditionRule(new DropWhenFrostMoonDefeated()).OnSuccess(new CommonDrop(ModContent.GetInstance<FrostbiteEssence>().Type, 5, 1, 3, 2)));
            }
            if (HarvestMoonEnemies.HasValue(npc.type))
            {
                npcLoot.Add(new LeadingConditionRule(new DropWhenHarvestMoonDefeated()).OnSuccess(new CommonDrop(ModContent.GetInstance<HarvestFlames>().Type, 5, 1, 3, 2)));
            }
            #endregion
            #region Single enemies
            switch (npc)
            {
                default:
                    break;
            }
            #endregion
        }
    }
    #region ItemDropRules conditions
    
    #endregion
}