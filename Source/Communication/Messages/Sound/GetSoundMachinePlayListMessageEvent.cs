using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Messages;
namespace Phoenix.Communication.Messages.Sound
{
	internal sealed class GetSoundMachinePlayListMessageEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			ServerMessage gClass = new ServerMessage(323u);
			gClass.AppendUInt(class16_0.GetHabbo().CurrentRoomId);
			gClass.AppendInt32(1);
			gClass.AppendInt32(1);
			gClass.AppendInt32(1);
			gClass.AppendStringWithBreak("Watercolour");
			gClass.AppendStringWithBreak("Pendulum");
			gClass.AppendInt32(1);
			class16_0.method_14(gClass);
		}
	}
}
