using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Messages;
using Phoenix.HabboHotel.Rooms;
namespace Phoenix.Communication.Messages.Rooms.Chat
{
	internal sealed class ShoutMessageEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			Room @class = Phoenix.GetGame().GetRoomManager().GetRoom(class16_0.GetHabbo().CurrentRoomId);
			if (@class != null)
			{
				Class33 class2 = @class.method_53(class16_0.GetHabbo().Id);
				if (class2 != null)
				{
					class2.method_1(class16_0, Phoenix.smethod_7(class18_0.PopFixedString()), true);
				}
			}
		}
	}
}
