using Terraria.ID;
using Terraria.ModLoader;

namespace UwU.Items.Weapons
{
	public class uwusword : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("This is an uwu sword");
		}

		public override void SetDefaults() 
		{
			item.damage = 64000;
			item.melee = true;
			item.width = 200;
			item.height = 1000;
			item.useTime = 1;
			item.useAnimation = 3;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = 10000;
			item.rare = 2;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.DirtBlock, 10);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}