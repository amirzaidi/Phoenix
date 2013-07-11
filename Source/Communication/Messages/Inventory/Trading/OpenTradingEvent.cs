using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Messages;
using Phoenix.HabboHotel.Rooms;
namespace Phoenix.Communication.Messages.Inventory.Trading
{
	internal sealed class OpenTradingEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			Room @class = Phoenix.GetGame().GetRoomManager().GetRoom(class16_0.GetHabbo().CurrentRoomId);
			if (@class != null)
			{
				if (!@class.Boolean_2)
				{
					class16_0.GetHabbo().method_28(PhoenixEnvironment.GetExternalText("trade_error_roomdisabled"));
				}
				else
				{
					Class33 class2 = @class.method_53(class16_0.GetHabbo().Id);
					Class33 class3 = @class.method_52(class18_0.PopWiredInt32());
					if (class2 != null && class3 != null && class3.method_16().GetHabbo().bool_2)
					{
						@class.method_77(class2, class3);
					}
					else
					{
						class16_0.GetHabbo().method_28(PhoenixEnvironment.GetExternalText("trade_error_targetdisabled"));
					}
				}
			}
		}
	}
}
