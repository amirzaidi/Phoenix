using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Messages;
namespace Phoenix.Communication.Messages.Marketplace
{
	internal sealed class GetMarketplaceCanMakeOfferEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			ServerMessage gClass = new ServerMessage(611u);
			gClass.AppendBoolean(true);
			gClass.AppendInt32(2);
			class16_0.method_14(gClass);
		}
	}
}
