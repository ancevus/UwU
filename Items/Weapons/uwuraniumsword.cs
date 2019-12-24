using UwU.Items.Place;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace UwU.Items.Weapons
{
	public class uwuraniumsword : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("uwuranium sword");
			Tooltip.SetDefault("gyjvkj");
		}

		public override void SetDefaults() 
		{
			item.damage = 27;
			item.melee = true;
			item.width = 64;
			item.height = 64;
			item.useTime = 23;
			item.useAnimation = 23;
			item.useStyle = 1;
			item.knockBack = 5.2f;
			item.value = 10000;
			item.rare = 3;
			item.shoot = ProjectileID.SeedlerNut;
			item.shootSpeed = 25;
			item.autoReuse = true;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemType<uwuraniumbar>(), 12);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}