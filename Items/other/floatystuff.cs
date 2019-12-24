using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace UwU.Items.other
{
	public class floatystuff : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("floaty stuff");
			Tooltip.SetDefault("stuff for stuff");
		}
		public override void SetDefaults()
		{
			item.width = 12;
			item.height = 12;
			item.maxStack = 999;
		}
	}
}