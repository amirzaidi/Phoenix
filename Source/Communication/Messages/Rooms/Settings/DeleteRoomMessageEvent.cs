using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.HabboHotel.Rooms;
using Phoenix.Messages;
using Phoenix.Storage;
namespace Phoenix.Communication.Messages.Rooms.Settings
{
	internal sealed class DeleteRoomMessageEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			uint num = class18_0.PopWiredUInt();
			Room class14_ = class16_0.GetHabbo().Class14_0;
			if (class14_ != null && (!(class14_.Owner != class16_0.GetHabbo().Username) || class16_0.GetHabbo().uint_1 == 7u))
			{
				Phoenix.GetGame().GetRoomManager().method_2(num);
                RoomData @class = Phoenix.GetGame().GetRoomManager().method_12(num);
				if (@class != null && (!(@class.Owner.ToLower() != class16_0.GetHabbo().Username.ToLower()) || class16_0.GetHabbo().uint_1 == 7u))
				{
					Room class2 = Phoenix.GetGame().GetRoomManager().GetRoom(@class.Id);
					if (class2 != null)
					{
						for (int i = 0; i < class2.class33_0.Length; i++)
						{
							Class33 class3 = class2.class33_0[i];
							if (class3 != null && !class3.Boolean_4)
							{
								class3.method_16().method_14(new ServerMessage(18u));
								class3.method_16().GetHabbo().method_11();
							}
						}
						Phoenix.GetGame().GetRoomManager().method_16(class2);
					}
					using (DatabaseClient class4 = Phoenix.GetDatabase().GetClient())
					{
						class4.ExecuteQuery("DELETE FROM rooms WHERE id = '" + num + "' LIMIT 1");
						class4.ExecuteQuery("DELETE FROM user_favorites WHERE room_id = '" + num + "'");
						class4.ExecuteQuery("UPDATE items SET room_id = '0' WHERE room_id = '" + num + "'");
						class4.ExecuteQuery("DELETE FROM room_rights WHERE room_id = '" + num + "'");
						class4.ExecuteQuery("UPDATE users SET home_room = '0' WHERE home_room = '" + num + "'");
						class4.ExecuteQuery("UPDATE user_pets SET room_id = '0' WHERE room_id = '" + num + "'");
						class16_0.GetHabbo().method_1(class4);
					}
					class16_0.GetHabbo().method_23().method_9(true);
					class16_0.GetHabbo().method_23().method_3(true);
					class16_0.method_14(Phoenix.GetGame().GetNavigator().method_12(class16_0, -3));
				}
			}
		}
	}
}
