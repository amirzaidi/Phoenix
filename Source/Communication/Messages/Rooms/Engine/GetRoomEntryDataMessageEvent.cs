using System;
using System.Collections;
using System.Collections.Generic;
using Phoenix.HabboHotel.GameClients;
using Phoenix.HabboHotel.Rooms;
using Phoenix.Messages;
using Phoenix.HabboHotel.Items;
namespace Phoenix.Communication.Messages.Rooms.Engine
{
	internal sealed class GetRoomEntryDataMessageEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			if (class16_0.GetHabbo().uint_2 > 0u && class16_0.GetHabbo().bool_5)
			{
                RoomData @class = Phoenix.GetGame().GetRoomManager().method_12(class16_0.GetHabbo().uint_2);
				if (@class != null)
				{
					if (@class.Model == null)
					{
						class16_0.SendNotif("Error loading room, please try again soon! (Error Code: MdlData)");
						class16_0.method_14(new ServerMessage(18u));
						class16_0.method_1().method_7();
					}
					else
					{
						class16_0.method_14(@class.Model.method_1());
						class16_0.method_14(@class.Model.method_2());
						Room class2 = Phoenix.GetGame().GetRoomManager().GetRoom(class16_0.GetHabbo().uint_2);
						if (class2 != null)
						{
							class16_0.method_1().method_7();
							ServerMessage gClass = new ServerMessage(30u);
							if (class2.Class28_0.string_2 != "")
							{
								gClass.AppendStringWithBreak(class2.Class28_0.string_2);
							}
							else
							{
								gClass.AppendInt32(0);
							}
							class16_0.method_14(gClass);
							if (class2.Type == "private")
							{
								Hashtable hashtable_ = class2.Hashtable_0;
								Hashtable hashtable_2 = class2.Hashtable_1;
								ServerMessage gClass2 = new ServerMessage(32u);
								gClass2.AppendInt32(hashtable_.Count);
								foreach (UserItemData class3 in hashtable_.Values)
								{
									class3.method_6(gClass2);
								}
								class16_0.method_14(gClass2);
								ServerMessage gClass3 = new ServerMessage(45u);
								gClass3.AppendInt32(hashtable_2.Count);
								foreach (UserItemData class3 in hashtable_2.Values)
								{
									class3.method_6(gClass3);
								}
								class16_0.method_14(gClass3);
							}
							class2.method_46(class16_0, class16_0.GetHabbo().bool_8);
							List<Class33> list = new List<Class33>();
							for (int i = 0; i < class2.class33_0.Length; i++)
							{
								Class33 class4 = class2.class33_0[i];
								if (class4 != null && (!class4.bool_11 && class4.bool_12))
								{
									list.Add(class4);
								}
							}
							ServerMessage gClass4 = new ServerMessage(28u);
							gClass4.AppendInt32(list.Count);
							foreach (Class33 class4 in list)
							{
								class4.method_14(gClass4);
							}
							class16_0.method_14(gClass4);
							ServerMessage gClass5 = new ServerMessage(472u);
							gClass5.AppendBoolean(class2.Hidewall);
							gClass5.AppendInt32(class2.Wallthick);
							gClass5.AppendInt32(class2.Floorthick);
							class16_0.method_14(gClass5);
							if (class2.Type == "public")
							{
								ServerMessage gClass6 = new ServerMessage(471u);
								gClass6.AppendBoolean(false);
								gClass6.AppendStringWithBreak(class2.ModelName);
								gClass6.AppendBoolean(false);
								class16_0.method_14(gClass6);
							}
							else
							{
								if (class2.Type == "private")
								{
									ServerMessage gClass6 = new ServerMessage(471u);
									gClass6.AppendBoolean(true);
									gClass6.AppendUInt(class2.Id);
									if (class2.method_27(class16_0, true))
									{
										gClass6.AppendBoolean(true);
									}
									else
									{
										gClass6.AppendBoolean(false);
									}
									class16_0.method_14(gClass6);
									ServerMessage gClass7 = new ServerMessage(454u);
									gClass7.AppendBoolean(false);
									@class.method_3(gClass7, false, false);
									class16_0.method_14(gClass7);
								}
							}
							ServerMessage gClass8 = class2.method_67(true);
							if (gClass8 != null)
							{
								class16_0.method_14(gClass8);
							}
							for (int i = 0; i < class2.class33_0.Length; i++)
							{
								Class33 class4 = class2.class33_0[i];
								if (class4 != null && !class4.bool_11)
								{
									if (class4.Boolean_1)
									{
										ServerMessage gClass9 = new ServerMessage(480u);
										gClass9.AppendInt32(class4.int_0);
										gClass9.AppendInt32(class4.int_15);
										class16_0.method_14(gClass9);
									}
									if (class4.bool_8)
									{
										ServerMessage gClass10 = new ServerMessage(486u);
										gClass10.AppendInt32(class4.int_0);
										gClass10.AppendBoolean(true);
										class16_0.method_14(gClass10);
									}
									if (class4.int_5 > 0 && class4.int_6 > 0)
									{
										ServerMessage gClass11 = new ServerMessage(482u);
										gClass11.AppendInt32(class4.int_0);
										gClass11.AppendInt32(class4.int_5);
										class16_0.method_14(gClass11);
									}
									if (!class4.Boolean_4)
									{
										try
										{
											if (class4.method_16().GetHabbo() != null && class4.method_16().GetHabbo().method_24() != null && class4.method_16().GetHabbo().method_24().int_0 >= 1)
											{
												ServerMessage gClass12 = new ServerMessage(485u);
												gClass12.AppendInt32(class4.int_0);
												gClass12.AppendInt32(class4.method_16().GetHabbo().method_24().int_0);
												class16_0.method_14(gClass12);
											}
											goto IL_5C5;
										}
										catch
										{
											goto IL_5C5;
										}
									}
									if (!class4.Boolean_0 && class4.class34_0.int_0 != 0)
									{
										ServerMessage gClass12 = new ServerMessage(485u);
										gClass12.AppendInt32(class4.int_0);
										gClass12.AppendInt32(class4.class34_0.int_0);
										class16_0.method_14(gClass12);
									}
								}
								IL_5C5:;
							}
							if (class2 != null && class16_0 != null && class16_0.GetHabbo().Class14_0 != null)
							{
								class2.method_8(class16_0.GetHabbo().Class14_0.method_53(class16_0.GetHabbo().Id));
							}
							if (class2.Achievement > 0u)
							{
								Phoenix.GetGame().GetAchievementManager().method_3(class16_0, class2.Achievement, 1);
							}
							if (class16_0.GetHabbo().bool_3 && class16_0.GetHabbo().int_4 > 0)
							{
								ServerMessage gClass13 = new ServerMessage(27u);
								gClass13.AppendInt32(class16_0.GetHabbo().int_4);
								class16_0.method_14(gClass13);
							}
						}
					}
				}
			}
		}
	}
}
