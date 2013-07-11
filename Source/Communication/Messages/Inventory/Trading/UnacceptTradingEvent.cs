using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Messages;
using Phoenix.HabboHotel.Rooms;
namespace Phoenix.Communication.Messages.Inventory.Trading
{
	internal sealed class UnacceptTradingEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			Room @class = Phoenix.GetGame().GetRoomManager().GetRoom(class16_0.GetHabbo().CurrentRoomId);
			if (@class != null && @class.Boolean_2)
			{
				Trade class2 = @class.method_76(class16_0.GetHabbo().Id);
				if (class2 != null)
				{
					class2.method_5(class16_0.GetHabbo().Id);
				}
			}
		}
	}
}
