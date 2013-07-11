using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.HabboHotel.Items;
using Phoenix.Messages;
using Phoenix.Storage;
using Phoenix.HabboHotel.Rooms;
namespace Phoenix.Communication.Messages.Rooms.Furniture
{
	internal sealed class PlacePostItMessageEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			try
			{
				Room @class = Phoenix.GetGame().GetRoomManager().GetRoom(class16_0.GetHabbo().CurrentRoomId);
				if (@class != null)
				{
					if (@class.method_72("stickiepole") > 0 || @class.method_26(class16_0))
					{
						uint uint_ = class18_0.PopWiredUInt();
						string text = class18_0.PopFixedString();
						string[] array = text.Split(new char[]
						{
							' '
						});
						if (array[0].Contains("-"))
						{
							array[0] = array[0].Replace("-", "");
						}
						Class39 class2 = class16_0.GetHabbo().method_23().method_10(uint_);
						if (class2 != null)
						{
							if (array[0].StartsWith(":"))
							{
								string text2 = @class.method_98(text);
								if (text2 == null)
								{
									ServerMessage gClass = new ServerMessage(516u);
									gClass.AppendInt32(11);
									class16_0.method_14(gClass);
									return;
								}
								UserItemData class63_ = new UserItemData(class2.uint_0, @class.Id, class2.uint_1, class2.string_0, 0, 0, 0.0, 0, text2, @class);
								if (@class.method_82(class16_0, class63_, true, null))
								{
									class16_0.GetHabbo().method_23().method_12(uint_, 1u, false);
								}
							}
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
					}
				}
			}
			catch
			{
			}
		}
	}
}
