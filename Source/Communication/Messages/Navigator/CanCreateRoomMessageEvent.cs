using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Util;
using Phoenix.Messages;
namespace Phoenix.Communication.Messages.Navigator
{
	internal sealed class CanCreateRoomMessageEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			ServerMessage gClass = new ServerMessage(512u);
			if (class16_0.GetHabbo().list_6.Count > Config.Int32_4)
			{
				gClass.AppendBoolean(true);
				gClass.AppendInt32(Config.Int32_4);
			}
			else
			{
				gClass.AppendBoolean(false);
			}
			class16_0.method_14(gClass);
		}
	}
}
