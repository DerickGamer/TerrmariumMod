using Terraria;
using Terraria.GameContent.Creative;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using TerrmariumMod;
using TerrmariumMod.Content.Items.Materials;
using System.Collections.Generic;

namespace TerrmariumMod.Content.NPCs.DropRulesConditions
{
    public class DropWhenMothronDown : IItemDropRuleCondition
    {
        public bool CanDrop(DropAttemptInfo info)
        {
            return !info.IsInSimulation && MainSystem.downedMothron;
        }

        public bool CanShowItemDropInUI()
        {
            return true;
        }

        public string GetConditionDescription()
        {
            return "Drops from Eclipse enemies after the giant moth, Mothron, is defeated";
        }
    }
    public class DropWhenFrostMoonDefeated : IItemDropRuleCondition
    {
        public bool CanDrop(DropAttemptInfo info)
        {
            return !info.IsInSimulation && NPC.downedChristmasTree && NPC.downedChristmasSantank && NPC.downedChristmasIceQueen;
        }

        public bool CanShowItemDropInUI()
        {
            return true;
        }

        public string GetConditionDescription()
        {
            return "Drops from Frost Moon enemies after the Everscream, Santa-NK1 & Ice Queen have been defeated";
        }
    }
    public class DropWhenHarvestMoonDefeated : IItemDropRuleCondition
    {
        public bool CanDrop(DropAttemptInfo info)
        {
            return !info.IsInSimulation && NPC.downedHalloweenKing && NPC.downedHalloweenTree;
        }

        public bool CanShowItemDropInUI()
        {
            return true;
        }

        public string GetConditionDescription()
        {
            return "Drops from Frost Moon enemies after the Mourning Wood & Pumpking have been defeated";
        }
    }
}
