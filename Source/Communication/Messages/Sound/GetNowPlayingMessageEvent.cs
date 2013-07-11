using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Messages;
namespace Phoenix.Communication.Messages.Sound
{
	internal sealed class GetNowPlayingMessageEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			ServerMessage gClass = new ServerMessage(327u);
			gClass.AppendInt32(3);
			gClass.AppendInt32(6);
			gClass.AppendInt32(3);
			gClass.AppendInt32(0);
			if (class16_0.GetHabbo().Class14_0 != null)
			{
				gClass.AppendInt32(class16_0.GetHabbo().Class14_0.int_13);
			}
			else
			{
				gClass.AppendInt32(0);
			}
			class16_0.method_14(gClass);
		}
	}
}
