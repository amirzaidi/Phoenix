using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Messages;
namespace Phoenix.Communication.Messages.Handshake
{
	internal sealed class GetSessionParametersMessageEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			ServerMessage gClass = new ServerMessage(257u);
			gClass.AppendInt32(0);
			class16_0.method_14(gClass);
		}
	}
}
