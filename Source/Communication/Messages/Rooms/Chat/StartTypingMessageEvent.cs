using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Messages;
using Phoenix.HabboHotel.Rooms;
namespace Phoenix.Communication.Messages.Rooms.Chat
{
	internal sealed class StartTypingMessageEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			Room @class = Phoenix.GetGame().GetRoomManager().GetRoom(class16_0.GetHabbo().CurrentRoomId);
			if (@class != null)
			{
				Class33 class2 = @class.method_53(class16_0.GetHabbo().Id);
				if (class2 != null)
				{
					ServerMessage gClass = new ServerMessage(361u);
					gClass.AppendInt32(class2.int_0);
					gClass.AppendBoolean(true);
					@class.SendMessage(gClass, null);
				}
			}
		}
	}
}
