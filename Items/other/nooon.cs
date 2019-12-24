using UwU.Items.Place;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace UwU.Items.other
{
    public class nooon : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("very good but consumable");
            ItemID.Sets.SortingPriorityBossSpawns[item.type] = 1000;
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.maxStack = 20;
            item.rare = 9;
            item.useAnimation = 45;
            item.useTime = 45;
            item.useStyle = 4;
            item.UseSound = SoundID.Item44;
            item.consumable = true;
        }
       
        public override bool UseItem(Player player)
        {
            NPC.SpawnOnPlayer(player.whoAmI, NPCType<npc.boss1.waterboi>());
            NPC.SpawnOnPlayer(player.whoAmI, NPCType<npc.boss1.waterboi>());
            NPC.SpawnOnPlayer(player.whoAmI, NPCType<npc.boss1.waterboi>());
            NPC.SpawnOnPlayer(player.whoAmI, NPCType<npc.boss1.waterboi>());
            NPC.SpawnOnPlayer(player.whoAmI, NPCType<npc.boss1.waterboi>());
            Main.PlaySound(SoundID.Roar, player.position, 5);
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemType<uwuraniumbar>(), 35);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}