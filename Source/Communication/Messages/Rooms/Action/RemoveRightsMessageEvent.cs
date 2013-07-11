using System;
using System.Text;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Messages;
using Phoenix.HabboHotel.Rooms;
using Phoenix.Storage;
namespace Phoenix.Communication.Messages.Rooms.Action
{
	internal sealed class RemoveRightsMessageEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			Room @class = Phoenix.GetGame().GetRoomManager().GetRoom(class16_0.GetHabbo().CurrentRoomId);
			if (@class != null && @class.method_27(class16_0, true))
			{
				StringBuilder stringBuilder = new StringBuilder();
				int num = class18_0.PopWiredInt32();
				for (int i = 0; i < num; i++)
				{
					if (i > 0)
					{
						stringBuilder.Append(" OR ");
					}
					uint num2 = class18_0.PopWiredUInt();
					@class.list_1.Remove(num2);
					stringBuilder.Append(string.Concat(new object[]
					{
						"room_id = '",
						@class.Id,
						"' AND user_id = '",
						num2,
						"'"
					}));
					Class33 class2 = @class.method_53(num2);
					if (class2 != null && !class2.Boolean_4)
					{
						class2.method_16().method_14(new ServerMessage(43u));
						class2.method_12("flatctrl");
						class2.bool_7 = true;
					}
					ServerMessage gClass = new ServerMessage(511u);
					gClass.AppendUInt(@class.Id);
					gClass.AppendUInt(num2);
					class16_0.method_14(gClass);
				}
				using (DatabaseClient class3 = Phoenix.GetDatabase().GetClient())
				{
					class3.ExecuteQuery("DELETE FROM room_rights WHERE " + stringBuilder.ToString());
				}
			}
		}
	}
}
