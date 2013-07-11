using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.HabboHotel.Pets;
using Phoenix.HabboHotel.Rooms;
using Phoenix.Storage;
using Phoenix.HabboHotel.Pathfinding;
namespace Phoenix.HabboHotel.RoomBots
{
	internal sealed class Class103 : Class99
	{
		private int int_2;
		private int int_3;
		public Class103(int int_4)
		{
			this.int_2 = new Random((int_4 ^ 2) + DateTime.Now.Millisecond).Next(25, 60);
			this.int_3 = new Random((int_4 ^ 2) + DateTime.Now.Millisecond).Next(10, 60);
		}
		private int method_4()
		{
			Class33 @class = base.method_2();
			int result = 5;
			if (@class.class15_0.Level >= 1)
			{
				result = Phoenix.smethod_5(1, 8);
			}
			else
			{
				if (@class.class15_0.Level >= 5)
				{
					result = Phoenix.smethod_5(1, 7);
				}
				else
				{
					if (@class.class15_0.Level >= 10)
					{
						result = Phoenix.smethod_5(1, 6);
					}
				}
			}
			return result;
		}
		private void method_5(int int_4, int int_5, bool bool_0)
		{
			Class33 @class = base.method_2();
			if (bool_0)
			{
				int int_6 = Phoenix.smethod_5(0, base.method_1().Class28_0.int_4);
				int int_7 = Phoenix.smethod_5(0, base.method_1().Class28_0.int_5);
				@class.method_5(int_6, int_7);
			}
			else
			{
				if (int_4 < base.method_1().Class28_0.int_4 && int_5 < base.method_1().Class28_0.int_5 && int_4 >= 0 && int_5 >= 0)
				{
					@class.method_5(int_4, int_5);
				}
			}
		}
		public override void OnSelfEnterRoom()
		{
			if (base.method_2().class15_0.X > 0 && base.method_2().class15_0.Y > 0)
			{
				base.method_2().int_3 = base.method_2().class15_0.X;
				base.method_2().int_4 = base.method_2().class15_0.Y;
			}
			this.method_5(0, 0, true);
		}
		public override void OnSelfLeaveRoom(bool bool_0)
		{
			if (base.method_3().class33_0 != null)
			{
				Class33 class33_ = base.method_3().class33_0;
				if (class33_.class34_1 != null && class33_ == base.method_3().class33_0)
				{
					base.method_3().class33_0 = null;
					class33_.method_16().GetHabbo().method_24().method_2(-1, true);
					class33_.class34_1 = null;
					class33_.class33_0 = null;
				}
			}
			using (DatabaseClient @class = Phoenix.GetDatabase().GetClient())
			{
				if (base.method_2().class15_0.DBState == DatabaseUpdateState.NeedsInsert)
				{
					@class.AddParamWithValue("petname" + base.method_2().class15_0.PetId, base.method_2().class15_0.Name);
					@class.AddParamWithValue("petcolor" + base.method_2().class15_0.PetId, base.method_2().class15_0.Color);
					@class.AddParamWithValue("petrace" + base.method_2().class15_0.PetId, base.method_2().class15_0.Race);
					@class.ExecuteQuery(string.Concat(new object[]
					{
						"INSERT INTO `user_pets` VALUES ('",
						base.method_2().class15_0.PetId,
						"', '",
						base.method_2().class15_0.OwnerId,
						"', '0', @petname",
						base.method_2().class15_0.PetId,
						", @petrace",
						base.method_2().class15_0.PetId,
						", @petcolor",
						base.method_2().class15_0.PetId,
						", '",
						base.method_2().class15_0.Type,
						"', '",
						base.method_2().class15_0.Expirience,
						"', '",
						base.method_2().class15_0.Energy,
						"', '",
						base.method_2().class15_0.Nutrition,
						"', '",
						base.method_2().class15_0.Respect,
						"', '",
						base.method_2().class15_0.CreationStamp,
						"', '",
						base.method_2().class15_0.X,
						"', '",
						base.method_2().class15_0.Y,
						"', '",
						base.method_2().class15_0.Z,
						"');"
					}));
				}
				else
				{
					@class.ExecuteQuery(string.Concat(new object[]
					{
						"UPDATE user_pets SET room_id = '0', expirience = '",
						base.method_2().class15_0.Expirience,
						"', energy = '",
						base.method_2().class15_0.Energy,
						"', nutrition = '",
						base.method_2().class15_0.Nutrition,
						"', respect = '",
						base.method_2().class15_0.Respect,
						"' WHERE id = '",
						base.method_2().class15_0.PetId,
						"' LIMIT 1; "
					}));
				}
				base.method_2().class15_0.DBState = DatabaseUpdateState.Updated;
			}
		}
		public override void OnUserEnterRoom(Class33 class33_0)
		{
		}
		public override void OnUserLeaveRoom(GameClient class16_0)
		{
			if (class16_0 != null && class16_0.GetHabbo() != null)
			{
				string string_ = class16_0.GetHabbo().Username;
				Class33 @class = base.method_1().method_53(class16_0.GetHabbo().Id);
				if (base.method_3().class33_0 != null && @class != null && @class.class34_1 != null && @class == base.method_3().class33_0)
				{
					base.method_3().class33_0 = null;
				}
				try
				{
					if (string_.ToLower() == base.method_2().class15_0.OwnerName.ToLower() && string_.ToLower() != base.method_1().Owner.ToLower())
					{
						base.method_1().method_6(base.method_2().class15_0.VirtualId, false);
						class16_0.GetHabbo().method_23().method_7(base.method_2().class15_0);
					}
				}
				catch
				{
				}
			}
		}
		public override void OnUserSay(Class33 class33_0, string string_0)
		{
			Class33 @class = base.method_2();
			if (@class.class34_0.class33_0 == null)
			{
				if (string_0.ToLower().Equals(@class.class15_0.Name.ToLower()))
				{
					@class.method_9(Class107.smethod_0(@class.int_3, @class.int_4, class33_0.int_3, class33_0.int_4));
				}
				else
				{
					if (string_0.ToLower().StartsWith(@class.class15_0.Name.ToLower() + " ") && class33_0.method_16().GetHabbo().Username.ToLower() == base.method_2().class15_0.OwnerName.ToLower())
					{
						string key = string_0.Substring(@class.class15_0.Name.ToLower().Length + 1);
						if ((@class.class15_0.Energy >= 10 && this.method_4() < 6) || @class.class15_0.Level >= 15)
						{
							@class.Statusses.Clear();
							if (!Phoenix.GetGame().GetRoleManager().dictionary_5.ContainsKey(key))
							{
								string[] array = new string[]
								{
									PhoenixEnvironment.GetExternalText("pet_response_confused1"),
									PhoenixEnvironment.GetExternalText("pet_response_confused2"),
									PhoenixEnvironment.GetExternalText("pet_response_confused3"),
									PhoenixEnvironment.GetExternalText("pet_response_confused4"),
									PhoenixEnvironment.GetExternalText("pet_response_confused5"),
									PhoenixEnvironment.GetExternalText("pet_response_confused6"),
									PhoenixEnvironment.GetExternalText("pet_response_confused7")
								};
								Random random = new Random();
								@class.method_1(null, array[random.Next(0, array.Length - 1)], false);
							}
							else
							{
								switch (Phoenix.GetGame().GetRoleManager().dictionary_5[key])
								{
								case 1:
									@class.class15_0.AddExpirience(10, -25);
									@class.method_1(null, PhoenixEnvironment.GetExternalText("pet_response_sleep"), false);
									@class.Statusses.Add("lay", @class.double_0.ToString());
									break;
								case 2:
									this.method_5(0, 0, true);
									@class.class15_0.AddExpirience(5, 5);
									break;
								case 3:
									@class.class15_0.AddExpirience(5, 5);
									@class.Statusses.Add("sit", @class.double_0.ToString());
									break;
								case 4:
									@class.class15_0.AddExpirience(5, 5);
									@class.Statusses.Add("lay", @class.double_0.ToString());
									break;
								case 5:
									@class.class15_0.AddExpirience(10, 10);
									this.int_3 = 60;
									break;
								case 6:
								{
									int int_ = class33_0.int_3;
									int int_2 = class33_0.int_4;
									if (class33_0.int_8 == 4)
									{
										int_2 = class33_0.int_4 + 1;
									}
									else
									{
										if (class33_0.int_8 == 0)
										{
											int_2 = class33_0.int_4 - 1;
										}
										else
										{
											if (class33_0.int_8 == 6)
											{
												int_ = class33_0.int_3 - 1;
											}
											else
											{
												if (class33_0.int_8 == 2)
												{
													int_ = class33_0.int_3 + 1;
												}
												else
												{
													if (class33_0.int_8 == 3)
													{
														int_ = class33_0.int_3 + 1;
														int_2 = class33_0.int_4 + 1;
													}
													else
													{
														if (class33_0.int_8 == 1)
														{
															int_ = class33_0.int_3 + 1;
															int_2 = class33_0.int_4 - 1;
														}
														else
														{
															if (class33_0.int_8 == 7)
															{
																int_ = class33_0.int_3 - 1;
																int_2 = class33_0.int_4 - 1;
															}
															else
															{
																if (class33_0.int_8 == 5)
																{
																	int_ = class33_0.int_3 - 1;
																	int_2 = class33_0.int_4 + 1;
																}
															}
														}
													}
												}
											}
										}
									}
									@class.class15_0.AddExpirience(15, 15);
									this.method_5(int_, int_2, false);
									break;
								}
								case 7:
									@class.class15_0.AddExpirience(20, 20);
									@class.Statusses.Add("ded", @class.double_0.ToString());
									break;
								case 8:
									@class.class15_0.AddExpirience(10, 10);
									@class.Statusses.Add("beg", @class.double_0.ToString());
									break;
								case 9:
									@class.class15_0.AddExpirience(15, 15);
									@class.Statusses.Add("jmp", @class.double_0.ToString());
									break;
								case 10:
									@class.class15_0.AddExpirience(25, 25);
									@class.method_1(null, PhoenixEnvironment.GetExternalText("pet_response_silent"), false);
									this.int_2 = 120;
									break;
								case 11:
									@class.class15_0.AddExpirience(15, 15);
									this.int_2 = 2;
									break;
								}
							}
						}
						else
						{
							string[] array2 = new string[]
							{
								PhoenixEnvironment.GetExternalText("pet_response_sleeping1"),
								PhoenixEnvironment.GetExternalText("pet_response_sleeping2"),
								PhoenixEnvironment.GetExternalText("pet_response_sleeping3"),
								PhoenixEnvironment.GetExternalText("pet_response_sleeping4"),
								PhoenixEnvironment.GetExternalText("pet_response_sleeping5")
							};
							string[] array3 = new string[]
							{
								PhoenixEnvironment.GetExternalText("pet_response_refusal1"),
								PhoenixEnvironment.GetExternalText("pet_response_refusal2"),
								PhoenixEnvironment.GetExternalText("pet_response_refusal3"),
								PhoenixEnvironment.GetExternalText("pet_response_refusal4"),
								PhoenixEnvironment.GetExternalText("pet_response_refusal5")
							};
							@class.int_10 = @class.int_12;
							@class.int_11 = @class.int_13;
							@class.Statusses.Clear();
							if (@class.class15_0.Energy < 10)
							{
								Random random2 = new Random();
								@class.method_1(null, array2[random2.Next(0, array2.Length - 1)], false);
								if (@class.class15_0.Type != 13u)
								{
									@class.Statusses.Add("lay", @class.double_0.ToString());
								}
								else
								{
									@class.Statusses.Add("lay", (@class.double_0 - 1.0).ToString());
								}
								this.int_2 = 25;
								this.int_3 = 20;
								base.method_2().class15_0.PetEnergy(-25);
							}
							else
							{
								Random random2 = new Random();
								@class.method_1(null, array3[random2.Next(0, array3.Length - 1)], false);
							}
						}
						@class.bool_7 = true;
					}
				}
			}
		}
		public override void OnUserShout(Class33 class33_0, string string_0)
		{
		}
		public override void OnTimerTick()
		{
			if (this.int_2 <= 0)
			{
				Class33 @class = base.method_2();
				string[] array = new string[]
				{
					PhoenixEnvironment.GetExternalText("pet_chatter_dog1"),
					PhoenixEnvironment.GetExternalText("pet_chatter_dog2"),
					PhoenixEnvironment.GetExternalText("pet_chatter_dog3"),
					PhoenixEnvironment.GetExternalText("pet_chatter_dog4"),
					PhoenixEnvironment.GetExternalText("pet_chatter_dog5")
				};
				string[] array2 = new string[]
				{
					PhoenixEnvironment.GetExternalText("pet_chatter_cat1"),
					PhoenixEnvironment.GetExternalText("pet_chatter_cat2"),
					PhoenixEnvironment.GetExternalText("pet_chatter_cat3"),
					PhoenixEnvironment.GetExternalText("pet_chatter_cat4"),
					PhoenixEnvironment.GetExternalText("pet_chatter_cat5")
				};
				string[] array3 = new string[]
				{
					PhoenixEnvironment.GetExternalText("pet_chatter_croc1"),
					PhoenixEnvironment.GetExternalText("pet_chatter_croc2"),
					PhoenixEnvironment.GetExternalText("pet_chatter_croc3"),
					PhoenixEnvironment.GetExternalText("pet_chatter_croc4"),
					PhoenixEnvironment.GetExternalText("pet_chatter_croc5")
				};
				string[] array4 = new string[]
				{
					PhoenixEnvironment.GetExternalText("pet_chatter_dog1"),
					PhoenixEnvironment.GetExternalText("pet_chatter_dog2"),
					PhoenixEnvironment.GetExternalText("pet_chatter_dog3"),
					PhoenixEnvironment.GetExternalText("pet_chatter_dog4"),
					PhoenixEnvironment.GetExternalText("pet_chatter_dog5")
				};
				string[] array5 = new string[]
				{
					PhoenixEnvironment.GetExternalText("pet_chatter_bear1"),
					PhoenixEnvironment.GetExternalText("pet_chatter_bear2"),
					PhoenixEnvironment.GetExternalText("pet_chatter_bear3"),
					PhoenixEnvironment.GetExternalText("pet_chatter_bear4"),
					PhoenixEnvironment.GetExternalText("pet_chatter_bear5")
				};
				string[] array6 = new string[]
				{
					PhoenixEnvironment.GetExternalText("pet_chatter_pig1"),
					PhoenixEnvironment.GetExternalText("pet_chatter_pig2"),
					PhoenixEnvironment.GetExternalText("pet_chatter_pig3"),
					PhoenixEnvironment.GetExternalText("pet_chatter_pig4"),
					PhoenixEnvironment.GetExternalText("pet_chatter_pig5")
				};
				string[] array7 = new string[]
				{
					PhoenixEnvironment.GetExternalText("pet_chatter_lion1"),
					PhoenixEnvironment.GetExternalText("pet_chatter_lion2"),
					PhoenixEnvironment.GetExternalText("pet_chatter_lion3"),
					PhoenixEnvironment.GetExternalText("pet_chatter_lion4"),
					PhoenixEnvironment.GetExternalText("pet_chatter_lion5")
				};
				string[] array8 = new string[]
				{
					PhoenixEnvironment.GetExternalText("pet_chatter_rhino1"),
					PhoenixEnvironment.GetExternalText("pet_chatter_rhino2"),
					PhoenixEnvironment.GetExternalText("pet_chatter_rhino3"),
					PhoenixEnvironment.GetExternalText("pet_chatter_rhino4"),
					PhoenixEnvironment.GetExternalText("pet_chatter_rhino5")
				};
				string[] array9 = new string[]
				{
					PhoenixEnvironment.GetExternalText("pet_chatter_spider1"),
					PhoenixEnvironment.GetExternalText("pet_chatter_spider2"),
					PhoenixEnvironment.GetExternalText("pet_chatter_spider3"),
					PhoenixEnvironment.GetExternalText("pet_chatter_spider4"),
					PhoenixEnvironment.GetExternalText("pet_chatter_spider5")
				};
				string[] array10 = new string[]
				{
					PhoenixEnvironment.GetExternalText("pet_chatter_turtle1"),
					PhoenixEnvironment.GetExternalText("pet_chatter_turtle2"),
					PhoenixEnvironment.GetExternalText("pet_chatter_turtle3"),
					PhoenixEnvironment.GetExternalText("pet_chatter_turtle4"),
					PhoenixEnvironment.GetExternalText("pet_chatter_turtle5")
				};
				string[] array11 = new string[]
				{
					PhoenixEnvironment.GetExternalText("pet_chatter_chic1"),
					PhoenixEnvironment.GetExternalText("pet_chatter_chic2"),
					PhoenixEnvironment.GetExternalText("pet_chatter_chic3"),
					PhoenixEnvironment.GetExternalText("pet_chatter_chic4"),
					PhoenixEnvironment.GetExternalText("pet_chatter_chic5")
				};
				string[] array12 = new string[]
				{
					PhoenixEnvironment.GetExternalText("pet_chatter_frog1"),
					PhoenixEnvironment.GetExternalText("pet_chatter_frog2"),
					PhoenixEnvironment.GetExternalText("pet_chatter_frog3"),
					PhoenixEnvironment.GetExternalText("pet_chatter_frog4"),
					PhoenixEnvironment.GetExternalText("pet_chatter_frog5")
				};
				string[] array13 = new string[]
				{
					PhoenixEnvironment.GetExternalText("pet_chatter_dragon1"),
					PhoenixEnvironment.GetExternalText("pet_chatter_dragon2"),
					PhoenixEnvironment.GetExternalText("pet_chatter_dragon3"),
					PhoenixEnvironment.GetExternalText("pet_chatter_dragon4"),
					PhoenixEnvironment.GetExternalText("pet_chatter_dragon5")
				};
				string[] array14 = new string[]
				{
					PhoenixEnvironment.GetExternalText("pet_chatter_horse1"),
					PhoenixEnvironment.GetExternalText("pet_chatter_horse2"),
					PhoenixEnvironment.GetExternalText("pet_chatter_horse3"),
					PhoenixEnvironment.GetExternalText("pet_chatter_horse4"),
					PhoenixEnvironment.GetExternalText("pet_chatter_horse5")
				};
				string[] array15 = new string[]
				{
					PhoenixEnvironment.GetExternalText("pet_chatter_monkey1"),
					PhoenixEnvironment.GetExternalText("pet_chatter_monkey2"),
					PhoenixEnvironment.GetExternalText("pet_chatter_monkey3"),
					PhoenixEnvironment.GetExternalText("pet_chatter_monkey4"),
					PhoenixEnvironment.GetExternalText("pet_chatter_monkey5")
				};
				string[] array16 = new string[]
				{
					PhoenixEnvironment.GetExternalText("pet_chatter_generic1"),
					PhoenixEnvironment.GetExternalText("pet_chatter_generic2"),
					PhoenixEnvironment.GetExternalText("pet_chatter_generic3"),
					PhoenixEnvironment.GetExternalText("pet_chatter_generic4"),
					PhoenixEnvironment.GetExternalText("pet_chatter_generic5")
				};
				string[] array17 = new string[]
				{
					"sit",
					"lay",
					"snf",
					"ded",
					"jmp",
					"snf",
					"sit",
					"snf"
				};
				string[] array18 = new string[]
				{
					"sit",
					"lay"
				};
				string[] array19 = new string[]
				{
					"wng",
					"grn",
					"flm",
					"std",
					"swg",
					"sit",
					"lay",
					"snf",
					"plf",
					"jmp",
					"flm",
					"crk",
					"rlx",
					"flm"
				};
				if (@class != null)
				{
					Random random = new Random();
					int num = Phoenix.smethod_5(1, 4);
					if (num == 2)
					{
						@class.Statusses.Clear();
						if (base.method_2().class34_0.class33_0 == null)
						{
							if (@class.class15_0.Type == 13u)
							{
								@class.Statusses.Add(array18[random.Next(0, array18.Length - 1)], @class.double_0.ToString());
							}
							else
							{
								if (@class.class15_0.Type != 12u)
								{
									@class.Statusses.Add(array17[random.Next(0, array17.Length - 1)], @class.double_0.ToString());
								}
								else
								{
									@class.Statusses.Add(array19[random.Next(0, array19.Length - 1)], @class.double_0.ToString());
								}
							}
						}
					}
					switch (@class.class15_0.Type)
					{
					case 0u:
						@class.method_1(null, array[random.Next(0, array.Length - 1)], false);
						break;
					case 1u:
						@class.method_1(null, array2[random.Next(0, array2.Length - 1)], false);
						break;
					case 2u:
						@class.method_1(null, array3[random.Next(0, array3.Length - 1)], false);
						break;
					case 3u:
						@class.method_1(null, array4[random.Next(0, array4.Length - 1)], false);
						break;
					case 4u:
						@class.method_1(null, array5[random.Next(0, array5.Length - 1)], false);
						break;
					case 5u:
						@class.method_1(null, array6[random.Next(0, array6.Length - 1)], false);
						break;
					case 6u:
						@class.method_1(null, array7[random.Next(0, array7.Length - 1)], false);
						break;
					case 7u:
						@class.method_1(null, array8[random.Next(0, array8.Length - 1)], false);
						break;
					case 8u:
						@class.method_1(null, array9[random.Next(0, array9.Length - 1)], false);
						break;
					case 9u:
						@class.method_1(null, array10[random.Next(0, array10.Length - 1)], false);
						break;
					case 10u:
						@class.method_1(null, array11[random.Next(0, array11.Length - 1)], false);
						break;
					case 11u:
						@class.method_1(null, array12[random.Next(0, array12.Length - 1)], false);
						break;
					case 12u:
						@class.method_1(null, array13[random.Next(0, array13.Length - 1)], false);
						break;
					case 13u:
						@class.method_1(null, array14[random.Next(0, array14.Length - 1)], false);
						break;
					case 14u:
						@class.method_1(null, array15[random.Next(0, array15.Length - 1)], false);
						break;
					default:
						@class.method_1(null, array16[random.Next(0, array16.Length - 1)], false);
						break;
					}
				}
				this.int_2 = Phoenix.smethod_5(30, 120);
			}
			else
			{
				this.int_2--;
			}
			if (this.int_3 <= 0)
			{
				base.method_2().class15_0.PetEnergy(-10);
				if (base.method_2().class34_0.class33_0 == null)
				{
					this.method_5(0, 0, true);
				}
				this.int_3 = 30;
			}
			else
			{
				this.int_3--;
			}
		}
	}
}
