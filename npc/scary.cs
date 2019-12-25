using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;

namespace UwU.npc
{
	public class scary : ModNPC
	{
		public override void SetDefaults()
		{
			npc.width = 50;
			npc.height = 50;
			npc.aiStyle = 3; 
			npc.damage = 40;
			npc.defense = 12;
			npc.lifeMax = 83;
			npc.HitSound = SoundID.NPCHit3;
			npc.DeathSound = SoundID.NPCHit21;
			npc.value = 100f;
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			if(spawnInfo.player.ZoneRockLayerHeight);
			return 0.5f;
		}

		public override void NPCLoot()
		{
			if(Main.rand.Next(50) < 1) 
				Item.NewItem(npc.getRect(), ItemID.DirtBlock, 200);
		}
	}
}