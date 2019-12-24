﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UwU.Items.Weapons
{
	public class uwuraniumyoyo52 : ModProjectile
	{
		public override void SetStaticDefaults() {
			ProjectileID.Sets.YoyosLifeTimeMultiplier[projectile.type] = 14f;
			ProjectileID.Sets.YoyosMaximumRange[projectile.type] = 300f;
			ProjectileID.Sets.YoyosTopSpeed[projectile.type] = 18f;
		}

		public override void SetDefaults() {
			projectile.extraUpdates = 0;
			projectile.width = 16;
			projectile.height = 16;
			projectile.aiStyle = 99;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.melee = true;
			projectile.scale = 1f;
		}
	}
}
