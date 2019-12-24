using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;
 
namespace UwU.Items.Weapons
{  
    public class owosummon69 : ModBuff
    {
        public override void SetDefaults()
	    {
	        DisplayName.SetDefault("owosummon");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
	    }
		
		public override void Update(Player player, ref int buffIndex) 
		{
		    if (player.ownedProjectileCounts[ProjectileType<owosummon52>()] > 0) 
		    {
		        player.buffTime[buffIndex] = 18000;
			}
				else
				{
					player.DelBuff(buffIndex);
					buffIndex--;
				}
		}
	}
}
