using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Util;
using Phoenix.Messages;
namespace Phoenix.Communication.Messages.Marketplace
{
	internal sealed class GetMarketplaceConfigurationMessageEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			DateTime now = DateTime.Now;
			TimeSpan timeSpan = now - Phoenix.ServerStarted;
			ServerMessage gClass = new ServerMessage(612u);
			gClass.AppendBoolean(true);
			gClass.AppendInt32(Config.int_1);
			gClass.AppendInt32(1);
			gClass.AppendInt32(5);
			gClass.AppendInt32(1);
			gClass.AppendInt32(Config.int_0);
			gClass.AppendInt32(48);
			gClass.AppendInt32(timeSpan.Days);
			class16_0.method_14(gClass);
		}
	}
}
