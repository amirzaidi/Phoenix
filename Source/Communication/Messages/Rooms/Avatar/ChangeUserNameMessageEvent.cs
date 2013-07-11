using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Phoenix.HabboHotel.Misc;
using Phoenix.HabboHotel.GameClients;
using Phoenix.HabboHotel.Rooms;
using Phoenix.Messages;
using Phoenix.Storage;
namespace Phoenix.Communication.Messages.Rooms.Avatar
{
	internal sealed class ChangeUserNameMessageEvent : Interface
	{
		[CompilerGenerated]
		private static Func<Room, int> func_0;
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			string text = Phoenix.smethod_8(class18_0.PopFixedString(), false, true);
			if (text.Length < 3)
			{
				ServerMessage gClass = new ServerMessage(571u);
				gClass.AppendString("J");
				class16_0.method_14(gClass);
			}
			else
			{
				if (text.Length > 15)
				{
					ServerMessage gClass = new ServerMessage(571u);
					gClass.AppendString("K");
					class16_0.method_14(gClass);
				}
				else
				{
					if (text.Contains(" ") || !class16_0.method_1().method_8(text) || text != ChatCommandHandler.smethod_4(text))
					{
						ServerMessage gClass = new ServerMessage(571u);
						gClass.AppendString("QA");
						class16_0.method_14(gClass);
					}
					else
					{
						if (class18_0.Header == "GW")
						{
							ServerMessage gClass = new ServerMessage(571u);
							gClass.AppendString("H");
							gClass.AppendString(text);
							class16_0.method_14(gClass);
						}
						else
						{
							if (class18_0.Header == "GV")
							{
								ServerMessage gClass2 = new ServerMessage(570u);
								gClass2.AppendString("H");
								class16_0.method_14(gClass2);
								ServerMessage gClass3 = new ServerMessage(572u);
								gClass3.AppendUInt(class16_0.GetHabbo().Id);
								gClass3.AppendString("H");
								gClass3.AppendString(text);
								class16_0.method_14(gClass3);
								if (class16_0.GetHabbo().CurrentRoomId > 0u)
								{
									Room @class = Phoenix.GetGame().GetRoomManager().GetRoom(class16_0.GetHabbo().CurrentRoomId);
									Class33 class2 = @class.method_53(class16_0.GetHabbo().Id);
									ServerMessage gClass4 = new ServerMessage(28u);
									gClass4.AppendInt32(1);
									class2.method_14(gClass4);
									@class.SendMessage(gClass4, null);
								}
								Dictionary<Room, int> dictionary = Phoenix.GetGame().GetRoomManager().method_22();
								IEnumerable<Room> arg_204_0 = dictionary.Keys;
								if (ChangeUserNameMessageEvent.func_0 == null)
								{
									ChangeUserNameMessageEvent.func_0 = new Func<Room, int>(ChangeUserNameMessageEvent.smethod_0);
								}
								IOrderedEnumerable<Room> orderedEnumerable = arg_204_0.OrderByDescending(ChangeUserNameMessageEvent.func_0);
								foreach (Room current in orderedEnumerable)
								{
									if (current.Owner == class16_0.GetHabbo().Username)
									{
										current.Owner = text;
										Phoenix.GetGame().GetRoomManager().method_16(Phoenix.GetGame().GetRoomManager().GetRoom(current.Id));
									}
								}
								using (DatabaseClient class3 = Phoenix.GetDatabase().GetClient())
								{
									class3.ExecuteQuery(string.Concat(new string[]
									{
										"UPDATE rooms SET owner = '",
										text,
										"' WHERE owner = '",
										class16_0.GetHabbo().Username,
										"'"
									}));
									class3.ExecuteQuery(string.Concat(new object[]
									{
										"UPDATE users SET username = '",
										text,
										"' WHERE id = '",
										class16_0.GetHabbo().Id,
										"' LIMIT 1"
									}));
									Phoenix.GetGame().GetClientManager().method_31(class16_0, "flagme", "OldName: " + class16_0.GetHabbo().Username + " NewName: " + text);
									class16_0.GetHabbo().Username = text;
									class16_0.GetHabbo().method_1(class3);
                                    foreach (RoomData current2 in class16_0.GetHabbo().list_6)
									{
										current2.Owner = text;
									}
								}
								Phoenix.GetGame().GetAchievementManager().method_3(class16_0, 9u, 1);
							}
						}
					}
				}
			}
		}
		[CompilerGenerated]
		private static int smethod_0(Room class14_0)
		{
			return class14_0.Int32_0;
		}
	}
}
