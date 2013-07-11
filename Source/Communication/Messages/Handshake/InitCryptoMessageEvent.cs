using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Messages;
namespace Phoenix.Communication.Messages.Handshake
{
	internal sealed class InitCryptoMessageEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			Interface @interface;
			if (Phoenix.GetPackets().Handle(1817u, out @interface))
			{
				@interface.imethod_0(class16_0, null);
			}
		}
	}
}
