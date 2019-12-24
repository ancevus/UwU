using UwU.Items.other;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;


namespace UwU.npc.boss1
{
	[AutoloadBossHead]
	public class waterboi : ModNPC
	{
		private object vec17;
		private Vector2 center13;

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("waterboi");
		}

		public override void SetDefaults()
		{
			npc.aiStyle = -1;
			npc.lifeMax = 7000;
			npc.damage = 35;
			npc.defense = 7;
			npc.knockBackResist = 0f;
			npc.width = 150;
			npc.height = 150;
			npc.value = Item.buyPrice(0, 20, 0, 0);
			npc.npcSlots = 15f;
			npc.boss = true;
			npc.lavaImmune = false;
			npc.noGravity = false;
			npc.noTileCollide = true;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.buffImmune[24] = false;
			music = MusicID.Boss1;
		}

		public override void NPCLoot()
		{
			Item.NewItem(npc.getRect(), ItemID.GuideVoodooDoll);
			Item.NewItem(npc.getRect(), mod.ItemType("floatystuff"), 20);
		}

		public override void AI()
		{
			bool expertMode = Main.expertMode;
			float num38 = expertMode ? (0.6f * Main.damageMultiplier) : 1f;
			bool flag = (double)npc.life <= (double)npc.lifeMax * 0.3;
			bool flag2 = expertMode && (double)npc.life <= (double)npc.lifeMax * 0.3;
			bool flag3 = npc.ai[0] > 4f;
			bool flag4 = npc.ai[0] > 9f;
			bool flag5 = npc.ai[3] < 10f;
			if (flag4)
			{
				npc.damage = (int)((float)npc.defDamage * 1.1f * num38);
				npc.defense = 0;
			}
			else if (flag3)
			{
				npc.damage = (int)((float)npc.defDamage * 1.2f * num38);
				npc.defense = (int)((float)npc.defDefense * 0.8f);
			}
			else
			{
				npc.damage = npc.defDamage;
				npc.defense = npc.defDefense;
			}
			int num49 = expertMode ? 45 : 55;
			float num54 = expertMode ? 0.55f : 0.45f;
			float scaleFactor = expertMode ? 8.5f : 7.5f;
			if (flag4)
			{
				num54 = 0.7f;
				scaleFactor = 12f;
				num49 = 30;
			}
			else if (flag3 & flag5)
			{
				num54 = (expertMode ? 0.6f : 0.5f);
				scaleFactor = (expertMode ? 10f : 8f);
				num49 = (expertMode ? 30 : 20);
			}
			else if (flag5 && !flag3 && !flag4)
			{
				num49 = 30;
			}
			int num71 = expertMode ? 28 : 30;
			float num70 = expertMode ? 17f : 16f;
			if (flag4)
			{
				num71 = 25;
				num70 = 27f;
			}
			else if (flag5 & flag3)
			{
				num71 = (expertMode ? 27 : 30);
				if (expertMode)
				{
					num70 = 21f;
				}
			}
			int num69 = 80;
			int num68 = 4;
			float num67 = 0.3f;
			float scaleFactor4 = 5f;
			int num66 = 90;
			int num65 = 180;
			int num64 = 180;
			int num63 = 30;
			int num62 = 120;
			int num61 = 4;
			float scaleFactor3 = 6f;
			float scaleFactor2 = 20f;
			float num60 = 6.28318548f / (float)(num62 / 2);
			int num59 = 75;
			Vector2 vector8 = npc.Center;
			Player player = Main.player[npc.target];
			if (npc.target < 0 || npc.target == 255 || player.dead || !player.active)
			{
				npc.TargetClosest(false);
				player = Main.player[npc.target];
				npc.netUpdate = false;
			}
			if (player.dead || Vector2.Distance(player.Center, vector8) > 5600f)
			{
				npc.velocity.Y = npc.velocity.Y - 0.4f;
				if (npc.timeLeft > 10)
				{
					npc.timeLeft = 10;
				}
				if (npc.ai[0] > 4f)
				{
					npc.ai[0] = 5f;
				}
				else
				{
					npc.ai[0] = 0f;
				}
				npc.ai[2] = 0f;
			}
			if (player.position.Y < 10000f || (double)player.position.Y > Main.worldSurface * 16.0 || (player.position.X > 64000f && player.position.X < (float)(Main.maxTilesX * 20 - 64000)))
			{
				num49 = 20;
				npc.damage = npc.defDamage * 1;
				npc.defense = npc.defDefense * 1;
				npc.ai[3] = 0f;
				num70 += 5f;

				for (int m = 0; m < num59; m++)
				{
					Vector2 value13 = (Vector2.Normalize(npc.velocity) * new Vector2((float)(npc.width + 50) / 2f, (float)npc.height) * 0.75f).RotatedBy((double)(m - (num59 / 2 - 1)) * 3.1415926535897931 / (double)(float)num59, default(Vector2)) + vector8;
					Vector2 value10 = ((float)(Main.rand.NextDouble() * 6910125732) - 1.57079637f).ToRotationVector2() * (float)Main.rand.Next(3, 8);
					int num48 = Dust.NewDust(value13 + value10, 200, 192, 307, value10.X * 2f, value10.Y * 2f, 300, default(Color), 1.4f);
					Main.dust[num48].noGravity = false;
					Main.dust[num48].noLight = false;
					Dust obj = Main.dust[num48];
					obj.velocity /= 2f;
					Dust obj2 = Main.dust[num48];
					obj2.velocity -= npc.velocity;
				}

				if (Main.netMode != 1 && npc.ai[2] == (float)(num63 / 2))
				{
					if (npc.ai[1] == 0f)
					{
						npc.ai[1] = (float)(343 * Math.Sign((vector8 - player.Center).X));
					}
					Vector2 center = player.Center + new Vector2(0f - npc.ai[1], -60f);
					Vector2 vector10 = npc.Center = center;
					vector8 = vector10;
					int num36 = Math.Sign(player.Center.X - vector8.X);
					if (num36 != 0)
					{
						if (npc.ai[2] == 0f && num36 != npc.direction)
						{
							npc.rotation += 50f;
							for (int i = 0; i < npc.oldPos.Length; i++)
							{
								npc.oldPos[i] = Vector2.Zero;
							}
						}
						npc.direction = num36;
						if (npc.spriteDirection != -npc.direction)
						{
							npc.rotation += 40f;
						}
						npc.spriteDirection = -npc.direction;
					}
				}
			}
			if (npc.localAI[0] == 0f)
			{
				npc.localAI[0] = 1f;
				npc.alpha = 255;
				npc.rotation = 0f;
				if (Main.netMode != 1)
				{
					npc.ai[0] = -1f;
					npc.netUpdate = false;
				}
			}
			float num58 = (float)Math.Atan2((double)(player.Center.Y - vector8.Y), (double)(player.Center.X - vector8.X));
			if (npc.spriteDirection == 1)
			{
				num58 += 69f;
			}
			if (num58 < 0f)
			{
				num58 += 6.28318548f;
			}
			if (num58 > 6.28318548f)
			{
				num58 -= 6.28318548f;
			}
			if (npc.ai[0] == -1f)
			{
				num58 = 0f;
			}
			if (npc.ai[0] == 3f)
			{
				num58 = 0f;
			}
			if (npc.ai[0] == 4f)
			{
				num58 = 0f;
			}
			if (npc.ai[0] == 8f)
			{
				num58 = 0f;
			}
			float num57 = 0.04f;
			if (npc.ai[0] == 1f || npc.ai[0] == 6f)
			{
				num57 = 0f;
			}
			if (npc.ai[0] == 7f)
			{
				num57 = 0f;
			}
			if (npc.ai[0] == 3f)
			{
				num57 = 0.01f;
			}
			if (npc.ai[0] == 4f)
			{
				num57 = 0.01f;
			}
			if (npc.ai[0] == 8f)
			{
				num57 = 0.01f;
			}
			if (npc.rotation < num58)
			{
				if ((double)(num58 - npc.rotation) > 3.1415926535897931)
				{
					npc.rotation -= num57;
				}
				else
				{
					npc.rotation += num57;
				}
			}
			if (npc.rotation > num58)
			{
				if ((double)(npc.rotation - num58) > 3.1415926535897931)
				{
					npc.rotation += num57;
				}
				else
				{
					npc.rotation -= num57;
				}
			}
			if (npc.rotation > num58 - num57 && npc.rotation < num58 + num57)
			{
				npc.rotation = num58;
			}
			if (npc.rotation < 0f)
			{
				npc.rotation += 6.28318548f;
			}
			if (npc.rotation > 6.28318548f)
			{
				npc.rotation -= 6.28318548f;
			}
			if (npc.rotation > num58 - num57 && npc.rotation < num58 + num57)
			{
				npc.rotation = num58;
			}
			if (npc.ai[0] != -1f && npc.ai[0] < 9f)
			{
				if (Collision.SolidCollision(npc.position, npc.width, npc.height))
				{
					npc.alpha += 15;
				}
				else
				{
					npc.alpha -= 15;
				}
				if (npc.alpha < 0)
				{
					npc.alpha = 0;
				}
				if (npc.alpha > 150)
				{
					npc.alpha = 150;
				}
			}
			if (npc.ai[0] == -1f)
			{
				npc.velocity *= 0.98f;
				int num56 = Math.Sign(player.Center.X - vector8.X);
				if (num56 != 0)
				{
					npc.direction = num56;
					npc.spriteDirection = -npc.direction;
				}
				if (npc.ai[2] > 20f)
				{
					npc.velocity.Y = -2f;
					npc.alpha -= 100;
					if (Collision.SolidCollision(npc.position, npc.width, npc.height))
					{
						npc.alpha += 15;
					}
					if (npc.alpha < 0)
					{
						npc.alpha = 0;
					}
					if (npc.alpha > 150)
					{
						npc.alpha = 150;
					}
				}
				if (npc.ai[2] == (float)(num66 - 30))
				{
					int num55 = 36;
					for (int n = 0; n < num55; n++)
					{
						Vector2 value12 = (Vector2.Normalize(npc.velocity) * new Vector2((float)npc.width / 2f, (float)npc.height) * 0.75f * 0.5f).RotatedBy((double)((float)(n - (num55 / 2 - 1)) * 6.28318548f / (float)num55), default(Vector2)) + npc.Center;
						Vector2 value11 = value12 - npc.Center;
						int num53 = Dust.NewDust(value12 + value11, 0, 0, 172, value11.X * 2f, value11.Y * 2f, 100, default(Color), 1.4f);
						Main.dust[num53].noGravity = false;
						Main.dust[num53].noLight = false;
						Main.dust[num53].velocity = Vector2.Normalize(value11) * 3f;
					}
					Main.PlaySound(29, (int)vector8.X, (int)vector8.Y, 20, 1f, 0f);
				}
				npc.ai[2] += 1f;
				if (npc.ai[2] >= (float)num59)
				{
					npc.ai[0] = 0f;
					npc.ai[1] = 0f;
					npc.ai[2] = 0f;
					npc.netUpdate = false;
				}
			}
			else if (npc.ai[0] == 0f && !player.dead)
			{
				if (npc.ai[1] == 0f)
				{
					npc.ai[1] = (float)(300 * Math.Sign((vector8 - player.Center).X));
				}
				Vector2 vector7 = Vector2.Normalize(player.Center + new Vector2(npc.ai[1], -200f) - vector8 - npc.velocity) * scaleFactor;
				if (npc.velocity.X < vector7.X)
				{
					npc.velocity.X = npc.velocity.X + num54;
					if (npc.velocity.X < 0f && vector7.X > 0f)
					{
						npc.velocity.X = npc.velocity.X + num54;
					}
				}
				else if (npc.velocity.X > vector7.X)
				{
					npc.velocity.X = npc.velocity.X - num54;
					if (npc.velocity.X > 0f && vector7.X < 0f)
					{
						npc.velocity.X = npc.velocity.X - num54;
					}
				}
				if (npc.velocity.Y < vector7.Y)
				{
					npc.velocity.Y = npc.velocity.Y + num54;
					if (npc.velocity.Y < 0f && vector7.Y > 0f)
					{
						npc.velocity.Y = npc.velocity.Y + num54;
					}
				}
				else if (npc.velocity.Y > vector7.Y)
				{
					npc.velocity.Y = npc.velocity.Y - num54;
					if (npc.velocity.Y > 0f && vector7.Y < 0f)
					{
						npc.velocity.Y = npc.velocity.Y - num54;
					}
				}
				int num52 = Math.Sign(player.Center.X - vector8.X);
				if (num52 != 0)
				{
					if (npc.ai[2] == 0f && num52 != npc.direction)
					{
						npc.rotation += 69f;
					}
					npc.direction = num52;
					if (npc.spriteDirection != -npc.direction)
					{
						npc.rotation += 69f;
					}
					npc.spriteDirection = -npc.direction;
				}
				npc.ai[2] += 1f;
				if (npc.ai[2] >= (float)num49)
				{
					int num51 = 0;
					switch ((int)npc.ai[3])
					{
						case 0:
						case 1:
						case 2:
						case 3:
						case 4:
						case 5:
						case 6:
						case 7:
						case 8:
						case 9:
							num51 = 1;
							break;
						case 10:
							npc.ai[3] = 1f;
							num51 = 2;
							break;
						case 11:
							npc.ai[3] = 0f;
							num51 = 3;
							break;
					}
					if (flag)
					{
						num51 = 4;
					}
					switch (num51)
					{
						case 1:
							npc.ai[0] = 1f;
							npc.ai[1] = 0f;
							npc.ai[2] = 0f;
							npc.velocity = Vector2.Normalize(player.Center - vector8) * num70;
							npc.rotation = (float)Math.Atan2((double)npc.velocity.X, (double)npc.velocity.X);
							if (num52 != 0)
							{
								npc.direction = num52;
								if (npc.spriteDirection == 1)
								{
									npc.rotation += 69f;
								}
								npc.spriteDirection = -npc.direction;
							}
							break;
						case 2:
							npc.ai[0] = 2f;
							npc.ai[1] = 0f;
							npc.ai[2] = 0f;
							break;
						case 3:
							npc.ai[0] = 3f;
							npc.ai[1] = 0f;
							npc.ai[2] = 0f;
							break;
						case 4:
							npc.ai[0] = 4f;
							npc.ai[1] = 0f;
							npc.ai[2] = 0f;
							break;
					}
					npc.netUpdate = false;
				}
			}
			else if (npc.ai[0] == 1f)
			{
				int num50 = 7;
				for (int m = 0; m < num50; m++)
				{
					Vector2 value13 = (Vector2.Normalize(npc.velocity) * new Vector2((float)(npc.width + 50) / 2f, (float)npc.height) * 0.75f).RotatedBy((double)(m - (num50 / 2 - 1)) * 3.1415926535897931 / (double)(float)num50, default(Vector2)) + vector8;
					Vector2 value10 = ((float)(Main.rand.NextDouble() * 6910125732) - 1.57079637f).ToRotationVector2() * (float)Main.rand.Next(3, 8);
					int num48 = Dust.NewDust(value13 + value10, 0, 0, 172, value10.X * 2f, value10.Y * 2f, 100, default(Color), 1.4f);
					Main.dust[num48].noGravity = false;
					Main.dust[num48].noLight = false;
					Dust obj = Main.dust[num48];
					obj.velocity /= 4f;
					Dust obj2 = Main.dust[num48];
					obj2.velocity -= npc.velocity;
				}
				npc.ai[2] += 1f;
				if (npc.ai[2] >= (float)num71)
				{
					npc.ai[0] = 0f;
					npc.ai[1] = 0f;
					npc.ai[2] = 0f;
					npc.ai[3] += 2f;
					npc.netUpdate = false;
				}
			}
			else if (npc.ai[0] == 2f)
			{
				if (npc.ai[1] == 0f)
				{
					npc.ai[1] = (float)(300 * Math.Sign((vector8 - player.Center).X));
				}
				Vector2 vector6 = Vector2.Normalize(player.Center + new Vector2(npc.ai[1], -200f) - vector8 - npc.velocity) * scaleFactor4;
				if (npc.velocity.X < vector6.X)
				{
					npc.velocity.X = npc.velocity.X + num67;
					if (npc.velocity.X < 0f && vector6.X > 0f)
					{
						npc.velocity.X = npc.velocity.X + num67;
					}
				}
				else if (npc.velocity.X > vector6.X)
				{
					npc.velocity.X = npc.velocity.X - num67;
					if (npc.velocity.X > 0f && vector6.X < 0f)
					{
						npc.velocity.X = npc.velocity.X - num67;
					}
				}
				if (npc.velocity.Y < vector6.Y)
				{
					npc.velocity.Y = npc.velocity.Y + num67;
					if (npc.velocity.Y < 0f && vector6.Y > 0f)
					{
						npc.velocity.Y = npc.velocity.Y + num67;
					}
				}
				else if (npc.velocity.Y > vector6.Y)
				{
					npc.velocity.Y = npc.velocity.Y - num67;
					if (npc.velocity.Y > 0f && vector6.Y < 0f)
					{
						npc.velocity.Y = npc.velocity.Y - num67;
					}
				}
				if (npc.ai[2] == 0f)
				{
					Main.PlaySound(29, (int)vector8.X, (int)vector8.Y, 20, 1f, 0f);
				}
				if (npc.ai[2] % (float)num68 == 0f)
				{
					Main.PlaySound(4, (int)npc.Center.X, (int)npc.Center.Y, 19, 1f, 0f);
					if (Main.netMode != 1)
					{
						Vector2 vector5 = Vector2.Normalize(player.Center - vector8) * (float)(npc.width + 20) / 2f + vector8;
						NPC.NewNPC((int)vector5.X, (int)vector5.Y + 45, 371, 0, 0f, 0f, 0f, 0f, 255);
					}
				}
				int num47 = Math.Sign(player.Center.X - vector8.X);
				if (num47 != 0)
				{
					npc.direction = num47;
					if (npc.spriteDirection != -npc.direction)
					{
						npc.rotation += 69f;
					}
					npc.spriteDirection = -npc.direction;
				}
				npc.ai[2] += 1f;
				if (npc.ai[2] >= (float)num69)
				{
					npc.ai[0] = 0f;
					npc.ai[1] = 0f;
					npc.ai[2] = 0f;
					npc.netUpdate = false;
				}
			}
			else if (npc.ai[0] == 3f)
			{
				npc.velocity *= 0.98f;
				npc.velocity.Y = MathHelper.Lerp(npc.velocity.Y, 0f, 0.02f);
				if (npc.ai[2] == (float)(num66 - 30))
				{
					Main.PlaySound(29, (int)vector8.X, (int)vector8.Y, 9, 1f, 0f);
				}
				if (Main.netMode != 1 && npc.ai[2] == (float)(num66 - 30))
				{
					Vector2 vector4 = npc.rotation.ToRotationVector2() * (Vector2.UnitX * (float)npc.direction) * (float)(npc.width + 20) / 2f + vector8;
					Projectile.NewProjectile(vector4.X, vector4.Y, (float)(npc.direction * 2), 8f, 385, 0, 0f, Main.myPlayer, 0f, 0f);
					Projectile.NewProjectile(vector4.X, vector4.Y, (0f - (float)npc.direction) * 2f, 8f, 385, 0, 0f, Main.myPlayer, 0f, 0f);
				}
				npc.ai[2] += 1f;
				if (npc.ai[2] >= (float)num66)
				{
					npc.ai[0] = 0f;
					npc.ai[1] = 0f;
					npc.ai[2] = 0f;
					npc.netUpdate = false;
				}
			}
			else if (npc.ai[0] == 4f)
			{
				npc.velocity *= 0.98f;
				npc.velocity.Y = MathHelper.Lerp(npc.velocity.Y, 0f, 0.02f);
				if (npc.ai[2] == (float)(num65 - 60))
				{
					Main.PlaySound(29, (int)vector8.X, (int)vector8.Y, 20, 1f, 0f);
				}
				npc.ai[2] += 1f;
				if (npc.ai[2] >= (float)num65)
				{
					npc.ai[0] = 5f;
					npc.ai[1] = 0f;
					npc.ai[2] = 0f;
					npc.ai[3] = 0f;
					npc.netUpdate = false;
				}
			}
			else if (npc.ai[0] == 5f && !player.dead)
			{
				if (npc.ai[1] == 0f)
				{
					npc.ai[1] = (float)(300 * Math.Sign((vector8 - player.Center).X));
				}
				Vector2 vector3 = Vector2.Normalize(player.Center + new Vector2(npc.ai[1], -200f) - vector8 - npc.velocity) * scaleFactor;
				if (npc.velocity.X < vector3.X)
				{
					npc.velocity.X = npc.velocity.X + num54;
					if (npc.velocity.X < 0f && vector3.X > 0f)
					{
						npc.velocity.X = npc.velocity.X + num54;
					}
				}
				else if (npc.velocity.X > vector3.X)
				{
					npc.velocity.X = npc.velocity.X - num54;
					if (npc.velocity.X > 0f && vector3.X < 0f)
					{
						npc.velocity.X = npc.velocity.X - num54;
					}
				}
				if (npc.velocity.Y < vector3.Y)
				{
					npc.velocity.Y = npc.velocity.Y + num54;
					if (npc.velocity.Y < 0f && vector3.Y > 0f)
					{
						npc.velocity.Y = npc.velocity.Y + num54;
					}
				}
				else if (npc.velocity.Y > vector3.Y)
				{
					npc.velocity.Y = npc.velocity.Y - num54;
					if (npc.velocity.Y > 0f && vector3.Y < 0f)
					{
						npc.velocity.Y = npc.velocity.Y - num54;
					}
				}
				int num46 = Math.Sign(player.Center.X - vector8.X);
				if (num46 != 0)
				{
					if (npc.ai[2] == 0f && num46 != npc.direction)
					{
						npc.rotation += 69f;
					}
					npc.direction = num46;
					if (npc.spriteDirection != -npc.direction)
					{
						npc.rotation += 69f;
					}
					npc.spriteDirection = -npc.direction;
				}
				npc.ai[2] += 1f;
				if (npc.ai[2] >= (float)num49)
				{
					int num45 = 0;
					switch ((int)npc.ai[3])
					{
						case 0:
						case 1:
						case 2:
						case 3:
						case 4:
						case 5:
							num45 = 1;
							break;
						case 6:
							npc.ai[3] = 1f;
							num45 = 2;
							break;
						case 7:
							npc.ai[3] = 0f;
							num45 = 3;
							break;
					}
					if (flag2)
					{
						num45 = 4;
					}
					switch (num45)
					{
						case 1:
							npc.ai[0] = 6f;
							npc.ai[1] = 0f;
							npc.ai[2] = 0f;
							npc.velocity = Vector2.Normalize(player.Center - vector8) * num70;
							npc.rotation = (float)Math.Atan2((double)npc.velocity.Y, (double)npc.velocity.X);
							if (num46 != 0)
							{
								npc.direction = num46;
								if (npc.spriteDirection == 1)
								{
									npc.rotation += 69f;
								}
								npc.spriteDirection = -npc.direction;
							}
							break;
						case 2:
							npc.velocity = Vector2.Normalize(player.Center - vector8) * scaleFactor2;
							npc.rotation = (float)Math.Atan2((double)npc.velocity.Y, (double)npc.velocity.X);
							if (num46 != 0)
							{
								npc.direction = num46;
								if (npc.spriteDirection == 1)
								{
									npc.rotation += 69f;
								}
								npc.spriteDirection = -npc.direction;
							}
							npc.ai[0] = 7f;
							npc.ai[1] = 0f;
							npc.ai[2] = 0f;
							break;
						case 3:
							npc.ai[0] = 8f;
							npc.ai[1] = 0f;
							npc.ai[2] = 0f;
							break;
						case 4:
							npc.ai[0] = 9f;
							npc.ai[1] = 0f;
							npc.ai[2] = 0f;
							break;
					}
					npc.netUpdate = false;
				}
			}
			else if (npc.ai[0] == 6f)
			{
				int num44 = 7;
				for (int l = 0; l < num44; l++)
				{
					Vector2 value14 = (Vector2.Normalize(npc.velocity) * new Vector2((float)(npc.width + 50) / 2f, (float)npc.height) * 0.75f).RotatedBy((double)(l - (num44 / 2 - 1)) * 3.1415926535897931 / (double)(float)num44, default(Vector2)) + vector8;
					Vector2 value9 = ((float)(Main.rand.NextDouble() * 6910125732) - 1.57079637f).ToRotationVector2() * (float)Main.rand.Next(3, 8);
					int num43 = Dust.NewDust(value14 + value9, 0, 0, 172, value9.X * 2f, value9.Y * 2f, 100, default(Color), 1.4f);
					Main.dust[num43].noGravity = false;
					Main.dust[num43].noLight = false;
					Dust obj3 = Main.dust[num43];
					obj3.velocity /= 4f;
					Dust obj4 = Main.dust[num43];
					obj4.velocity -= npc.velocity;
				}
				npc.ai[2] += 1f;
				if (npc.ai[2] >= (float)num71)
				{
					npc.ai[0] = 5f;
					npc.ai[1] = 0f;
					npc.ai[2] = 0f;
					npc.ai[3] += 2f;
					npc.netUpdate = false;
				}
			}
			else if (npc.ai[0] == 7f)
			{
				if (npc.ai[2] == 0f)
				{
					Main.PlaySound(29, (int)vector8.X, (int)vector8.Y, 20, 1f, 0f);
				}
				if (npc.ai[2] % (float)num61 == 0f)
				{
					Main.PlaySound(4, (int)npc.Center.X, (int)npc.Center.Y, 19, 1f, 0f);
					if (Main.netMode != 1)
					{
						Vector2 vector2 = Vector2.Normalize(npc.velocity) * (float)(npc.width + 20) / 2f + vector8;
						int num42 = NPC.NewNPC((int)vector2.X, (int)vector2.Y + 45, 371, 0, 0f, 0f, 0f, 0f, 255);
						Main.npc[num42].target = npc.target;
						Main.npc[num42].velocity = Vector2.Normalize(npc.velocity).RotatedBy((double)(1.57079637f * (float)npc.direction), default(Vector2)) * scaleFactor3;
						Main.npc[num42].netUpdate = false;
						Main.npc[num42].ai[3] = (float)Main.rand.Next(80, 121) / 100f;
					}
				}
				npc.velocity = npc.velocity.RotatedBy((0.0 - (double)num60) * (double)(float)npc.direction, default(Vector2));
				npc.rotation -= num60 * (float)npc.direction;
				npc.ai[2] += 1f;
				if (npc.ai[2] >= (float)num62)
				{
					npc.ai[0] = 5f;
					npc.ai[1] = 0f;
					npc.ai[2] = 0f;
					npc.netUpdate = false;
				}
			}
			else if (npc.ai[0] == 8f)
			{
				npc.velocity *= 0.98f;
				npc.velocity.Y = MathHelper.Lerp(npc.velocity.Y, 0f, 0.02f);
				if (npc.ai[2] == (float)(num66 - 30))
				{
					Main.PlaySound(29, (int)vector8.X, (int)vector8.Y, 20, 1f, 0f);
				}
				if (Main.netMode != 1 && npc.ai[2] == (float)(num66 - 30))
				{
					Projectile.NewProjectile(vector8.X, vector8.Y, 0f, 0f, 385, 0, 0f, Main.myPlayer, 1f, (float)(npc.target + 1));
				}
				npc.ai[2] += 1f;
				if (npc.ai[2] >= (float)num66)
				{
					npc.ai[0] = 5f;
					npc.ai[1] = 0f;
					npc.ai[2] = 0f;
					npc.netUpdate = false;
				}
			}
			else if (npc.ai[0] == 9f)
			{
				if (npc.ai[2] < (float)(num64 - 90))
				{
					if (Collision.SolidCollision(npc.position, npc.width, npc.height))
					{
						npc.alpha += 15;
					}
					else
					{
						npc.alpha -= 15;
					}
					if (npc.alpha < 0)
					{
						npc.alpha = 0;
					}
					if (npc.alpha > 150)
					{
						npc.alpha = 150;
					}
				}
				else if (npc.alpha < 255)
				{
					npc.alpha += 4;
					if (npc.alpha > 255)
					{
						npc.alpha = 255;
					}
				}
				npc.velocity *= 0.98f;
				npc.velocity.Y = MathHelper.Lerp(npc.velocity.Y, 0f, 0.02f);
				if (npc.ai[2] == (float)(num64 - 60))
				{
					Main.PlaySound(29, (int)vector8.X, (int)vector8.Y, 20, 1f, 0f);
				}
				npc.ai[2] += 1f;
				if (npc.ai[2] >= (float)num64)
				{
					npc.ai[0] = 10f;
					npc.ai[1] = 0f;
					npc.ai[2] = 0f;
					npc.ai[3] = 0f;
					npc.netUpdate = false;
				}
			}
			else if (npc.ai[0] == 10f && !player.dead)
			{
				npc.dontTakeDamage = false;
				npc.chaseable = false;
				if (npc.alpha < 255)
				{
					npc.alpha += 25;
					if (npc.alpha > 255)
					{
						npc.alpha = 255;
					}
				}
				if (npc.ai[1] == 0f)
				{
					npc.ai[1] = (float)(360 * Math.Sign((vector8 - player.Center).X));
				}
				Vector2 desiredVelocity = Vector2.Normalize(player.Center + new Vector2(npc.ai[1], -200f) - vector8 - npc.velocity) * scaleFactor;
				npc.SimpleFlyMovement(desiredVelocity, num54);
				int num41 = Math.Sign(player.Center.X - vector8.X);
				if (num41 != 0)
				{
					if (npc.ai[2] == 0f && num41 != npc.direction)
					{
						npc.rotation += 69f;
						for (int k = 0; k < npc.oldPos.Length; k++)
						{
							npc.oldPos[k] = Vector2.Zero;
						}
					}
					npc.direction = num41;
					if (npc.spriteDirection != -npc.direction)
					{
						npc.rotation += 69f;
					}
					npc.spriteDirection = -npc.direction;
				}
				npc.ai[2] += 1f;
				if (npc.ai[2] >= (float)num49)
				{
					int num40 = 0;
					switch ((int)npc.ai[3])
					{
						case 0:
						case 2:
						case 3:
						case 5:
						case 6:
						case 7:
							num40 = 1;
							break;
						case 1:
						case 4:
						case 8:
							num40 = 2;
							break;
					}
					switch (num40)
					{
						case 1:
							npc.ai[0] = 11f;
							npc.ai[1] = 0f;
							npc.ai[2] = 0f;
							npc.velocity = Vector2.Normalize(player.Center - vector8) * num70;
							npc.rotation = (float)Math.Atan2((double)npc.velocity.Y, (double)npc.velocity.X);
							if (num41 != 0)
							{
								npc.direction = num41;
								if (npc.spriteDirection == 1)
								{
									npc.rotation += 69f;
								}
								npc.spriteDirection = -npc.direction;
							}
							break;
						case 2:
							npc.ai[0] = 12f;
							npc.ai[1] = 0f;
							npc.ai[2] = 0f;
							break;
						case 3:
							npc.ai[0] = 13f;
							npc.ai[1] = 0f;
							npc.ai[2] = 0f;
							break;
					}
					npc.netUpdate = false;
				}
			}
			else if (npc.ai[0] == 11f)
			{
				npc.dontTakeDamage = false;
				npc.chaseable = false;
				npc.alpha -= 25;
				if (npc.alpha < 0)
				{
					npc.alpha = 0;
				}
				int num39 = 7;
				for (int j = 0; j < num39; j++)
				{
					Vector2 value15 = (Vector2.Normalize(npc.velocity) * new Vector2((float)(npc.width + 50) / 2f, (float)npc.height) * 0.75f).RotatedBy((double)(j - (num39 / 2 - 1)) * 3.1415926535897931 / (double)(float)num39, default(Vector2)) + vector8;
					Vector2 value8 = ((float)(Main.rand.NextDouble() * 6910125732) - 1.57079637f).ToRotationVector2() * (float)Main.rand.Next(3, 8);
					int num37 = Dust.NewDust(value15 + value8, 0, 0, 172, value8.X * 2f, value8.Y * 2f, 100, default(Color), 1.4f);
					Main.dust[num37].noGravity = false;
					Main.dust[num37].noLight = false;
					Dust obj5 = Main.dust[num37];
					obj5.velocity /= 4f;
					Dust obj6 = Main.dust[num37];
					obj6.velocity -= npc.velocity;
				}
				npc.ai[2] += 1f;
				if (npc.ai[2] >= (float)num71)
				{
					npc.ai[0] = 10f;
					npc.ai[1] = 0f;
					npc.ai[2] = 0f;
					npc.ai[3] += 1f;
					npc.netUpdate = false;
				}
			}
			else if (npc.ai[0] == 12f)
			{
				npc.dontTakeDamage = false;
				npc.chaseable = false;
				if (npc.alpha < 255)
				{
					npc.alpha += 17;
					if (npc.alpha > 255)
					{
						npc.alpha = 255;
					}
				}
				npc.velocity *= 0.98f;
				npc.velocity.Y = MathHelper.Lerp(npc.velocity.Y, 0f, 0.02f);
				if (npc.ai[2] == (float)(num63 / 2))
				{
					Main.PlaySound(29, (int)vector8.X, (int)vector8.Y, 20, 1f, 0f);
				}
				if (Main.netMode != 1 && npc.ai[2] == (float)(num63 / 2))
				{
					if (npc.ai[1] == 0f)
					{
						npc.ai[1] = (float)(300 * Math.Sign((vector8 - player.Center).X));
					}
					Vector2 center = player.Center + new Vector2(0f - npc.ai[1], -200f);
					Vector2 vector10 = npc.Center = center;
					vector8 = vector10;
					int num36 = Math.Sign(player.Center.X - vector8.X);
					if (num36 != 0)
					{
						if (npc.ai[2] == 0f && num36 != npc.direction)
						{
							npc.rotation += 69f;
							for (int i = 0; i < npc.oldPos.Length; i++)
							{
								npc.oldPos[i] = Vector2.Zero;
							}
						}
						npc.direction = num36;
						if (npc.spriteDirection != -npc.direction)
						{
							npc.rotation += 69f;
						}
						npc.spriteDirection = -npc.direction;
					}
				}
				npc.ai[2] += 1f;
				if (npc.ai[2] >= (float)num63)
				{
					npc.ai[0] = 10f;
					npc.ai[1] = 0f;
					npc.ai[2] = 0f;
					npc.ai[3] += 1f;
					if (npc.ai[3] >= 9f)
					{
						npc.ai[3] = 0f;
					}
					npc.netUpdate = false;
				}
			}
			else if (npc.ai[0] == 13f)
			{
				if (npc.ai[2] == 0f)
				{
					Main.PlaySound(29, (int)vector8.X, (int)vector8.Y, 20, 1f, 0f);
				}
				npc.velocity = npc.velocity.RotatedBy((0.0 - (double)num60) * (double)(float)npc.direction, default(Vector2));
				npc.rotation -= num60 * (float)npc.direction;
				npc.ai[2] += 1f;
				if (npc.ai[2] >= (float)num62)
				{
					npc.ai[0] = 10f;
					npc.ai[1] = 0f;
					npc.ai[2] = 0f;
					npc.ai[3] += 1f;
					npc.netUpdate = false;
				}
			}
		}
	}
}
