using System;
using System.Collections.Generic;
using System.Linq;
using Phoenix.Core;
using Phoenix.HabboHotel.Pathfinding;
using Phoenix.HabboHotel.Items;
using Phoenix.Messages;
using Phoenix.HabboHotel.Rooms;
using Phoenix.HabboHotel.Items.Interactors;
namespace Phoenix.HabboHotel.Items
{
	internal sealed class UserItemData
	{
		internal enum Enum5
		{
			const_0,
			const_1,
			const_2
		}
		internal uint uint_0;
		internal uint uint_1;
		internal uint uint_2;
		internal string string_0;
		internal bool bool_0;
		internal string string_1;
		internal string string_2;
		internal string string_3;
		internal string string_4;
		internal string string_5;
		internal string string_6;
		internal int int_0;
		private Dictionary<int, Coordinates> dictionary_0;
		private int int_1;
		private int int_2;
		private double double_0;
		internal UserItemData.Enum5 enum5_0;
		internal int int_3;
		internal string string_7;
		internal bool bool_1;
		internal int int_4;
		internal uint uint_3;
		internal uint uint_4;
		internal Dictionary<Class33, int> dictionary_1;
		private FurnitureData class40_0;
		private Room class14_0;
		private bool bool_2;
		private bool bool_3;
		private bool bool_4;
		internal Dictionary<int, Coordinates> Dictionary_0
		{
			get
			{
				return this.dictionary_0;
			}
		}
		internal int Int32_0
		{
			get
			{
				return this.int_1;
			}
		}
		internal int Int32_1
		{
			get
			{
				return this.int_2;
			}
		}
		internal double Double_0
		{
			get
			{
				return this.double_0;
			}
		}
		internal bool Boolean_0
		{
			get
			{
				return this.bool_4;
			}
		}
		internal ThreeDCoord GStruct1_0
		{
			get
			{
				return new ThreeDCoord(this.int_1, this.int_2);
			}
		}
		internal double Double_1
		{
			get
			{
				double result;
				if (this.GetBaseItem().list_0.Count > 1)
				{
					int index;
					if (int.TryParse(this.string_0, out index))
					{
						result = this.double_0 + this.GetBaseItem().list_0[index];
					}
					else
					{
						result = this.double_0 + this.GetBaseItem().Height;
					}
				}
				else
				{
					result = this.double_0 + this.GetBaseItem().Height;
				}
				return result;
			}
		}
		internal bool Boolean_1
		{
			get
			{
				return this.bool_2;
			}
		}
		internal bool Boolean_2
		{
			get
			{
				return this.bool_3;
			}
		}
		internal ThreeDCoord GStruct1_1
		{
			get
			{
				ThreeDCoord result = new ThreeDCoord(this.int_1, this.int_2);
				if (this.int_3 == 0)
				{
					result.y--;
				}
				else
				{
					if (this.int_3 == 2)
					{
						result.x++;
					}
					else
					{
						if (this.int_3 == 4)
						{
							result.y++;
						}
						else
						{
							if (this.int_3 == 6)
							{
								result.x--;
							}
						}
					}
				}
				return result;
			}
		}
		internal ThreeDCoord GStruct1_2
		{
			get
			{
				ThreeDCoord result = new ThreeDCoord(this.int_1, this.int_2);
				if (this.int_3 == 0)
				{
					result.y++;
				}
				else
				{
					if (this.int_3 == 2)
					{
						result.x--;
					}
					else
					{
						if (this.int_3 == 4)
						{
							result.y--;
						}
						else
						{
							if (this.int_3 == 6)
							{
								result.x++;
							}
						}
					}
				}
				return result;
			}
		}
		internal Class69 Class69_0
		{
			get
			{
				string text = this.GetBaseItem().InteractionType.ToLower();
				Class69 result;
				switch (text)
				{
				case "ball":
					result = new Class96();
					return result;
				case "teleport":
					result = new Class95();
					return result;
				case "bottle":
					result = new Class94();
					return result;
				case "dice":
					result = new Class93();
					return result;
				case "habbowheel":
					result = new Class92();
					return result;
				case "loveshuffler":
					result = new Class91();
					return result;
				case "onewaygate":
					result = new Class90();
					return result;
				case "alert":
					result = new Class89();
					return result;
				case "vendingmachine":
					result = new Class88();
					return result;
				case "gate":
					result = new Class87(this.GetBaseItem().int_3);
					return result;
				case "scoreboard":
					result = new Class86();
					return result;
				case "counter":
					result = new Class85();
					return result;
				case "wired":
					result = new Class84();
					return result;
				case "wf_trg_onsay":
					result = new Class83();
					return result;
				case "wf_trg_enterroom":
					result = new Class82();
					return result;
				case "wf_act_saymsg":
				case "wf_act_give_phx":
				case "wf_cnd_phx":
					result = new Class81();
					return result;
				case "wf_trg_furnistate":
				case "wf_trg_onfurni":
				case "wf_trg_offfurni":
				case "wf_act_moveuser":
				case "wf_act_togglefurni":
					result = new Class80();
					return result;
				case "wf_trg_gameend":
				case "wf_trg_gamestart":
					result = new Class79();
					return result;
				case "wf_trg_timer":
					result = new Class78();
					return result;
				case "wf_act_givepoints":
					result = new Class77();
					return result;
				case "wf_trg_attime":
					result = new Class76();
					return result;
				case "wf_trg_atscore":
					result = new Class75();
					return result;
				case "wf_act_moverotate":
					result = new Class74();
					return result;
				case "wf_act_matchfurni":
					result = new Class73();
					return result;
				case "wf_cnd_trggrer_on_frn":
				case "wf_cnd_furnis_hv_avtrs":
				case "wf_cnd_has_furni_on":
					result = new Class72();
					return result;
				case "puzzlebox":
					result = new Class71();
					return result;
				}
				result = new Class70(this.GetBaseItem().int_3);
				return result;
			}
		}
		public UserItemData(uint uint_5, uint uint_6, uint uint_7, string string_8, int int_5, int int_6, double double_1, int int_7, string string_9, Room class14_1)
		{
			this.uint_0 = uint_5;
			this.uint_1 = uint_6;
			this.uint_2 = uint_7;
			this.string_0 = string_8;
			this.int_1 = int_5;
			this.int_2 = int_6;
			this.double_0 = double_1;
			this.int_3 = int_7;
			this.string_7 = string_9;
			this.bool_1 = false;
			this.int_4 = 0;
			this.uint_3 = 0u;
			this.uint_4 = 0u;
			this.bool_0 = false;
			this.string_1 = "none";
			this.enum5_0 = UserItemData.Enum5.const_0;
			this.string_2 = "";
			this.string_3 = "";
			this.string_4 = "";
			this.string_5 = "";
			this.string_6 = "";
			this.int_0 = 0;
			this.dictionary_1 = new Dictionary<Class33, int>();
			this.class40_0 = Phoenix.GetGame().GetItemManager().method_2(uint_7);
			this.class14_0 = class14_1;
			if (this.GetBaseItem() == null)
			{
                Logging.LogException("Unknown baseID: " + uint_7);
			}
			string text = this.GetBaseItem().InteractionType.ToLower();
			if (text != null)
			{
				if (!(text == "teleport"))
				{
					if (!(text == "roller"))
					{
						if (!(text == "blue_score"))
						{
							if (!(text == "green_score"))
							{
								if (!(text == "red_score"))
								{
									if (text == "yellow_score")
									{
										this.string_1 = "yellow";
									}
								}
								else
								{
									this.string_1 = "red";
								}
							}
							else
							{
								this.string_1 = "green";
							}
						}
						else
						{
							this.string_1 = "blue";
						}
					}
					else
					{
						this.bool_4 = true;
						class14_1.Boolean_1 = true;
					}
				}
				else
				{
					this.method_3(0);
				}
			}
			this.bool_2 = (this.GetBaseItem().char_0 == 'i');
			this.bool_3 = (this.GetBaseItem().char_0 == 's');
			this.dictionary_0 = this.method_8().method_94(this.GetBaseItem().int_2, this.GetBaseItem().int_1, this.int_1, this.int_2, int_7);
		}
		internal void method_0(int int_5, int int_6, double double_1)
		{
			this.int_1 = int_5;
			this.int_2 = int_6;
			this.double_0 = double_1;
			this.dictionary_0 = this.method_8().method_94(this.GetBaseItem().int_2, this.GetBaseItem().int_1, this.int_1, this.int_2, this.int_3);
		}
		internal ThreeDCoord method_1(int int_5)
		{
			ThreeDCoord result = new ThreeDCoord(this.int_1, this.int_2);
			if (int_5 == 0)
			{
				result.y++;
			}
			else
			{
				if (int_5 == 2)
				{
					result.x--;
				}
				else
				{
					if (int_5 == 4)
					{
						result.y--;
					}
					else
					{
						if (int_5 == 6)
						{
							result.x++;
						}
					}
				}
			}
			return result;
		}
		internal void method_2()
		{
			this.int_4--;
			if (this.int_4 <= 0)
			{
				this.bool_1 = false;
				this.int_4 = 0;
				if (this.bool_0 && this.int_0 > 0)
				{
					this.int_0 += 500;
					this.method_8().int_13 += 500;
					this.bool_1 = true;
					if (this.int_0 > Phoenix.GetGame().GetItemManager().method_4(Convert.ToInt32(this.string_0)).int_1)
					{
						ServerMessage gClass = new ServerMessage(327u);
						gClass.AppendInt32(7);
						gClass.AppendInt32(6);
						gClass.AppendInt32(7);
						gClass.AppendInt32(0);
						gClass.AppendInt32(0);
						this.method_8().SendMessage(gClass, null);
						this.int_0 = 1;
						this.method_8().int_13 = 0;
					}
				}
				else
				{
					string text = this.GetBaseItem().InteractionType.ToLower();
					switch (text)
					{
					case "onewaygate":
					{
						Class33 @class = null;
						if (this.uint_3 > 0u)
						{
							@class = this.method_8().method_53(this.uint_3);
						}
						if (@class != null && @class.int_3 == this.int_1 && @class.int_4 == this.int_2 && this.string_2 != "tried")
						{
							this.string_0 = "1";
							this.string_2 = "tried";
							@class.method_6();
							@class.method_4(this.GStruct1_2);
							this.method_3(0);
							this.method_5(false, true);
						}
						else
						{
							if ((@class != null && ThreeDCoord.smethod_0(@class.GStruct1_0, this.GStruct1_2)) || this.string_2 == "tried")
							{
								this.string_2 = "";
								this.string_0 = "0";
								this.uint_3 = 0u;
								this.method_5(false, true);
								this.method_8().method_22();
							}
							else
							{
								if (this.string_0 == "1")
								{
									this.string_0 = "0";
									this.method_5(false, true);
								}
							}
						}
						if (@class == null)
						{
							this.uint_3 = 0u;
						}
						break;
					}
					case "teleport":
					{
						bool flag = false;
						bool flag2 = false;
						if (this.uint_3 > 0u)
						{
							Class33 @class = this.method_8().method_53(this.uint_3);
							if (@class != null)
							{
								if (ThreeDCoord.smethod_0(@class.GStruct1_0, this.GStruct1_0))
								{
									@class.bool_1 = false;
									if (@class.int_19 == -1)
									{
										@class.int_19 = 1;
									}
									if (Class110.smethod_2(this.uint_0))
									{
										flag2 = true;
										if (@class.int_19 == 0)
										{
											uint num2 = Class110.smethod_0(this.uint_0);
											uint num3 = Class110.smethod_1(num2);
											if (num3 == this.uint_1)
											{
												UserItemData class2 = this.method_8().method_28(num2);
												if (class2 == null)
												{
													@class.method_6();
												}
												else
												{
													@class.method_7(class2.Int32_0, class2.Int32_1, class2.Double_0);
													@class.method_9(class2.int_3);
													class2.string_0 = "2";
													class2.method_5(false, true);
													class2.uint_4 = this.uint_3;
												}
											}
											else
											{
												if (!@class.Boolean_4)
												{
													Phoenix.GetGame().GetRoomManager().method_5(new Teleport(@class.method_16().method_1(), @class.method_16().GetHabbo(), num3, num2));
												}
											}
											this.uint_3 = 0u;
										}
										else
										{
											@class.int_19--;
										}
									}
									else
									{
										@class.method_6();
										this.uint_3 = 0u;
										@class.method_4(this.GStruct1_1);
									}
								}
								else
								{
									if (ThreeDCoord.smethod_0(@class.GStruct1_0, this.GStruct1_1) && @class.class63_0 == this)
									{
										@class.bool_1 = true;
										flag = true;
										if (@class.bool_6 && (@class.int_10 != this.int_1 || @class.int_11 != this.int_2))
										{
											@class.method_3(true);
										}
										@class.bool_0 = false;
										@class.bool_1 = true;
										@class.method_4(this.GStruct1_0);
									}
									else
									{
										this.uint_3 = 0u;
									}
								}
							}
							else
							{
								this.uint_3 = 0u;
							}
						}
						if (this.uint_4 > 0u)
						{
							Class33 class3 = this.method_8().method_53(this.uint_4);
							if (class3 != null)
							{
								flag = true;
								class3.method_6();
								if (ThreeDCoord.smethod_0(class3.GStruct1_0, this.GStruct1_0))
								{
									class3.method_4(this.GStruct1_1);
								}
							}
							this.uint_4 = 0u;
						}
						if (flag)
						{
							if (this.string_0 != "1")
							{
								this.string_0 = "1";
								this.method_5(false, true);
							}
						}
						else
						{
							if (flag2)
							{
								if (this.string_0 != "2")
								{
									this.string_0 = "2";
									this.method_5(false, true);
								}
							}
							else
							{
								if (this.string_0 != "0")
								{
									this.string_0 = "0";
									this.method_5(false, true);
								}
							}
						}
						this.method_3(1);
						break;
					}
					case "bottle":
					{
						int num = Phoenix.smethod_5(0, 7);
						this.string_0 = num.ToString();
						this.method_4();
						break;
					}
					case "dice":
						try
						{
							Class33 @class = this.method_8().method_53(this.uint_3);
							if (@class.method_16().GetHabbo().int_1 > 0)
							{
								this.string_0 = @class.method_16().GetHabbo().int_1.ToString();
								@class.method_16().GetHabbo().int_1 = 0;
							}
							else
							{
								int num = Phoenix.smethod_5(1, 6);
								this.string_0 = num.ToString();
							}
						}
						catch
						{
							int num = Phoenix.smethod_5(1, 6);
							this.string_0 = num.ToString();
						}
						this.method_4();
						break;
					case "habbowheel":
					{
						int num = Phoenix.smethod_5(1, 10);
						this.string_0 = num.ToString();
						this.method_4();
						break;
					}
					case "loveshuffler":
						if (this.string_0 == "0")
						{
							int num = Phoenix.smethod_5(1, 4);
							this.string_0 = num.ToString();
							this.method_3(20);
						}
						else
						{
							if (this.string_0 != "-1")
							{
								this.string_0 = "-1";
							}
						}
						this.method_5(false, true);
						break;
					case "alert":
						if (this.string_0 == "1")
						{
							this.string_0 = "0";
							this.method_5(false, true);
						}
						break;
					case "vendingmachine":
						if (this.string_0 == "1")
						{
							Class33 @class = this.method_8().method_53(this.uint_3);
							if (@class != null)
							{
								@class.method_6();
								int int_ = this.GetBaseItem().list_1[Phoenix.smethod_5(0, this.GetBaseItem().list_1.Count - 1)];
								@class.method_8(int_);
							}
							this.uint_3 = 0u;
							this.string_0 = "0";
							this.method_5(false, true);
						}
						break;
					case "wf_trg_onsay":
					case "wf_trg_enterroom":
					case "wf_trg_furnistate":
					case "wf_trg_onfurni":
					case "wf_trg_offfurni":
					case "wf_trg_gameend":
					case "wf_trg_gamestart":
					case "wf_trg_attime":
					case "wf_trg_atscore":
					case "wf_act_saymsg":
					case "wf_act_togglefurni":
					case "wf_act_givepoints":
					case "wf_act_moverotate":
					case "wf_act_matchfurni":
					case "wf_act_give_phx":
					case "wf_cnd_trggrer_on_frn":
					case "wf_cnd_furnis_hv_avtrs":
					case "wf_cnd_has_furni_on":
					case "wf_cnd_phx":
					case "bb_teleport":
						if (this.string_0 == "1")
						{
							this.string_0 = "0";
							this.method_5(false, true);
						}
						break;
					case "wf_trg_timer":
						if (this.string_0 == "1")
						{
							this.string_0 = "0";
							this.method_5(false, true);
						}
						if (this.string_2.Length > 0)
						{
							this.method_8().method_15(this);
							this.method_3(Convert.ToInt32(Convert.ToDouble(this.string_2) * 2.0));
						}
						break;
					case "wf_act_moveuser":
						if (this.dictionary_1.Count > 0 && this.method_8().class33_0 != null)
						{
							int num4 = 0;
							Class33[] class33_ = this.method_8().class33_0;
							for (int i = 0; i < class33_.Length; i++)
							{
								Class33 class4 = class33_[i];
								if (class4 != null)
								{
									if (class4.Boolean_4)
									{
										this.dictionary_1.Remove(class4);
									}
									if (this.dictionary_1.ContainsKey(class4))
									{
										if (this.dictionary_1[class4] > 0)
										{
											if (this.dictionary_1[class4] == 10 && !class4.Boolean_4)
											{
												class4.method_16().GetHabbo().method_24().method_2(4, true);
											}
											Dictionary<Class33, int> dictionary;
											Class33 key;
											(dictionary = this.dictionary_1)[key = class4] = dictionary[key] - 1;
											num4++;
										}
										else
										{
											this.dictionary_1.Remove(class4);
											class4.method_16().GetHabbo().method_24().method_2(0, true);
										}
									}
								}
							}
							if (num4 > 0)
							{
								this.method_3(0);
							}
							else
							{
								this.dictionary_1.Clear();
							}
						}
						break;
					case "counter":
						if (this.bool_0 && this.string_2 != "1")
						{
							this.string_0 = Convert.ToString(Convert.ToInt32(this.string_0) - 1);
							if (Convert.ToInt32(this.string_0) <= 0)
							{
								this.string_0 = "0";
								this.bool_0 = false;
								this.method_8().method_89(0, this, true);
							}
							this.method_5(true, true);
							this.method_8().method_16((double)Convert.ToInt32(this.string_0));
							this.string_2 = "1";
							this.method_3(1);
						}
						else
						{
							if (this.bool_0)
							{
								this.method_8().method_16((double)Convert.ToInt32(this.string_0) - 0.5);
								this.string_2 = "0";
								this.method_3(1);
							}
						}
						break;
					}
				}
			}
		}
		internal void method_3(int int_5)
		{
			this.int_4 = int_5;
			this.bool_1 = true;
		}
		internal void method_4()
		{
			this.method_5(true, true);
		}
		internal void method_5(bool bool_5, bool bool_6)
		{
			if (bool_5)
			{
				this.method_8().method_80(this);
			}
			if (bool_6)
			{
				ServerMessage gClass = new ServerMessage();
				if (this.Boolean_2)
				{
					gClass.Init(88u);
					gClass.AppendStringWithBreak(this.uint_0.ToString());
					gClass.AppendStringWithBreak(this.string_0);
				}
				else
				{
					gClass.Init(85u);
					this.method_6(gClass);
				}
				this.method_8().SendMessage(gClass, null);
			}
		}
		internal void method_6(ServerMessage gclass5_0)
		{
			if (this.Boolean_2)
			{
				gclass5_0.AppendUInt(this.uint_0);
				gclass5_0.AppendInt32(this.GetBaseItem().int_0);
				gclass5_0.AppendInt32(this.int_1);
				gclass5_0.AppendInt32(this.int_2);
				gclass5_0.AppendInt32(this.int_3);
				gclass5_0.AppendStringWithBreak(this.double_0.ToString().Replace(',', '.'));
				if (this.GetBaseItem().string_1 == "song_disk" && this.string_0.Length > 0)
				{
					gclass5_0.AppendInt32(Convert.ToInt32(this.string_0));
					gclass5_0.AppendStringWithBreak("");
				}
				else
				{
					gclass5_0.AppendInt32(0);
					gclass5_0.AppendStringWithBreak(this.string_0);
				}
				gclass5_0.AppendInt32(-1);
				gclass5_0.AppendBoolean(!(this.GetBaseItem().InteractionType.ToLower() == "default"));
			}
			else
			{
				if (this.Boolean_1)
				{
					gclass5_0.AppendStringWithBreak(string.Concat(this.uint_0));
					gclass5_0.AppendInt32(this.GetBaseItem().int_0);
					gclass5_0.AppendStringWithBreak(this.string_7);
					if (this.GetBaseItem().string_1.StartsWith("poster_"))
					{
						gclass5_0.AppendString(this.GetBaseItem().string_1.Split(new char[]
						{
							'_'
						})[1]);
					}
					string text = this.GetBaseItem().InteractionType.ToLower();
					if (text != null && text == "postit")
					{
						gclass5_0.AppendStringWithBreak(this.string_0.Split(new char[]
						{
							' '
						})[0]);
					}
					else
					{
						gclass5_0.AppendStringWithBreak(this.string_0);
					}
					gclass5_0.AppendBoolean(!(this.GetBaseItem().InteractionType == "default"));
				}
			}
		}
		internal FurnitureData GetBaseItem()
		{
			if (this.class40_0 == null)
			{
				this.class40_0 = Phoenix.GetGame().GetItemManager().method_2(this.uint_2);
			}
			return this.class40_0;
		}
		internal Room method_8()
		{
			if (this.class14_0 == null)
			{
				this.class14_0 = Phoenix.GetGame().GetRoomManager().GetRoom(this.uint_1);
			}
			return this.class14_0;
		}
		internal void method_9()
		{
			if (!(this.string_4 == ""))
			{
				string[] collection = this.string_4.Split(new char[]
				{
					','
				});
				IEnumerable<string> enumerable = new List<string>(collection);
				List<string> list = enumerable.ToList<string>();
				bool flag = false;
				if (list.Count > 5)
				{
					this.string_4 = "";
					this.string_5 = "";
				}
				else
				{
					foreach (string current in enumerable)
					{
						UserItemData @class = null;
						if (current.Length > 0)
						{
							@class = this.method_8().method_28(Convert.ToUInt32(current));
						}
						if (@class == null)
						{
							list.Remove(current);
							flag = true;
						}
					}
					if (flag)
					{
						this.string_5 = OldEncoding.encodeVL64(list.Count);
						for (int i = 0; i < list.Count; i++)
						{
							int value = Convert.ToInt32(list[i]);
							this.string_5 += OldEncoding.encodeVL64(value);
							this.string_4 = this.string_4 + "," + Convert.ToString(value);
						}
						this.string_4 = this.string_4.Substring(1);
					}
				}
			}
		}
		internal void method_10()
		{
			if (!(this.string_3 == ""))
			{
				string[] collection = this.string_3.Split(new char[]
				{
					','
				});
				IEnumerable<string> enumerable = new List<string>(collection);
				List<string> list = enumerable.ToList<string>();
				bool flag = false;
				foreach (string current in enumerable)
				{
					UserItemData @class = this.method_8().method_28(Convert.ToUInt32(current));
					if (@class == null)
					{
						list.Remove(current);
						flag = true;
					}
				}
				if (flag)
				{
					this.string_2 = OldEncoding.encodeVL64(list.Count);
					for (int i = 0; i < list.Count; i++)
					{
						int num = Convert.ToInt32(list[i]);
						this.string_2 += OldEncoding.encodeVL64(num);
					}
					this.string_3 = string.Join(",", list.ToArray());
				}
			}
		}
	}
}
