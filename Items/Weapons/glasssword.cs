using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;
 
namespace UwU.Items.Weapons
{  
    public class glasssword : ModItem
    {
        public override void SetStaticDefaults()
	    {
	        DisplayName.SetDefault("Glass sword");
		    Tooltip.SetDefault("glass");
		}
	   
	    public override void SetDefaults()
	    {
	        item.width = 30;
			item.autoReuse = true;
		    item.height = 30;
		    item.value = Item.buyPrice(0, 0, 2, 0);
		    item.rare = 1;
		    item.useStyle = 1;
		    item.useTime = 21;
		    item.useAnimation = 20;
			item.damage = 10;
			item.crit = 9;
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
