using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.Chat;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using TerrmariumMod;

internal class Mothron : GlobalNPC
{
    public override bool AppliesToEntity(NPC entity, bool lateInstantiation)
    {
        return entity.type == NPCID.Mothron;
    }
    
    public override void OnKill(NPC npc)
    {
        if (!MainSystem.downedMothron)
        {
            Ultilities.SendInChat("The eclipsian creatures are getting anxious", 193, 114, 26);
        }
        MainSystem.downedMothron = true;
        base.OnKill(npc);
    }
}