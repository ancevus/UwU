using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;
 
namespace UwU.Items.Weapons
{  
	public class owosummon : ModItem
	{
		public override void SetStaticDefaults()
		{
		    DisplayName.SetDefault("owosummon");
		    Tooltip.SetDefault("OwO");
            ItemID.Sets.GamepadWholeScreenUseRange[item.type] = true;
            ItemID.Sets.LockOnIgnoresCollision[item.type] = true;
			Item.staff[item.type] = true;
		}
		
	    public override void SetDefaults()
		{
			item.damage = 30000;
			item.knockBack = 10f;
			item.mana = 1;
			item.width = 40;
			item.height = 50;
			item.useTime = 10;
			item.useAnimation = 10;
			item.useStyle = 1;
			item.value = Item.buyPrice(0, 30, 2, 0);
			item.rare = 1;
			item.noMelee = true;
			item.summon = true;
			item.buffType = BuffType<owosummon69>();
            item.shoot = ProjectileType<owosummon52>();
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			player.AddBuff(item.buffType, 2);
	        position = Main.MouseWorld;
	        return true;
		}
		
		
		
	    public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SnowBlock, 69);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
        }
    }
}
