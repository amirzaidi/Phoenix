using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Messages;
using Phoenix.Storage;
using Phoenix.HabboHotel.Rooms;
namespace Phoenix.Communication.Messages.Navigator
{
	internal sealed class RateFlatMessageEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			Room @class = Phoenix.GetGame().GetRoomManager().GetRoom(class16_0.GetHabbo().CurrentRoomId);
			if (@class != null && !class16_0.GetHabbo().list_4.Contains(@class.Id) && !@class.method_27(class16_0, true))
			{
				switch (class18_0.PopWiredInt32())
				{
				case -1:
					@class.Score--;
					break;
				case 0:
					return;
				case 1:
					@class.Score++;
					break;
				default:
					return;
				}
				using (DatabaseClient class2 = Phoenix.GetDatabase().GetClient())
				{
					class2.ExecuteQuery(string.Concat(new object[]
					{
						"UPDATE rooms SET score = '",
						@class.Score,
						"' WHERE id = '",
						@class.Id,
						"' LIMIT 1"
					}));
				}
				class16_0.GetHabbo().list_4.Add(@class.Id);
				ServerMessage gClass = new ServerMessage(345u);
				gClass.AppendInt32(@class.Score);
				class16_0.method_14(gClass);
			}
		}
	}
}
