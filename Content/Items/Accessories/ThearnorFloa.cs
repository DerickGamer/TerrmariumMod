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

namespace TerrmariumMod.Content.Items.Accessories
{
    [AutoloadEquip(EquipType.Back)]
    public class ThearnorFloa : ModItem // Hornet Mega Nest (thear is nest, nor is the "mega" postfix, floa is hornet)
    {
        public override void Load()
        {
            IL.Terraria.Player.beeType += HookBeeType;
        }
        static void HookBeeType(ILContext context)
        {
            ILCursor cursor = new(context);
            if (!cursor.TryGotoNext(i => i.MatchLdcI4(566)))
                return;
            cursor.Index++;
            cursor.Emit(OpCodes.Ldarg_0);
            cursor.EmitDelegate<Func<int, Player, int>>((returnValue, player) => {
                // Regular c# code
                if (player.GetModPlayer<GlobalPlayer>().ThearnorFloaEquiped && Main.rand.NextBool(10) && Main.ProjectileUpdateLoopIndex == -1)
                {
                    return ProjectileID.Beenade;
                }
                return returnValue;
            });
        }
    }
}
