using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using TerrmariumMod.Content.Classes;
using TerrmariumMod;

internal class ConvertionThrowingMelee : GlobalItem
{
	static readonly int[] OmniWeaponsList = new int[] { ItemID.WoodenBoomerang, ItemID.EnchantedBoomerang, ItemID.IceBoomerang, ItemID.FruitcakeChakram, ItemID.BloodyMachete, ItemID.Shroomerang,
		ItemID.ThornChakram, ItemID.Flamarang, ItemID.CombatWrench, ItemID.FlyingKnife, ItemID.BouncingShield, ItemID.LightDisc, ItemID.Bananarang, ItemID.PossessedHatchet, ItemID.PaladinsHammer, ItemID.ShadowFlameKnife, ItemID.ScourgeoftheCorruptor, ItemID.VampireKnives, ItemID.DayBreak };
	public override bool AppliesToEntity(Item item, bool lateInstantiation)
	{
		return OmniWeaponsList.HasValue(item.type);
	}
	public override void SetDefaults(Item item)
	{
		item.DamageType = ModContent.GetInstance<OmniMeleeThrown>();
	}
}
