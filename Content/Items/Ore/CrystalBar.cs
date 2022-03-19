using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using TerrmariumMod.Content.Items.Armor;

namespace TerrmariumMod.Content.Items.Ore
{
    public class CrystalBar : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crystaline Bar");
            Tooltip.SetDefault($"A bar forged with shards from the deepths of the holy lands");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 999;
        }

        public override void SetDefaults()
        {
            Item.width = Item.height = 16;
            Item.value = Item.sellPrice(silver: 48);
            Item.rare = ItemRarityID.Green;
            Item.maxStack = 999;
        }

        public override void AddRecipes()
        {
            CreateRecipe().
                AddIngredient(ItemID.CrystalShard, 3).
                AddTile(TileID.Anvils).
                Register();
        }
    }
}
