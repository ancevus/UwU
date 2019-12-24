using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;
 
namespace UwU.Items.Weapons
{  
	public class owosummon52 : ModProjectile
	{
		public override void SetStaticDefaults()
		{
	    	DisplayName.SetDefault("owo summon52");
			ProjectileID.Sets.MinionTargettingFeature[projectile.type] = true;
			Main.projPet[projectile.type] = true;
			ProjectileID.Sets.MinionSacrificable[projectile.type] = true;
			ProjectileID.Sets.Homing[projectile.type] = true;
		}
		
		public sealed override void SetDefaults()
		{
			projectile.width = 30;
			projectile.height = 40;
			projectile.tileCollide = false;
			projectile.friendly = true;
			projectile.minion = true;
			projectile.minionSlots = 1f;
			projectile.penetrate = -1;
		}
		
		public override bool MinionContactDamage()
		{
			return true;
		}
		
		public override void AI()
		{
			Player player = Main.player[projectile.owner];
			
			#region Active check
			if (player.dead || !player.active)
			{
				player.ClearBuff(BuffType<owosummon69>());
			}
			
			if (player.HasBuff(BuffType<owosummon69>()))
			{
				projectile.timeLeft = 5;
			}
			
			#endregion
			
			#region General behavior
			Vector2 idlePosition = player.Center;
			idlePosition.Y -= 40f;
			
			float minionPositionOffsetX = (10 + projectile.minionPos * 40) * -player.direction;
			idlePosition.X += minionPositionOffsetX;
			
			Vector2 vectorToIdlePosition = idlePosition - projectile.Center;
			float distanceToIdlePosition = vectorToIdlePosition.Length();
			if (Main.myPlayer == player.whoAmI && distanceToIdlePosition > 2000f)
			{
				projectile.position = idlePosition;
				projectile.velocity *= 0.1f;
				projectile.netUpdate = true;
			}
			
			float overlapVelocity = 0.04f;
			for (int i = 0; i < Main.maxProjectiles; i++)
			{
				Projectile other = Main.projectile[i];
				if (i != projectile.whoAmI && other.active && other.owner == projectile.owner && Math.Abs(projectile.position.X - other.position.X) + Math.Abs(projectile.position.Y - other.position.Y) < projectile.width)
				{
					if (projectile.position.X < other.position.X) projectile.velocity.X -= overlapVelocity;
					else projectile.velocity.X += overlapVelocity;
					if (projectile.position.Y < other.position.Y) projectile.velocity.Y -= overlapVelocity;
					else projectile.velocity.Y += overlapVelocity;
				}
			}
			
			#endregion
			#region Find target
			float distanceFromTarget = 700f;
			Vector2 targetCenter = projectile.position;
			bool foundTarget = false;
			
			if (player.HasMinionAttackTargetNPC)
			{
				NPC npc = Main.npc[player.MinionAttackTargetNPC];
				float between = Vector2.Distance(npc.Center, projectile.Center);
				if (between < 2000f)
				{
					distanceFromTarget = between;
					targetCenter = npc.Center;
					foundTarget = true;
				}
			}
			
			if (!foundTarget)
			{
				for (int i = 0; i < Main.maxNPCs; i++)
				{
					NPC npc = Main.npc[i];
					if (npc.CanBeChasedBy())
					{
						float between = Vector2.Distance(npc.Center, projectile.Center);
						bool closest = Vector2.Distance(projectile.Center, targetCenter) > between;
						bool inRange = between < distanceFromTarget;
						bool lineOfSight = Collision.CanHitLine(projectile.position, projectile.width, projectile.height, npc.position, npc.width, npc.height);
						bool closeThroughWall = between < 100f;
						if (((closest && inRange) || !foundTarget) && (lineOfSight || closeThroughWall))
						{
							distanceFromTarget = between;
							targetCenter = npc.Center;
							foundTarget = true;
						}
					}
				}
			}
			
            projectile.friendly = foundTarget;
			#endregion
			#region Movement
			float speed = 50f;
			float inertia = 40f;
			if (foundTarget)
			{
				if (distanceFromTarget > 40f)
				{
					Vector2 direction = targetCenter - projectile.Center;
					direction.Normalize();
					direction *= speed;
					projectile.velocity = (projectile.velocity * (inertia - 1) + direction) / inertia;
				}
			}
			
			else
			{
				if (distanceToIdlePosition > 569f)
				{
					speed = 12f;
					inertia = 60f;
				}
				
				else
				{
					speed = 6f;

					inertia = 69f;
				}
				
				if (distanceToIdlePosition > 19f)
				{
					vectorToIdlePosition.Normalize();
					vectorToIdlePosition *= speed;
					projectile.velocity = (projectile.velocity * (inertia - 1) + vectorToIdlePosition) / inertia;
				}
				
				else if (projectile.velocity == Vector2.Zero)
				{
					projectile.velocity.X = -0.25f;
					projectile.velocity.Y = -0.15f;
				}
			}
			
			#endregion
			
			#region Animation and visuals
			projectile.rotation = projectile.velocity.X * 0.69f;
            int frameSpeed = 3;
			projectile.frameCounter++;
			if (projectile.frameCounter >= frameSpeed)
			{
				projectile.frameCounter = 0;
				projectile.frame++;
				if (projectile.frame >= Main.projFrames[projectile.type])
				{
					projectile.frame = 0;
				}
			}
			
			Lighting.AddLight(projectile.Center, Color.Magenta.ToVector3() * 0.69f);

			#endregion
		}
	}
}
