using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Generation;
using Terraria.ID;
using Terraria.IO;
using Terraria.ModLoader;
using Terraria.WorldBuilding;

namespace TerrmariumMod.Content.Items.Accessories
{
    [AutoloadEquip(EquipType.Shoes)]
    public class ExosparkBoots : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault(@"The upgrade everyone wanted.
Allows flight, hyper fast running, and extra mobility on ice
30 % increased movement speed
Provides the ability to walk on water, honey & lava
Grants immunity to fire blocks and 10 seconds of immunity to lava
Reduces damage from touching lava");
        }
        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.TerrasparkBoots);
            Item.defense = 10;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.waterWalk = true;
            player.fireWalk = true;
            player.lavaMax += 600;
            player.lavaRose = true;
            player.accRunSpeed = 8f;
            player.rocketBoots = (player.vanityRocketBoots = 7);
            player.moveSpeed += 1.2f;
            player.iceSkate = true;
            player.moveSpeed += 0.3f;
            player.empressBrooch = true;
            player.frogLegJumpBoost = true;
            player.runningOnSand = true;
        }
        public override void AddRecipes()
        {
            CreateRecipe().
                AddIngredient(ItemID.TerrasparkBoots).
                AddIngredient(ItemID.AmphibianBoots).
                AddIngredient(ItemID.SandBoots).
                AddIngredient(ItemID.SoulofFlight, 10).
                AddIngredient(ItemID.SoulofLight, 10).
                AddIngredient(ItemID.SoulofNight, 10).
                AddIngredient(ItemID.SoulofFright, 10).
                AddIngredient(ItemID.SoulofMight, 10).
                AddIngredient(ItemID.SoulofSight, 10).
                AddIngredient(ItemID.FragmentNebula, 10).
                AddIngredient(ItemID.FragmentSolar, 10).
                AddIngredient(ItemID.FragmentStardust, 10).
                AddIngredient(ItemID.FragmentVortex, 10).
                AddTile(TileID.LunarCraftingStation).
                Register();
        }
    }
}
