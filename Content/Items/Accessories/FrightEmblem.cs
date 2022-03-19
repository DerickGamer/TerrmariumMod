using Terraria;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace TerrmariumMod.Content.Items.Accessories
{
    public class FrightEmblem : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Fright Emblem");
			Tooltip.SetDefault("Increases running speed by 23%");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.width = 40;
			Item.height = 40;
            Item.accessory = true;
		}

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
			player.maxRunSpeed *= 1.23f;
        }
    }
}
