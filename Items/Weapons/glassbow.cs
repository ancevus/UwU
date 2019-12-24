using UwU.Items.Place;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace UwU.Items.Weapons
{
	public class glassbow : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Glass bow");
			Tooltip.SetDefault("leylin");
		}

		public override void SetDefaults() 
		{
			item.damage = 11;
			item.ranged = true;
			item.width = 64;
			item.height = 64;
			item.useTime = 22;
			item.useAnimation = 22;
			item.useStyle = 5;
			item.knockBack = 5;
			item.value = 10000;
			item.rare = 3;
			item.shootSpeed = 22;
			item.shoot = 10;
			item.autoReuse = true;
			item.noMelee = true;
			item.useAmmo = AmmoID.Arrow;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Glass, 20);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}