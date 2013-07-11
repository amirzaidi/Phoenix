using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.HabboHotel.Rooms;
using Phoenix.Messages;
using Phoenix.Storage;
namespace Phoenix.Communication.Messages.Navigator
{
	internal sealed class UpdateNavigatorSettingsMessageEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			uint num = class18_0.PopWiredUInt();
            RoomData @class = Phoenix.GetGame().GetRoomManager().method_12(num);
			if (num == 0u || (@class != null && !(@class.Owner.ToLower() != class16_0.GetHabbo().Username.ToLower())))
			{
				class16_0.GetHabbo().uint_4 = num;
				using (DatabaseClient class2 = Phoenix.GetDatabase().GetClient())
				{
					class2.ExecuteQuery(string.Concat(new object[]
					{
						"UPDATE users SET home_room = '",
						num,
						"' WHERE id = '",
						class16_0.GetHabbo().Id,
						"' LIMIT 1;"
					}));
				}
				ServerMessage gClass = new ServerMessage(455u);
				gClass.AppendUInt(num);
				class16_0.method_14(gClass);
			}
		}
	}
}
