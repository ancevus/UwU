using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace UwU.Items.Tools
{
    public class smallhook : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("fhueiworcefwjpr");
        }

        public override void SetDefaults()
        {
            item.noUseGraphic = true;
            item.damage = 70;
            item.knockBack = 7f;
            item.useStyle = 5;
            item.shootSpeed = 15f;
            item.shoot = 3;
            item.width = 18;
            item.height = 28;
            item.useAnimation = 3;
            item.useTime = 3;
            item.rare = 1;
            item.noMelee = true;
            item.value = 20000;
            item.shoot = ProjectileType<smallhookowo>();
        }
    }

    public class smallhookowo : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.netImportant = true;
            projectile.width = 18;
            projectile.height = 18;
            projectile.aiStyle = 7;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.tileCollide = false;
            projectile.timeLeft *= 10;
        }

        public override bool? CanUseGrapple(Player player)
        {
            int hooksOut = 0;
            for (int l = 0; l < 1000; l++)
            {
                if (Main.projectile[l].active && Main.projectile[l].owner == Main.myPlayer && Main.projectile[l].type == projectile.type)
                {
                    hooksOut++;
                }
            }
            if (hooksOut > 696969) 
            {
                return false;
            }
            return true;
        }

        public override void GrappleRetreatSpeed(Player player, ref float speed)
        {
            speed = 290f;
        }

        public override void GrapplePullSpeed(Player player, ref float speed)
        {
            speed = 321;
        }
    }
}
