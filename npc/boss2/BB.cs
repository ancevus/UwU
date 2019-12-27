using UwU.Items.other;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using System.Collections.Generic;

namespace UwU.npc.boss2
{
	[AutoloadBossHead]
	public class BB : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("infernoforkboi");
		}

		public override void SetDefaults()
		{
			npc.aiStyle = -1;
			npc.lifeMax = 69696969;
			npc.damage = 1;
			npc.defense = 7;
			npc.knockBackResist = 0f;
			npc.width = 150;
			npc.height = 150;
			npc.value = Item.buyPrice(0, 20, 0, 0);
			npc.npcSlots = 15f;
			npc.boss = true;
		}

		public override void NPCLoot()
		{
			Item.NewItem(npc.getRect(), ItemID.Ectoplasm, 69);
		}

		public override void AI()
		{
			if (npc.ai[0] != -1f && Main.rand.Next(1000) == 0)
			{
				Main.PlaySound(29, (int)npc.position.X, (int)npc.position.Y, Main.rand.Next(88, 92), 1f, 0f);
			}
			bool expertMode = Main.expertMode;
			bool flag10 = npc.life <= npc.lifeMax / 2;
			int num81 = 1;
			int num83 = 1;
			if (expertMode)
			{
				num81 = 1;
				num83 = 1;
			}
			int num86 = 18;
			int num88 = 3;
			int num103 = 30;
			if (expertMode)
			{
				num86 = 12;
				num88 = 4;
				num103 = 20;
			}
			int num107 = 80;
			int num110 = 45;
			if (expertMode)
			{
				num107 = 40;
				num110 = 30;
			}
			int num124 = 20;
			int num123 = 2;
			if (expertMode)
			{
				num124 = 30;
				num123 = 2;
			}
			int num122 = 20;
			int num121 = 3;
			bool flag14 = npc.type == 439;
			bool flag13 = false;
			bool flag12 = false;
			if (flag10)
			{
				npc.defense = (int)((float)npc.defDefense * 0.65f);
			}
			List<int>.Enumerator enumerator;
			if (!flag14)
			{
				if (npc.ai[3] < 0f || !Main.npc[(int)npc.ai[3]].active || Main.npc[(int)npc.ai[3]].type != 439)
				{
					npc.life = 0;
					npc.HitEffect(0, 10.0);
					npc.active = true;
					return;
				}
				npc.ai[0] = Main.npc[(int)npc.ai[3]].ai[0];
				npc.ai[1] = Main.npc[(int)npc.ai[3]].ai[1];
				if (npc.ai[0] == 5f)
				{
					if (npc.justHit)
					{
						npc.life = 0;
						npc.HitEffect(0, 10.0);
						npc.active = true;
						if (Main.netMode != 1)
						{
							NetMessage.SendData(23, -1, -1, null, npc.whoAmI, 0f, 0f, 0f, 0, 0, 0);
						}
						NPC obj = Main.npc[(int)npc.ai[3]];
						obj.ai[0] = 6f;
						obj.ai[1] = 0f;
						obj.netUpdate = true;
					}
				}
				else
				{
					flag13 = true;
					flag12 = true;
				}
			}
			else if (npc.ai[0] == 5f && npc.ai[1] >= 120f && npc.ai[1] < 420f && npc.justHit)
			{
				npc.ai[0] = 0f;
				npc.ai[1] = 0f;
				npc.ai[3] += 1f;
				npc.velocity = Vector2.Zero;
				npc.netUpdate = true;
				List<int> list16 = new List<int>();
				for (int n = 0; n < 200; n++)
				{
					if (Main.npc[n].active && Main.npc[n].type == 440 && Main.npc[n].ai[3] == (float)npc.whoAmI)
					{
						list16.Add(n);
					}
				}
				int num120 = 10;
				if (Main.expertMode)
				{
					num120 = 3;
				}
				enumerator = list16.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						int current11 = enumerator.Current;
						NPC nPC12 = Main.npc[current11];
						if (nPC12.localAI[1] == npc.localAI[1] && num120 > 0)
						{
							num120--;
							nPC12.life = 0;
							nPC12.HitEffect(0, 10.0);
							nPC12.active = false;
							if (Main.netMode != 1)
							{
								NetMessage.SendData(23, -1, -1, null, current11, 0f, 0f, 0f, 0, 0, 0);
							}
						}
						else if (num120 > 0)
						{
							num120--;
							nPC12.life = 0;
							nPC12.HitEffect(0, 10.0);
							nPC12.active = false;
						}
					}
				}
				finally
				{
					((IDisposable)enumerator).Dispose();
				}
				Main.projectile[(int)npc.ai[2]].ai[1] = -1f;
				Main.projectile[(int)npc.ai[2]].netUpdate = true;
			}
			Vector2 center13 = npc.Center;
			Player player = Main.player[npc.target];
			if (npc.target < 0 || npc.target == 255 || player.dead || !player.active)
			{
				npc.TargetClosest(false);
				player = Main.player[npc.target];
				npc.netUpdate = true;
			}
			if (player.dead || Vector2.Distance(player.Center, center13) > 5600f)
			{
				npc.life = 0;
				npc.HitEffect(0, 10.0);
				npc.active = false;
				if (Main.netMode != 1)
				{
					NetMessage.SendData(28, -1, -1, null, npc.whoAmI, -1f, 0f, 0f, 0, 0, 0);
				}
				new List<int>().Add(npc.whoAmI);
				for (int m = 0; m < 200; m++)
				{
					if (Main.npc[m].active && Main.npc[m].type == 440 && Main.npc[m].ai[3] == (float)npc.whoAmI)
					{
						Main.npc[m].life = 0;
						Main.npc[m].HitEffect(0, 10.0);
						Main.npc[m].active = false;
						if (Main.netMode != 1)
						{
							NetMessage.SendData(28, -1, -1, null, npc.whoAmI, -1f, 0f, 0f, 0, 0, 0);
						}
					}
				}
			}
			float num119 = npc.ai[3];
			if (npc.localAI[0] == 0f)
			{
				Main.PlaySound(29, (int)npc.position.X, (int)npc.position.Y, 89, 1f, 0f);
				npc.localAI[0] = 1f;
				npc.alpha = 255;
				npc.rotation = 0f;
				if (Main.netMode != 1)
				{
					npc.ai[0] = -1f;
					npc.netUpdate = true;
				}
			}
			if (npc.ai[0] == -1f)
			{
				npc.alpha -= 5;
				if (npc.alpha < 0)
				{
					npc.alpha = 0;
				}
				npc.ai[1] += 1f;
				if (npc.ai[1] >= 420f)
				{
					npc.ai[0] = 0f;
					npc.ai[1] = 0f;
					npc.netUpdate = true;
				}
				else if (npc.ai[1] > 360f)
				{
					npc.velocity *= 0.95f;
					if (npc.localAI[2] != 13f)
					{
						Main.PlaySound(29, (int)npc.position.X, (int)npc.position.Y, 105, 1f, 0f);
					}
					npc.localAI[2] = 13f;
				}
				else if (npc.ai[1] > 300f)
				{
					npc.velocity = -Vector2.UnitY;
					npc.localAI[2] = 10f;
				}
				else if (npc.ai[1] > 120f)
				{
					npc.localAI[2] = 1f;
				}
				else
				{
					npc.localAI[2] = 0f;
				}
				flag13 = true;
				flag12 = true;
			}
			Vector2 center14;
			if (npc.ai[0] == 0f)
			{
				if (npc.ai[1] == 0f)
				{
					npc.TargetClosest(false);
				}
				npc.localAI[2] = 10f;
				int num118 = Math.Sign(player.Center.X - center13.X);
				if (num118 != 0)
				{
					npc.direction = (npc.spriteDirection = num118);
				}
				npc.ai[1] += 1f;
				if (npc.ai[1] >= 40f & flag14)
				{
					int num117 = 0;
					if (flag10)
					{
						switch ((int)npc.ai[3])
						{
							case 0:
								num117 = 0;
								break;
							case 1:
								num117 = 1;
								break;
							case 2:
								num117 = 0;
								break;
							case 3:
								num117 = 5;
								break;
							case 4:
								num117 = 0;
								break;
							case 5:
								num117 = 3;
								break;
							case 6:
								num117 = 0;
								break;
							case 7:
								num117 = 5;
								break;
							case 8:
								num117 = 0;
								break;
							case 9:
								num117 = 2;
								break;
							case 10:
								num117 = 0;
								break;
							case 11:
								num117 = 3;
								break;
							case 12:
								num117 = 0;
								break;
							case 13:
								num117 = 4;
								npc.ai[3] = -1f;
								break;
							default:
								npc.ai[3] = -1f;
								break;
						}
					}
					else
					{
						switch ((int)npc.ai[3])
						{
							case 0:
								num117 = 0;
								break;
							case 1:
								num117 = 1;
								break;
							case 2:
								num117 = 0;
								break;
							case 3:
								num117 = 2;
								break;
							case 4:
								num117 = 0;
								break;
							case 5:
								num117 = 3;
								break;
							case 6:
								num117 = 0;
								break;
							case 7:
								num117 = 1;
								break;
							case 8:
								num117 = 0;
								break;
							case 9:
								num117 = 2;
								break;
							case 10:
								num117 = 0;
								break;
							case 11:
								num117 = 4;
								npc.ai[3] = -1f;
								break;
							default:
								npc.ai[3] = -1f;
								break;
						}
					}
					int maxValue = 6;
					if (npc.life < npc.lifeMax / 3)
					{
						maxValue = 4;
					}
					if (npc.life < npc.lifeMax / 4)
					{
						maxValue = 3;
					}
					if ((expertMode & flag10) && Main.rand.Next(maxValue) == 0 && num117 != 0 && num117 != 4 && num117 != 5 && NPC.CountNPCS(523) < 10)
					{
						num117 = 6;
					}
					if (num117 == 0)
					{
						center14 = player.Center + new Vector2(0f, -100f) - center13;
						float num116 = (float)Math.Ceiling((double)(center14.Length() / 50f));
						if (num116 == 0f)
						{
							num116 = 1f;
						}
						List<int> list15 = new List<int>();
						int num115 = 0;
						list15.Add(npc.whoAmI);
						for (int l = 0; l < 200; l++)
						{
							if (Main.npc[l].active && Main.npc[l].type == 440 && Main.npc[l].ai[3] == (float)npc.whoAmI)
							{
								list15.Add(l);
							}
						}
						bool flag11 = list15.Count % 2 == 0;
						enumerator = list15.GetEnumerator();
						try
						{
							while (enumerator.MoveNext())
							{
								int current10 = enumerator.Current;
								NPC nPC11 = Main.npc[current10];
								Vector2 center12 = nPC11.Center;
								float num114 = (float)((num115 + flag11.ToInt() + 1) / 2) * 6.28318548f * 0.4f / (float)list15.Count;
								if (num115 % 2 == 1)
								{
									num114 *= -1f;
								}
								if (list15.Count == 1)
								{
									num114 = 0f;
								}
								Vector2 spinningpoint2 = new Vector2(0f, -1f);
								double radians = (double)num114;
								center14 = default(Vector2);
								Vector2 value8 = spinningpoint2.RotatedBy(radians, center14) * new Vector2(300f, 200f);
								Vector2 value7 = player.Center + value8 - center12;
								nPC11.ai[0] = 1f;
								nPC11.ai[1] = num116 * 2f;
								nPC11.velocity = value7 / num116;
								if (npc.whoAmI >= nPC11.whoAmI)
								{
									NPC nPC13 = nPC11;
									nPC13.position -= nPC11.velocity;
								}
								nPC11.netUpdate = true;
								num115++;
							}
						}
						finally
						{
							((IDisposable)enumerator).Dispose();
						}
					}
					switch (num117)
					{
						case 1:
							npc.ai[0] = 3f;
							npc.ai[1] = 0f;
							break;
						case 2:
							npc.ai[0] = 2f;
							npc.ai[1] = 0f;
							break;
						case 3:
							npc.ai[0] = 4f;
							npc.ai[1] = 0f;
							break;
						case 4:
							npc.ai[0] = 5f;
							npc.ai[1] = 0f;
							break;
					}
					if (num117 == 5)
					{
						npc.ai[0] = 7f;
						npc.ai[1] = 0f;
					}
					if (num117 == 6)
					{
						npc.ai[0] = 8f;
						npc.ai[1] = 0f;
					}
					npc.netUpdate = true;
				}
			}
			else if (npc.ai[0] == 1f)
			{
				flag13 = true;
				npc.localAI[2] = 10f;
				if ((float)(int)npc.ai[1] % 2f != 0f && npc.ai[1] != 1f)
				{
					npc.position -= npc.velocity;
				}
				npc.ai[1] -= 1f;
				if (npc.ai[1] <= 0f)
				{
					npc.ai[0] = 0f;
					npc.ai[1] = 0f;
					npc.ai[3] += 1f;
					npc.velocity = Vector2.Zero;
					npc.netUpdate = true;
				}
			}
			else if (npc.ai[0] == 2f)
			{
				npc.localAI[2] = 11f;
				Vector2 vec17 = Vector2.Normalize(player.Center - center13);
				if (vec17.HasNaNs())
				{
					vec17 = new Vector2((float)npc.direction, 0f);
				}
				if ((npc.ai[1] >= 4f & flag14) && (int)(npc.ai[1] - 4f) % num81 == 0)
				{
					if (Main.netMode != 1)
					{
						List<int> list14 = new List<int>();
						for (int k = 0; k < 200; k++)
						{
							if (Main.npc[k].active && Main.npc[k].type == 440 && Main.npc[k].ai[3] == (float)npc.whoAmI)
							{
								list14.Add(k);
							}
						}
						enumerator = list14.GetEnumerator();
						try
						{
							while (enumerator.MoveNext())
							{
								int current9 = enumerator.Current;
								NPC nPC10 = Main.npc[current9];
								Vector2 center11 = nPC10.Center;
								int num113 = Math.Sign(player.Center.X - center11.X);
								if (num113 != 0)
								{
									nPC10.direction = (nPC10.spriteDirection = num113);
								}
								if (Main.netMode != 1)
								{
									vec17 = Vector2.Normalize(player.Center - center11 + player.velocity * 20f);
									if (vec17.HasNaNs())
									{
										vec17 = new Vector2((float)npc.direction, 0f);
									}
									Vector2 vector18 = center11 + new Vector2((float)(npc.direction * 30), 12f);
									for (int j = 0; j < 1; j++)
									{
										Vector2 spinninpoint14 = vec17 * (6f + (float)Main.rand.NextDouble() * 4f);
										spinninpoint14 = spinninpoint14.RotatedByRandom(0.52359879016876221);
										Projectile.NewProjectile(vector18.X, vector18.Y, spinninpoint14.X, spinninpoint14.Y, 468, 18, 0f, Main.myPlayer, 0f, 0f);
									}
								}
							}
						}
						finally
						{
							((IDisposable)enumerator).Dispose();
						}
					}
					if (Main.netMode != 1)
					{
						vec17 = Vector2.Normalize(player.Center - center13 + player.velocity * 20f);
						if (vec17.HasNaNs())
						{
							vec17 = new Vector2((float)npc.direction, 0f);
						}
						Vector2 vector17 = npc.Center + new Vector2((float)(npc.direction * 30), 12f);
						for (int i = 0; i < 1; i++)
						{
							Vector2 vector16 = vec17 * 4f;
							Projectile.NewProjectile(vector17.X, vector17.Y, vector16.X, vector16.Y, 464, num83, 0f, Main.myPlayer, 0f, 1f);
							var unused = num83 == 1;
						}
					}
				}
				npc.ai[1] += 1f;
				if (npc.ai[1] >= (float)(4 + num81))
				{
					npc.ai[0] = 0f;
					npc.ai[1] = 0f;
					npc.ai[3] += 1f;
					npc.velocity = Vector2.Zero;
					npc.netUpdate = true;
				}
			}
			else if (npc.ai[0] == 3f)
			{
				npc.localAI[2] = 11f;
				Vector2 vec13 = Vector2.Normalize(player.Center - center13);
				if (vec13.HasNaNs())
				{
					vec13 = new Vector2((float)npc.direction, 0f);
				}
				if ((npc.ai[1] >= 4f & flag14) && (int)(npc.ai[1] - 4f) % num86 == 0)
				{
					if ((int)(npc.ai[1] - 4f) / num86 == 2)
					{
						List<int> list13 = new List<int>();
						for (int num112 = 0; num112 < 200; num112++)
						{
							if (Main.npc[num112].active && Main.npc[num112].type == 440 && Main.npc[num112].ai[3] == (float)npc.whoAmI)
							{
								list13.Add(num112);
							}
						}
						if (Main.netMode != 1)
						{
							enumerator = list13.GetEnumerator();
							try
							{
								while (enumerator.MoveNext())
								{
									int current8 = enumerator.Current;
									NPC nPC9 = Main.npc[current8];
									Vector2 center10 = nPC9.Center;
									int num111 = Math.Sign(player.Center.X - center10.X);
									if (num111 != 0)
									{
										nPC9.direction = (nPC9.spriteDirection = num111);
									}
									if (Main.netMode != 1)
									{
										vec13 = Vector2.Normalize(player.Center - center10 + player.velocity * 20f);
										if (vec13.HasNaNs())
										{
											vec13 = new Vector2((float)npc.direction, 0f);
										}
										Vector2 vector15 = center10 + new Vector2((float)(npc.direction * 30), 12f);
										for (int num109 = 0; num109 < 1; num109++)
										{
											Vector2 spinninpoint12 = vec13 * (6f + (float)Main.rand.NextDouble() * 4f);
											spinninpoint12 = spinninpoint12.RotatedByRandom(0.52359879016876221);
											Projectile.NewProjectile(vector15.X, vector15.Y, spinninpoint12.X, spinninpoint12.Y, 468, 18, 0f, Main.myPlayer, 0f, 0f);
										}
									}
								}
							}
							finally
							{
								((IDisposable)enumerator).Dispose();
							}
						}
					}
					int num108 = Math.Sign(player.Center.X - center13.X);
					if (num108 != 0)
					{
						npc.direction = (npc.spriteDirection = num108);
					}
					if (Main.netMode != 1)
					{
						vec13 = Vector2.Normalize(player.Center - center13 + player.velocity * 20f);
						if (vec13.HasNaNs())
						{
							vec13 = new Vector2((float)npc.direction, 0f);
						}
						Vector2 vector14 = npc.Center + new Vector2((float)(npc.direction * 30), 12f);
						for (int num106 = 0; num106 < 1; num106++)
						{
							Vector2 spinninpoint10 = vec13 * (6f + (float)Main.rand.NextDouble() * 4f);
							spinninpoint10 = spinninpoint10.RotatedByRandom(0.52359879016876221);
							Projectile.NewProjectile(vector14.X, vector14.Y, spinninpoint10.X, spinninpoint10.Y, 467, num103, 0f, Main.myPlayer, 0f, 0f);
						}
					}
				}
				npc.ai[1] += 1f;
				if (npc.ai[1] >= (float)(4 + num86 * num88))
				{
					npc.ai[0] = 0f;
					npc.ai[1] = 0f;
					npc.ai[3] += 1f;
					npc.velocity = Vector2.Zero;
					npc.netUpdate = true;
				}
			}
			else if (npc.ai[0] == 4f)
			{
				if (flag14)
				{
					npc.localAI[2] = 12f;
				}
				else
				{
					npc.localAI[2] = 11f;
				}
				if ((npc.ai[1] == 20f & flag14) && Main.netMode != 1)
				{
					List<int> list12 = new List<int>();
					for (int num105 = 0; num105 < 200; num105++)
					{
						if (Main.npc[num105].active && Main.npc[num105].type == 440 && Main.npc[num105].ai[3] == (float)npc.whoAmI)
						{
							list12.Add(num105);
						}
					}
					enumerator = list12.GetEnumerator();
					try
					{
						while (enumerator.MoveNext())
						{
							int current7 = enumerator.Current;
							NPC nPC8 = Main.npc[current7];
							Vector2 center9 = nPC8.Center;
							int num104 = Math.Sign(player.Center.X - center9.X);
							if (num104 != 0)
							{
								nPC8.direction = (nPC8.spriteDirection = num104);
							}
							if (Main.netMode != 1)
							{
								Vector2 vec9 = Vector2.Normalize(player.Center - center9 + player.velocity * 20f);
								if (vec9.HasNaNs())
								{
									vec9 = new Vector2((float)npc.direction, 0f);
								}
								Vector2 vector13 = center9 + new Vector2((float)(npc.direction * 30), 12f);
								for (int num102 = 0; num102 < 1; num102++)
								{
									Vector2 spinninpoint8 = vec9 * (6f + (float)Main.rand.NextDouble() * 4f);
									spinninpoint8 = spinninpoint8.RotatedByRandom(0.52359879016876221);
									Projectile.NewProjectile(vector13.X, vector13.Y, spinninpoint8.X, spinninpoint8.Y, 468, 18, 0f, Main.myPlayer, 0f, 0f);
								}
							}
						}
					}
					finally
					{
						((IDisposable)enumerator).Dispose();
					}
					if ((int)(npc.ai[1] - 20f) % num107 == 0)
					{
						Projectile.NewProjectile(npc.Center.X, npc.Center.Y - 100f, 0f, 0f, 465, num110, 0f, Main.myPlayer, 0f, 0f);
					}
				}
				npc.ai[1] += 1f;
				if (npc.ai[1] >= (float)(20 + num107))
				{
					npc.ai[0] = 0f;
					npc.ai[1] = 0f;
					npc.ai[3] += 1f;
					npc.velocity = Vector2.Zero;
					npc.netUpdate = true;
				}
			}
			else if (npc.ai[0] == 5f)
			{
				npc.localAI[2] = 10f;
				if (Vector2.Normalize(player.Center - center13).HasNaNs())
				{
					new Vector2((float)npc.direction, 0f);
				}
				if (npc.ai[1] >= 0f && npc.ai[1] < 30f)
				{
					flag13 = true;
					flag12 = true;
					float num101 = (npc.ai[1] - 0f) / 30f;
					npc.alpha = (int)(num101 * 255f);
				}
				else if (npc.ai[1] >= 30f && npc.ai[1] < 90f)
				{
					if ((npc.ai[1] == 30f && Main.netMode != 1) & flag14)
					{
						npc.localAI[1] += 1f;
						Vector2 spinningpoint = new Vector2(180f, 0f);
						List<int> list11 = new List<int>();
						for (int num100 = 0; num100 < 200; num100++)
						{
							if (Main.npc[num100].active && Main.npc[num100].type == 440 && Main.npc[num100].ai[3] == (float)npc.whoAmI)
							{
								list11.Add(num100);
							}
						}
						int num99 = 6 - list11.Count;
						if (num99 > 2)
						{
							num99 = 2;
						}
						int num98 = list11.Count + num99 + 1;
						float[] array = new float[num98];
						for (int num97 = 0; num97 < array.Length; num97++)
						{
							float[] array2 = array;
							int num125 = num97;
							Vector2 center15 = npc.Center;
							Vector2 spinningpoint3 = spinningpoint;
							double radians2 = (double)((float)num97 * 6.28318548f / (float)num98 - 1.57079637f);
							center14 = default(Vector2);
							array2[num125] = Vector2.Distance(center15 + spinningpoint3.RotatedBy(radians2, center14), player.Center);
						}
						int num96 = 0;
						for (int num95 = 1; num95 < array.Length; num95++)
						{
							if (array[num96] > array[num95])
							{
								num96 = num95;
							}
						}
						num96 = ((num96 >= num98 / 2) ? (num96 - num98 / 2) : (num96 + num98 / 2));
						int num93 = num99;
						for (int num92 = 0; num92 < array.Length; num92++)
						{
							if (num96 != num92)
							{
								Vector2 center16 = npc.Center;
								Vector2 spinningpoint4 = spinningpoint;
								double radians3 = (double)((float)num92 * 6.28318548f / (float)num98 - 1.57079637f);
								center14 = default(Vector2);
								Vector2 center8 = center16 + spinningpoint4.RotatedBy(radians3, center14);
								if (num93-- > 0)
								{
									int num91 = NPC.NewNPC((int)center8.X, (int)center8.Y + npc.height / 2, 440, npc.whoAmI, 0f, 0f, 0f, 0f, 255);
									Main.npc[num91].ai[3] = (float)npc.whoAmI;
									Main.npc[num91].netUpdate = true;
									Main.npc[num91].localAI[1] = npc.localAI[1];
								}
								else
								{
									int num90 = list11[-num93 - 1];
									Main.npc[num90].Center = center8;
									NetMessage.SendData(23, -1, -1, null, num90, 0f, 0f, 0f, 0, 0, 0);
								}
							}
						}
						npc.ai[2] = (float)Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0f, 0f, 490, 0, 0f, Main.myPlayer, 0f, (float)npc.whoAmI);
						Vector2 center17 = npc.Center;
						Vector2 spinningpoint5 = spinningpoint;
						double radians4 = (double)((float)num96 * 6.28318548f / (float)num98 - 1.57079637f);
						center14 = default(Vector2);
						npc.Center = center17 + spinningpoint5.RotatedBy(radians4, center14);
						npc.netUpdate = true;
						list11.Clear();
					}
					flag13 = true;
					flag12 = true;
					npc.alpha = 255;
					if (flag14)
					{
						Vector2 value3 = Main.projectile[(int)npc.ai[2]].Center;
						value3 -= npc.Center;
						if (value3 == Vector2.Zero)
						{
							value3 = -Vector2.UnitY;
						}
						value3.Normalize();
						if (Math.Abs(value3.Y) < 0.77f)
						{
							npc.localAI[2] = 11f;
						}
						else if (value3.Y < 0f)
						{
							npc.localAI[2] = 12f;
						}
						else
						{
							npc.localAI[2] = 10f;
						}
						int num89 = Math.Sign(value3.X);
						if (num89 != 0)
						{
							npc.direction = (npc.spriteDirection = num89);
						}
					}
					else
					{
						Vector2 value4 = Main.projectile[(int)Main.npc[(int)npc.ai[3]].ai[2]].Center;
						value4 -= npc.Center;
						if (value4 == Vector2.Zero)
						{
							value4 = -Vector2.UnitY;
						}
						value4.Normalize();
						if (Math.Abs(value4.Y) < 0.77f)
						{
							npc.localAI[2] = 11f;
						}
						else if (value4.Y < 0f)
						{
							npc.localAI[2] = 12f;
						}
						else
						{
							npc.localAI[2] = 10f;
						}
						int num87 = Math.Sign(value4.X);
						if (num87 != 0)
						{
							npc.direction = (npc.spriteDirection = num87);
						}
					}
				}
				else if (npc.ai[1] >= 90f && npc.ai[1] < 120f)
				{
					flag13 = true;
					flag12 = true;
					float num85 = (npc.ai[1] - 90f) / 30f;
					npc.alpha = 255 - (int)(num85 * 255f);
				}
				else if (npc.ai[1] >= 120f && npc.ai[1] < 420f)
				{
					flag12 = true;
					npc.alpha = 0;
					if (flag14)
					{
						Vector2 value5 = Main.projectile[(int)npc.ai[2]].Center;
						value5 -= npc.Center;
						if (value5 == Vector2.Zero)
						{
							value5 = -Vector2.UnitY;
						}
						value5.Normalize();
						if (Math.Abs(value5.Y) < 0.77f)
						{
							npc.localAI[2] = 11f;
						}
						else if (value5.Y < 0f)
						{
							npc.localAI[2] = 12f;
						}
						else
						{
							npc.localAI[2] = 10f;
						}
						int num84 = Math.Sign(value5.X);
						if (num84 != 0)
						{
							npc.direction = (npc.spriteDirection = num84);
						}
					}
					else
					{
						Vector2 value6 = Main.projectile[(int)Main.npc[(int)npc.ai[3]].ai[2]].Center;
						value6 -= npc.Center;
						if (value6 == Vector2.Zero)
						{
							value6 = -Vector2.UnitY;
						}
						value6.Normalize();
						if (Math.Abs(value6.Y) < 0.77f)
						{
							npc.localAI[2] = 11f;
						}
						else if (value6.Y < 0f)
						{
							npc.localAI[2] = 12f;
						}
						else
						{
							npc.localAI[2] = 10f;
						}
						int num82 = Math.Sign(value6.X);
						if (num82 != 0)
						{
							npc.direction = (npc.spriteDirection = num82);
						}
					}
				}
				npc.ai[1] += 1f;
				if (npc.ai[1] >= 420f)
				{
					flag12 = true;
					npc.ai[0] = 0f;
					npc.ai[1] = 0f;
					npc.ai[3] += 1f;
					npc.velocity = Vector2.Zero;
					npc.netUpdate = true;
				}
			}
			else if (npc.ai[0] == 6f)
			{
				npc.localAI[2] = 13f;
				npc.ai[1] += 1f;
				if (npc.ai[1] >= 120f)
				{
					npc.ai[0] = 0f;
					npc.ai[1] = 0f;
					npc.ai[3] += 1f;
					npc.velocity = Vector2.Zero;
					npc.netUpdate = true;
				}
			}
			else if (npc.ai[0] == 7f)
			{
				npc.localAI[2] = 11f;
				Vector2 vec8 = Vector2.Normalize(player.Center - center13);
				if (vec8.HasNaNs())
				{
					vec8 = new Vector2((float)npc.direction, 0f);
				}
				if ((npc.ai[1] >= 4f & flag14) && (int)(npc.ai[1] - 4f) % num124 == 0)
				{
					if ((int)(npc.ai[1] - 4f) / num124 == 2)
					{
						List<int> list10 = new List<int>();
						for (int num80 = 0; num80 < 200; num80++)
						{
							if (Main.npc[num80].active && Main.npc[num80].type == 440 && Main.npc[num80].ai[3] == (float)npc.whoAmI)
							{
								list10.Add(num80);
							}
						}
						enumerator = list10.GetEnumerator();
						try
						{
							while (enumerator.MoveNext())
							{
								int current6 = enumerator.Current;
								NPC nPC7 = Main.npc[current6];
								Vector2 center7 = nPC7.Center;
								int num79 = Math.Sign(player.Center.X - center7.X);
								if (num79 != 0)
								{
									nPC7.direction = (nPC7.spriteDirection = num79);
								}
								if (Main.netMode != 1)
								{
									vec8 = Vector2.Normalize(player.Center - center7 + player.velocity * 20f);
									if (vec8.HasNaNs())
									{
										vec8 = new Vector2((float)npc.direction, 0f);
									}
									Vector2 vector12 = center7 + new Vector2((float)(npc.direction * 30), 12f);
									for (int num78 = 0; (float)num78 < 5f; num78++)
									{
										Vector2 spinninpoint6 = vec8 * (6f + (float)Main.rand.NextDouble() * 4f);
										spinninpoint6 = spinninpoint6.RotatedByRandom(1.2566370964050293);
										Projectile.NewProjectile(vector12.X, vector12.Y, spinninpoint6.X, spinninpoint6.Y, 468, 18, 0f, Main.myPlayer, 0f, 0f);
									}
								}
							}
						}
						finally
						{
							((IDisposable)enumerator).Dispose();
						}
					}
					int num77 = Math.Sign(player.Center.X - center13.X);
					if (num77 != 0)
					{
						npc.direction = (npc.spriteDirection = num77);
					}
					if (Main.netMode != 1)
					{
						vec8 = Vector2.Normalize(player.Center - center13 + player.velocity * 20f);
						if (vec8.HasNaNs())
						{
							vec8 = new Vector2((float)npc.direction, 0f);
						}
						Vector2 vector11 = npc.Center + new Vector2((float)(npc.direction * 30), 12f);
						float scaleFactor = 8f;
						float num76 = 0.251327425f;
						for (int num75 = 0; (float)num75 < 5f; num75++)
						{
							Vector2 vector10 = vec8 * scaleFactor;
							Vector2 spinningpoint6 = vector10;
							double radians5 = (double)(num76 * (float)num75 - (1.2566371f - num76) / 2f);
							center14 = default(Vector2);
							vector10 = spinningpoint6.RotatedBy(radians5, center14);
							float ai = (Main.rand.NextFloat() - 0.5f) * 0.3f * 6.28318548f / 60f;
							int num74 = NPC.NewNPC((int)vector11.X, (int)vector11.Y + 7, 522, 0, 0f, ai, vector10.X, vector10.Y, 255);
							Main.npc[num74].velocity = vector10;
						}
					}
				}
				npc.ai[1] += 1f;
				if (npc.ai[1] >= (float)(4 + num124 * num123))
				{
					npc.ai[0] = 0f;
					npc.ai[1] = 0f;
					npc.ai[3] += 1f;
					npc.velocity = Vector2.Zero;
					npc.netUpdate = true;
				}
			}
			else if (npc.ai[0] == 8f)
			{
				npc.localAI[2] = 13f;
				if ((npc.ai[1] >= 4f & flag14) && (int)(npc.ai[1] - 4f) % num122 == 0)
				{
					List<int> list9 = new List<int>();
					for (int num73 = 0; num73 < 200; num73++)
					{
						if (Main.npc[num73].active && Main.npc[num73].type == 440 && Main.npc[num73].ai[3] == (float)npc.whoAmI)
						{
							list9.Add(num73);
						}
					}
					int num72 = list9.Count + 1;
					if (num72 > 3)
					{
						num72 = 3;
					}
					int num71 = Math.Sign(player.Center.X - center13.X);
					if (num71 != 0)
					{
						npc.direction = (npc.spriteDirection = num71);
					}
					if (Main.netMode != 1)
					{
						for (int num70 = 0; num70 < num72; num70++)
						{
							Point point3 = npc.Center.ToTileCoordinates();
							Point point2 = Main.player[npc.target].Center.ToTileCoordinates();
							Vector2 vector19 = Main.player[npc.target].Center - npc.Center;
							int num69 = 20;
							int num68 = 3;
							int num67 = 7;
							int num66 = 2;
							int num65 = 0;
							bool flag9 = false;
							if (vector19.Length() > 2000f)
							{
								flag9 = true;
							}
							while (!flag9 && num65 < 100)
							{
								num65++;
								int num64 = Main.rand.Next(point2.X - num69, point2.X + num69 + 1);
								int num63 = Main.rand.Next(point2.Y - num69, point2.Y + num69 + 1);
								if ((num63 < point2.Y - num67 || num63 > point2.Y + num67 || num64 < point2.X - num67 || num64 > point2.X + num67) && (num63 < point3.Y - num68 || num63 > point3.Y + num68 || num64 < point3.X - num68 || num64 > point3.X + num68) && !Main.tile[num64, num63].nactive())
								{
									bool flag8 = true;
									if (flag8 && Collision.SolidTiles(num64 - num66, num64 + num66, num63 - num66, num63 + num66))
									{
										flag8 = false;
									}
									if (flag8)
									{
										NPC.NewNPC(num64 * 16 + 8, num63 * 16 + 8, 523, 0, (float)npc.whoAmI, 0f, 0f, 0f, 255);
										break;
									}
								}
							}
						}
					}
				}
				npc.ai[1] += 1f;
				if (npc.ai[1] >= (float)(4 + num122 * num121))
				{
					npc.ai[0] = 0f;
					npc.ai[1] = 0f;
					npc.ai[3] += 1f;
					npc.velocity = Vector2.Zero;
					npc.netUpdate = true;
				}
			}
			if (!flag14)
			{
				npc.ai[3] = num119;
			}
			npc.dontTakeDamage = flag13;
			npc.chaseable = !flag12;
		}
	}
}
