using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.HabboHotel.Items;
using Phoenix.Messages;
using Phoenix.HabboHotel.Rooms;
namespace Phoenix.Communication.Messages.Inventory.Trading
{
	internal sealed class RemoveItemFromTradeEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			Room @class = Phoenix.GetGame().GetRoomManager().GetRoom(class16_0.GetHabbo().CurrentRoomId);
			if (@class != null && @class.Boolean_2)
			{
				Trade class2 = @class.method_76(class16_0.GetHabbo().Id);
				Class39 class3 = class16_0.GetHabbo().method_23().method_10(class18_0.PopWiredUInt());
				if (class2 != null && class3 != null)
				{
					class2.method_3(class16_0.GetHabbo().Id, class3);
				}
			}
		}
	}
}
