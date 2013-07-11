using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Messages;
namespace Phoenix.Communication.Messages.Catalog
{
	internal sealed class RedeemVoucherMessageEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			Phoenix.GetGame().GetCatalog().method_21().method_2(class16_0, class18_0.PopFixedString());
		}
	}
}
