using UwU.Items.Place;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace UwU.Items.Tools
{
	public class fastpick : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("uwuboisonly");
		}

		public override void SetDefaults() {
			item.damage = 1;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 1000;
			item.useAnimation = 10000;
			item.pick = 6969;
			item.useStyle = 1;
			item.knockBack = 10000;
			item.value = 10000;
			item.rare = 100;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemType<uwuraniumbar>(), 69);
			recipe.AddIngredient(3460, 69);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}