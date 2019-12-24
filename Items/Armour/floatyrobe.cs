using UwU.Items.other;
using UwU.Items.Place;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;


namespace UwU.Items.Armour
{
	[AutoloadEquip(EquipType.Body)]
	internal class floatyrobe : ModItem
	{
		public override void SetDefaults() {
			item.width = 18;
			item.height = 14;
			item.rare = 1;
			item.defense = 14;
			item.lifeRegen = 4;
		}

		public override void SetMatch(bool male, ref int equipSlot, ref bool robes) {
			robes = true;
			equipSlot = mod.GetEquipSlot("floatyrobe_Legs", EquipType.Legs);
		}

		public override void DrawHands(ref bool drawHands, ref bool drawArms) {
			drawHands = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemType<uwuraniumbar>(), 10);
			recipe.AddIngredient(ItemType<floatystuff>(), 35);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
