using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Messages;
namespace Phoenix.Communication.Messages.Quest
{
	internal sealed class RejectQuestMessageEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			Phoenix.GetGame().GetQuestManager().method_7(0u, class16_0);
		}
	}
}
