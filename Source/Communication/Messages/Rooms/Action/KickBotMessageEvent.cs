using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Messages;
using Phoenix.HabboHotel.Rooms;
namespace Phoenix.Communication.Messages.Rooms.Action
{
	internal sealed class KickBotMessageEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			Room @class = Phoenix.GetGame().GetRoomManager().GetRoom(class16_0.GetHabbo().CurrentRoomId);
			if (@class != null && @class.method_27(class16_0, true))
			{
				Class33 class2 = @class.method_52(class18_0.PopWiredInt32());
				if (class2 != null && class2.Boolean_4)
				{
					@class.method_6(class2.int_0, true);
				}
			}
		}
	}
}
