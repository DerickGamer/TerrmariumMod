using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace TerrmariumMod.Content.Classes
{
    public class OmniMeleeThrown : DamageClass
    {
        protected override string DisplayNameInternal => "melee and throwing";

        public override bool CountsAs(DamageClass damageClass)
        {
            if (damageClass.GetType() == typeof(MeleeDamageClass) || damageClass.GetType() == typeof(ThrowingDamageClass))
            {
                return true;
            }
            return false;
        }
    }
}
