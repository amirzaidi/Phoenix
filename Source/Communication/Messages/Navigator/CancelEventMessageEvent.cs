using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Messages;
using Phoenix.HabboHotel.Rooms;
namespace Phoenix.Communication.Messages.Navigator
{
	internal sealed class CancelEventMessageEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			Room @class = Phoenix.GetGame().GetRoomManager().GetRoom(class16_0.GetHabbo().CurrentRoomId);
			if (@class != null && @class.method_27(class16_0, true) && @class.Event != null)
			{
				@class.Event = null;
				ServerMessage gClass = new ServerMessage(370u);
				gClass.AppendStringWithBreak("-1");
				@class.SendMessage(gClass, null);
			}
		}
	}
}
