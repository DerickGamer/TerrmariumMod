using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;
using TerrmariumMod;

namespace TerrmariumMod.Content.Items.Materials
{
    public class DerrotShard : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 33;
            ItemID.Sets.SortingPriorityMaterials[Item.type] = 58;
        }
        public override void SetDefaults()
        {
            Item.width = Item.height = 32;
            Item.maxStack = 999;
            Item.value = 10000;
        }
    }
}
