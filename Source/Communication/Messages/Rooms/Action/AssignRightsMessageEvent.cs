using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Messages;
using Phoenix.HabboHotel.Rooms;
using Phoenix.Storage;
namespace Phoenix.Communication.Messages.Rooms.Action
{
	internal sealed class AssignRightsMessageEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			uint num = class18_0.PopWiredUInt();
			Room @class = Phoenix.GetGame().GetRoomManager().GetRoom(class16_0.GetHabbo().CurrentRoomId);
			Class33 class2 = @class.method_53(num);
			if (@class != null && @class.method_27(class16_0, true) && class2 != null && !class2.Boolean_4 && !@class.list_1.Contains(num))
			{
				@class.list_1.Add(num);
				using (DatabaseClient class3 = Phoenix.GetDatabase().GetClient())
				{
					class3.ExecuteQuery(string.Concat(new object[]
					{
						"INSERT INTO room_rights (room_id,user_id) VALUES ('",
						@class.Id,
						"','",
						num,
						"')"
					}));
				}
				ServerMessage gClass = new ServerMessage(510u);
				gClass.AppendUInt(@class.Id);
				gClass.AppendUInt(num);
				gClass.AppendStringWithBreak(class2.method_16().GetHabbo().Username);
				class16_0.method_14(gClass);
				class2.method_11("flatctrl", "");
				class2.bool_7 = true;
				class2.method_16().method_14(new ServerMessage(42u));
			}
		}
	}
}
