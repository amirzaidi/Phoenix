using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Messages;
namespace Phoenix.Communication.Messages.Handshake
{
	internal sealed class InfoRetrieveMessageEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			ServerMessage gClass = new ServerMessage(5u);
			gClass.AppendStringWithBreak(class16_0.GetHabbo().Id.ToString());
			gClass.AppendStringWithBreak(class16_0.GetHabbo().Username);
			gClass.AppendStringWithBreak(class16_0.GetHabbo().string_5);
			gClass.AppendStringWithBreak(class16_0.GetHabbo().string_6.ToUpper());
			gClass.AppendStringWithBreak(class16_0.GetHabbo().string_4);
			gClass.AppendStringWithBreak(class16_0.GetHabbo().RealName);
			gClass.AppendBoolean(false);
			gClass.AppendInt32(class16_0.GetHabbo().Respect);
			gClass.AppendInt32(class16_0.GetHabbo().int_21);
			gClass.AppendInt32(class16_0.GetHabbo().int_22);
			gClass.AppendBoolean(false);
			class16_0.method_14(gClass);
		}
	}
}
