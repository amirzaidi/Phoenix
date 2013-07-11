using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Util;
using Phoenix.HabboHotel.Items;
using Phoenix.Messages;
using Phoenix.Storage;
using Phoenix.HabboHotel.Rooms;
namespace Phoenix.Communication.Messages.Rooms.Engine
{
	internal sealed class PlaceObjectMessageEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			Room @class = Phoenix.GetGame().GetRoomManager().GetRoom(class16_0.GetHabbo().CurrentRoomId);
			if (@class != null && @class.method_26(class16_0) && (Config.Boolean_1 || !(@class.Owner != class16_0.GetHabbo().Username)))
			{
				string text = class18_0.PopFixedString();
				string[] array = text.Split(new char[]
				{
					' '
				});
				if (array[0].Contains("-"))
				{
					array[0] = array[0].Replace("-", "");
				}
				uint uint_ = 0u;
				try
				{
					uint_ = uint.Parse(array[0]);
				}
				catch
				{
					return;
				}
				Class39 class2 = class16_0.GetHabbo().method_23().method_10(uint_);
				if (class2 != null)
				{
					string text2 = class2.method_1().InteractionType.ToLower();
					if (text2 != null && text2 == "dimmer" && @class.method_72("dimmer") >= 1)
					{
						class16_0.SendNotif("You can only have one moodlight in a room.");
					}
					else
					{
						UserItemData class63_;
						if (array[1].StartsWith(":"))
						{
							string text3 = @class.method_98(":" + text.Split(new char[]
							{
								':'
							})[1]);
							if (text3 == null)
							{
								ServerMessage gClass = new ServerMessage(516u);
								gClass.AppendInt32(11);
								class16_0.method_14(gClass);
								return;
							}
							class63_ = new UserItemData(class2.uint_0, @class.Id, class2.uint_1, class2.string_0, 0, 0, 0.0, 0, text3, @class);
							if (!@class.method_82(class16_0, class63_, true, null))
							{
								goto IL_32C;
							}
							class16_0.GetHabbo().method_23().method_12(uint_, 1u, false);
							using (DatabaseClient class3 = Phoenix.GetDatabase().GetClient())
							{
								class3.ExecuteQuery(string.Concat(new object[]
								{
									"UPDATE items SET room_id = '",
									@class.Id,
									"' WHERE id = '",
									class2.uint_0,
									"' LIMIT 1"
								}));
								goto IL_32C;
							}
						}
						int int_ = int.Parse(array[1]);
						int int_2 = int.Parse(array[2]);
						int int_3 = int.Parse(array[3]);
						class63_ = new UserItemData(class2.uint_0, @class.Id, class2.uint_1, class2.string_0, 0, 0, 0.0, 0, "", @class);
						if (@class.method_79(class16_0, class63_, int_, int_2, int_3, true, false, false))
						{
							class16_0.GetHabbo().method_23().method_12(uint_, 1u, false);
							using (DatabaseClient class3 = Phoenix.GetDatabase().GetClient())
							{
								class3.ExecuteQuery(string.Concat(new object[]
								{
									"UPDATE items SET room_id = '",
									@class.Id,
									"' WHERE id = '",
									class2.uint_0,
									"' LIMIT 1"
								}));
							}
						}
						IL_32C:
						if (class16_0.GetHabbo().CurrentQuestId == 14u)
						{
							Phoenix.GetGame().GetQuestManager().method_1(14u, class16_0);
						}
					}
				}
			}
		}
	}
}
