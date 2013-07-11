using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Messages;
using Phoenix.HabboHotel.Rooms;
namespace Phoenix.Communication.Messages.Rooms.Avatar
{
	internal sealed class WaveMessageEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			Room @class = Phoenix.GetGame().GetRoomManager().GetRoom(class16_0.GetHabbo().CurrentRoomId);
			if (@class != null)
			{
				Class33 class2 = @class.method_53(class16_0.GetHabbo().Id);
				if (class2 != null)
				{
					class2.method_0();
					class2.int_15 = 0;
					ServerMessage gClass = new ServerMessage(481u);
					gClass.AppendInt32(class2.int_0);
					@class.SendMessage(gClass, null);
					if (class16_0.GetHabbo().CurrentQuestId == 8u)
					{
						Phoenix.GetGame().GetQuestManager().method_1(8u, class16_0);
					}
				}
			}
		}
	}
}
