using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;
 
namespace UwU.Items.Weapons
{  
	public class uwu52 : ModProjectile
	{
		public override void SetStaticDefaults()
		{
	    	DisplayName.SetDefault("uwu52");
		}
		
		public override void SetDefaults()
		{
			projectile.width = 100;
			projectile.height = 100;
			projectile.tileCollide = false;
			projectile.friendly = true;
			projectile.penetrate = -1;
		}
	}
}
