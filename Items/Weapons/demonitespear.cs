using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace UwU.Items.Weapons
{
	public class demonitespear : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("demonite spear");
			Tooltip.SetDefault("actually balanced");
		}

		public override void SetDefaults() 
		{
			item.damage = 23;
			item.useStyle = 5;
			item.useAnimation = 18;
			item.useTime = 24;
			item.shootSpeed = 6f;
			item.knockBack = 4f;
			item.width = 32;
			item.height = 32;
			item.scale = 1f;
			item.rare = 4;
			item.value = Item.sellPrice(silver: 40);

			item.melee = true;
			item.noMelee = true;
			item.noUseGraphic = true; 
			item.autoReuse = true; 

			item.UseSound = SoundID.Item1;
			item.shoot = ProjectileType<demonitespear52>();
		}

		public override bool CanUseItem(Player player)
		{
			return player.ownedProjectileCounts[item.shoot] < 1;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.DemoniteBar, 12);
			recipe.AddIngredient(ItemID.ShadowScale, 4);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}