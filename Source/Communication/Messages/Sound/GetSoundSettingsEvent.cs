using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Messages;
namespace Phoenix.Communication.Messages.Sound
{
	internal sealed class GetSoundSettingsEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			ServerMessage gClass = new ServerMessage(308u);
			gClass.AppendInt32(class16_0.GetHabbo().int_11);
			gClass.AppendBoolean(false);
			class16_0.method_14(gClass);
		}
	}
}
