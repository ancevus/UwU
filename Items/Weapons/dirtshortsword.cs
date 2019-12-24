using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace UwU.Items.Weapons
{
	public class dirtshortsword : ModItem
	{
		public override void SetStaticDefaults() 
		{
		    DisplayName.SetDefault("dirt shortsword");
			Tooltip.SetDefault("good");
		}

		public override void SetDefaults() 
		{
			item.damage = 14;
			item.melee = true;
			item.width = 1000;
			item.height = 3500;
			item.useTime = 15;
			item.useAnimation = 20;
			item.useStyle = 3;
			item.knockBack = 2;
			item.value = 10000;
			item.rare = 3;
			item.UseSound = SoundID.Item5;
			item.autoReuse = true;
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