using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace TerrmariumMod.Content.Items.Accessories
{
    public class DaybreakersStone : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Daybreaker's Stone");
            Tooltip.SetDefault("Throwing attacks has 10% increased damage and inflict daybroken\n" +
                "And now, there is a use of this pillar's remains!");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = Item.height = 30;
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            base.UpdateAccessory(player, hideVisual);
            GlobalPlayer plr = player.GetModPlayer<GlobalPlayer>();
            if (plr != null)
            {
                plr.DayBreakersStone = true;
            }
        }

        public override void AddRecipes()
        {
            CreateRecipe().
                AddIngredient(ItemID.SolarBrick, 25).
                AddTile(TileID.LunarCraftingStation).
                Register();
        }
    }
}
