using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;
 
namespace UwU.Items.Weapons
{  
    public class uwu : ModItem
    {
        public override void SetStaticDefaults()
	    {
	        DisplayName.SetDefault("uwu");
		    Tooltip.SetDefault("uwuwuwuwuwuwuwuwu");
			Item.staff[item.type] = true;
		}
	   
	    public override void SetDefaults()
	    {
	        item.width = 200;
			item.autoReuse = true;
		    item.height = 250;
		    item.value = Item.buyPrice(0, 0, 69, 0);
		    item.rare = 1;
		    item.useStyle = 1;
		    item.useTime = 3;
		    item.useAnimation = 3;
			item.channel = true;
			item.magic = true;
			item.mana = 0;
			item.damage = 30690;
			item.crit = 96;
			item.shoot = ProjectileType<uwu52>();
			item.shootSpeed = 25f;
			item.noMelee = true;
			item.channel = true;
		}
		
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.StoneBlock, 30);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}
