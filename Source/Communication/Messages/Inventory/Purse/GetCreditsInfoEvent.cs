using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Messages;
namespace Phoenix.Communication.Messages.Inventory.Purse
{
	internal sealed class GetCreditsInfoEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			class16_0.GetHabbo().method_13(false);
			class16_0.GetHabbo().method_15(false);
		}
	}
}
