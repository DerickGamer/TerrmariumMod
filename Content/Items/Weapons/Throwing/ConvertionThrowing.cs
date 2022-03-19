using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using TerrmariumMod;

internal class ConvertionThrowing : GlobalItem
{
    static readonly int[] ThrowingWeaponsList = new int[] { ItemID.PaperAirplaneA, ItemID.PaperAirplaneB, ItemID.Shuriken, ItemID.ThrowingKnife, ItemID.PoisonedKnife, ItemID.Snowball,
		ItemID.AleThrowingGlove, ItemID.SpikyBall, ItemID.Bone, ItemID.RottenEgg, ItemID.StarAnise, ItemID.MolotovCocktail, ItemID.FrostDaggerfish, ItemID.Javelin, ItemID.BoneJavelin,
		ItemID.BoneDagger, ItemID.Grenade, ItemID.BouncyGrenade, ItemID.StickyGrenade, ItemID.PartyGirlGrenade, ItemID.Beenade };
	public override bool AppliesToEntity(Item item, bool lateInstantiation)
	{
		return ThrowingWeaponsList.HasValue(item.type);
	}
	public override void SetDefaults(Item item)
	{
		item.DamageType = DamageClass.Throwing;
	}
}
