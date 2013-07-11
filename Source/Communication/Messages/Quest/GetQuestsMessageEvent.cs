using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Messages;
namespace Phoenix.Communication.Messages.Quest
{
	internal sealed class GetQuestsMessageEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			class16_0.method_14(Phoenix.GetGame().GetQuestManager().method_5(class16_0));
		}
	}
}
