using Terraria.ID;
using Terraria.ModLoader;

namespace UwU.Items.Weapons
{
	public class gudsword : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("gud");
		}

		public override void SetDefaults() 
		{
			item.damage = 69;
			item.melee = true;
			item.width = 1000;
			item.height = 3500;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.knockBack = 19;
			item.value = 10000;
			item.rare = 3;
			item.UseSound = SoundID.Item2;
			item.autoReuse = true;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.ChlorophyteOre, 15);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}