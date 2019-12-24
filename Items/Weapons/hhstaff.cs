using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
 
namespace UwU.Items.Weapons
{  
    public class hhstaff : ModItem
    {
        public override void SetStaticDefaults()
	    {
	        DisplayName.SetDefault("hhstaff");
		    Tooltip.SetDefault("this is good hh");
			Item.staff[item.type] = true;
		}
	   
	    public override void SetDefaults()
	    {
	        item.width = 200;
		    item.height = 250;
		    item.value = Item.buyPrice(0, 0, 1, 0);
		    item.rare = 1;
		    item.useStyle = 1;
		    item.useTime = 5;
		    item.useAnimation = 5;
			
			item.magic = true;
			item.mana = 0;
			
			item.damage = 10000;
			item.crit = 99;
			
			item.shoot = ProjectileID.UnholyTridentFriendly;
			item.shootSpeed = 10f;
			item.noMelee = true;
			item.channel = true;
		}
		
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.DirtBlock, 11);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}
