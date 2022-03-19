using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.Chat;
using Terraria.ModLoader;

namespace TerrmariumMod
{
    public static class Ultilities
    {
        public static class RecipeGroups
        {
            public static readonly RecipeGroup EvilBar = new RecipeGroup(() => "Evil Bar", ItemID.DemoniteBar, ItemID.CrimtaneBar);
            public static readonly RecipeGroup EvilRemains = new RecipeGroup(() => "Evil Remains", ItemID.ShadowScale, ItemID.TissueSample);
            public static readonly RecipeGroup PreHardmodeAnvil = new RecipeGroup(() => "Pre-hardmode Anvil", ItemID.IronAnvil, ItemID.LeadAnvil);
        }
        public static int NumMechDowned => NPC.downedMechBoss1.ToInt() + NPC.downedMechBoss2.ToInt() + NPC.downedMechBoss3.ToInt();
        public static bool BossIsAlive
        {
            get
            {
                for (int i = 0; i < Main.maxNPCs; i++)
                {
                    NPC npc = Main.npc[i];
                    if (npc == null || !npc.active)
                    {
                        continue;
                    }
                    if (npc.boss)
                    {
                        return true;
                    }
                }
                return false;
            }
        }
        public static Player GetNearestPlayer(Vector2 pos)
        {
            Player closestPlayer = null;
            float closestPlayerDist = float.MaxValue;
            foreach (Player plr in Main.player)
            {
                if (Vector2.DistanceSquared(plr.Center, pos) < closestPlayerDist)
                {
                    closestPlayer = plr;
                    closestPlayerDist = Vector2.DistanceSquared(plr.Center, pos);
                }
            }
            return closestPlayer;
        }
        public static bool HasValue<T>(this T[] self, T value)
        {
            foreach (T item in self)
            {
                if (EqualityComparer<T>.Default.Equals(item, value))
                    return true;
            }
            return false;
        }
        public static int ToInt(this bool self) => self ? 1 : 0;
        public static void SendInChat(string text, int r, int g, int b) => SendInChat(text, new Color(r, g, b));
        public static void SendInChat(string text, Color color)
        {
            if (Main.netMode == NetmodeID.SinglePlayer)
            {
                Main.NewText(text, color);
            }
            else
            {
                ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral(text), color);
            }
        }
        public static void SendInChat(NetworkText text, int r, int g, int b) => SendInChat(text, new Color(r, g, b));
        public static void SendInChat(NetworkText text, Color color)
        {
            if (Main.netMode == NetmodeID.SinglePlayer)
            {
                Main.NewText(text, color);
            }
            else
            {
                ChatHelper.BroadcastChatMessage(text, color);
            }
        }

    }
}
