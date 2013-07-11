using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Messages;
namespace Phoenix.Communication.Messages.Messenger
{
	internal sealed class SetEventStreamingAllowedEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			ServerMessage gClass = new ServerMessage(950u);
			gClass.AppendInt32(1);
			gClass.AppendUInt(1u);
			gClass.AppendInt32(2);
			gClass.AppendStringWithBreak(class16_0.GetHabbo().Id.ToString());
			gClass.AppendStringWithBreak(class16_0.GetHabbo().Username);
			gClass.AppendStringWithBreak(class16_0.GetHabbo().string_6.ToLower());
			gClass.AppendStringWithBreak("http://habboon.com/images/avatar_head.cfm?figure=");
			gClass.AppendInt32(0);
			gClass.AppendInt32(1);
			gClass.AppendStringWithBreak("");
			gClass.AppendStringWithBreak("");
			class16_0.method_14(gClass);
		}
	}
}
