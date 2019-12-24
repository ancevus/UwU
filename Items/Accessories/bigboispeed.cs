using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
 
namespace UwU.Items.Accessories
{ 
    public class bigboispeed : ModItem
    {
        public override void SetStaticDefaults()
	    {
	        DisplayName.SetDefault("big boi speeeeeeed");
		    Tooltip.SetDefault("indeed");
	    }

		public override void SetDefaults()
		{
			item.width = 15;
			item.height = 15;
			item.value = Item.buyPrice(0, 0, 1, 0);
			item.rare = 3;
			item.accessory = true;
			item.defense = 6969;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
        {
			player.moveSpeed += -3f;
        }
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);		
			recipe.AddIngredient(ItemID.IceBlock, 19);
			recipe.AddTile(TileID.IceBlock);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}
