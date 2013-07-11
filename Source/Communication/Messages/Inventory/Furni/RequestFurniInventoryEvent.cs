using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Messages;
namespace Phoenix.Communication.Messages.Inventory.Furni
{
	internal sealed class RequestFurniInventoryEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			if (class16_0 != null && class16_0.GetHabbo() != null)
			{
				class16_0.method_14(class16_0.GetHabbo().method_23().method_13());
			}
		}
	}
}
