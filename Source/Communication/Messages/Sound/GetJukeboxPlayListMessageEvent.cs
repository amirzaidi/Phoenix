using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Messages;
namespace Phoenix.Communication.Messages.Sound
{
	internal sealed class GetJukeboxPlayListMessageEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			ServerMessage gClass = new ServerMessage(334u);
			gClass.AppendInt32(20);
			gClass.AppendInt32(16);
			for (int i = 1; i <= 16; i++)
			{
				gClass.AppendInt32(i);
				gClass.AppendInt32(i);
			}
			class16_0.method_14(gClass);
		}
	}
}
