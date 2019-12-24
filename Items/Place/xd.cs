using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace UwU.Items.Place
{
	public class xd : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("xdddddd");
		}
		public override void SetDefaults()
		{
			item.width = 100;
			item.height = 100;
			item.maxStack = 999;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 3;
			item.useTime = 3;
			item.useStyle = 6;
			item.consumable = true;
			item.createTile = TileType<Items.Tiles.xd>();
		}
		
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(0);
			recipe.AddTile(18);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}