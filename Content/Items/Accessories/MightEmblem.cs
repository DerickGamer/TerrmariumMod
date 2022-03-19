using Terraria;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace TerrmariumMod.Content.Items.Accessories
{
    public class MightEmblem : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Might Emblem"); 
			Tooltip.SetDefault("+25 of defense");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.width = 40;
			Item.height = 40;
			Item.accessory = true;

			Item.defense = 25;
		}

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
        }
    }
}
