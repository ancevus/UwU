using UwU.Items.Place;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace UwU.Items.Weapons
{
	public class uwuraniumbow : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("uwuranium bow");
			Tooltip.SetDefault("   ");
		}

		public override void SetDefaults() 
		{
			item.damage = 24;
			item.ranged = true;
			item.width = 64;
			item.height = 64;
			item.useTime = 23;
			item.useAnimation = 23;
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
			recipe.AddIngredient(ItemType<uwuraniumbar>(), 10);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		public override bool ConsumeAmmo(Player player)
		{
			return Main.rand.NextFloat() >= .20f;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			int numberProjectiles = 3 + Main.rand.Next(2);
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(5));
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
			}
			return false; 
		}
	}
}