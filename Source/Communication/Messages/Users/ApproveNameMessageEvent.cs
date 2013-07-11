using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Messages;
namespace Phoenix.Communication.Messages.Users
{
	internal sealed class ApproveNameMessageEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			ServerMessage gClass = new ServerMessage(36u);
			gClass.AppendInt32(Phoenix.GetGame().GetCatalog().method_8(class18_0.PopFixedString()) ? 0 : 2);
			class16_0.method_14(gClass);
		}
	}
}
