using Terraria.ID;
using Terraria.ModLoader;

namespace UwU.Items.Weapons
{
	public class broccoli : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("green indeed");
		}

		public override void SetDefaults() 
		{
			item.damage = 120;
			item.melee = true;
			item.width = 1000;
			item.height = 3500;
			item.useTime = 3;
			item.useAnimation = 20;
			item.useStyle = 2;
			item.knockBack = 2;
			item.value = 10000;
			item.rare = 3;
			item.UseSound = SoundID.Item3;
			item.autoReuse = true;
			item.shoot = ProjectileID.ChlorophyteBullet;
			item.shootSpeed = 15f;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.MudBlock, 10);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}