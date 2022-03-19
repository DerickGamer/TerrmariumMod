using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using TerrmariumMod.Content.Items.Ore;

namespace TerrmariumMod.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]
    public class CrystalBreastplate : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Crystaline Breastplate");
            Tooltip.SetDefault("Increases throwing damage by 6%\n" +
                "Increases player's endurance by 2% (multiplying)\n" +
                "Throwing attacks has 7% of chance of inflicting confused on the target");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = Item.height = 18;
            Item.defense = 11;
            Item.rare = ItemRarityID.Orange;
            Item.value = Item.sellPrice(silver: 48 * 25);
        }

        public override void UpdateEquip(Player player)
        {
            player.GetDamage(DamageClass.Throwing) *= 1.06f;
            player.endurance *= 1.02f;
            GlobalPlayer modplayer = player.GetModPlayer<GlobalPlayer>();
            if (modplayer != null)
            {
                modplayer.CrystalineChestplate = true;
            }
        }

        public override void AddRecipes()
        {
            CreateRecipe().
                AddIngredient<CrystalBar>(25).
                AddTile(TileID.Anvils).
                Register();
        }
    }

    [AutoloadEquip(EquipType.Head)]
    public class CrystalHeadgear : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Crystaline Headgear");
            Tooltip.SetDefault("Increases throwing damage by 11%\n" +
                "Throwing attacks has 12% of chance to burn the target");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = Item.height = 18;
            Item.defense = 7;
            Item.rare = ItemRarityID.Orange;
            Item.value = Item.sellPrice(silver: 48 * 15);
        }

        public override void UpdateEquip(Player player)
        {
            player.GetDamage(DamageClass.Throwing) += .11f;
            GlobalPlayer modplayer = player.GetModPlayer<GlobalPlayer>();
            if (modplayer != null)
            {
                modplayer.CrystalineHeadgear = true;
            }
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.GetInstance<CrystalBreastplate>().Type && legs.type == ModContent.GetInstance<CrystalLeggings>().Type;
        }

        public override void UpdateArmorSet(Player player)
        {
            base.UpdateArmorSet(player);
            player.setBonus = "Attacks WILL inflict [c/FD9800:ichor], [c/BD6DFF:confused] & [c/F25B02:flames]\n" +
                "Throwing damage increased by 25%";
            player.GetDamage(DamageClass.Throwing) *= 1.25f;
            GlobalPlayer modplayer = player.GetModPlayer<GlobalPlayer>();
            if (modplayer != null)
            {
                modplayer.CrystalineSet = true;
            }
        }

        public override void AddRecipes()
        {
            CreateRecipe().
                AddIngredient<CrystalBar>(15).
                AddTile(TileID.Anvils).
                Register();
        }
    }

    [AutoloadEquip(EquipType.Legs)]
    public class CrystalLeggings : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Crystaline Leggings");
            Tooltip.SetDefault("Increases moviment speed by 25%\n" +
                "Throwing attacks has 42% of chance of inflicting ichor on the target");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = Item.height = 18;
            Item.defense = 9;
            Item.rare = ItemRarityID.Orange;
            Item.value = Item.sellPrice(silver: 48 * 20);
        }

        public override void UpdateEquip(Player player)
        {
            player.maxRunSpeed *= 1.25f;
            player.runAcceleration *= 1.25f;
            GlobalPlayer modplayer = player.GetModPlayer<GlobalPlayer>();
            if (modplayer != null)
            {
                modplayer.CrystalineLeggings = true;
            }
        }

        public override void AddRecipes()
        {
            CreateRecipe().
                AddIngredient<CrystalBar>(20).
                AddTile(TileID.Anvils).
                Register();
        }
    }
}
