using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;
 
namespace UwU.Items.Armour
{ 
    [AutoloadEquip(EquipType.Legs)]
    public class greavves : ModItem
    {
        public override void SetStaticDefaults()
	    {
	        DisplayName.SetDefault("greavves");
		    Tooltip.SetDefault("amazing set bonus for magic wepons");
	    }

		public override void SetDefaults()
		{
			item.width = 17;
			item.height = 17;
			item.value = Item.buyPrice(0, 0, 52, 0);
			item.rare = 4;
			item.defense = 69;
		}
		
		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return head.type == mod.ItemType("hellmet")
			    && body.type == mod.ItemType("chesstplate");
		}
		
		public override void UpdateArmorSet(Player player)
		{
			player.magicDamage *= 10f;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);		
			recipe.AddIngredient(ItemID.SiltBlock, 70);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}
