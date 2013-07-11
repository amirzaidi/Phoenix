using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Messages;
using Phoenix.HabboHotel.Rooms;
using Phoenix.Storage;
namespace Phoenix.Communication.Messages.Rooms.Action
{
	internal sealed class RemoveAllRightsMessageEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			Room @class = Phoenix.GetGame().GetRoomManager().GetRoom(class16_0.GetHabbo().CurrentRoomId);
			if (@class != null && @class.method_27(class16_0, true))
			{
				foreach (uint current in @class.list_1)
				{
					Class33 class2 = @class.method_53(current);
					if (class2 != null && !class2.Boolean_4)
					{
						class2.method_16().method_14(new ServerMessage(43u));
					}
					ServerMessage gClass = new ServerMessage(511u);
					gClass.AppendUInt(@class.Id);
					gClass.AppendUInt(current);
					class16_0.method_14(gClass);
				}
				using (DatabaseClient class3 = Phoenix.GetDatabase().GetClient())
				{
					class3.ExecuteQuery("DELETE FROM room_rights WHERE room_id = '" + @class.Id + "'");
				}
				@class.list_1.Clear();
			}
		}
	}
}
