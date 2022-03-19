using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.Chat;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.GameContent.Generation;
using Terraria.ID;
using Terraria.IO;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.WorldBuilding;

namespace TerrmariumMod
{
    public class MainSystem : ModSystem
    {
        public static bool downedMothron;

        public override void SaveWorldData(TagCompound tag)
        {
            tag.Add("downedMothron", downedMothron);
        }
        public override void LoadWorldData(TagCompound tag)
        {
            try
            {
                downedMothron = tag.GetBool("downedMothron");
            }
            catch (System.Exception)
            {
                tag.Add("downedMothron", false);
            }
        }
    }
}
