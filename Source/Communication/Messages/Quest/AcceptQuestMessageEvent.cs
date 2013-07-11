using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Messages;
namespace Phoenix.Communication.Messages.Quest
{
	internal sealed class AcceptQuestMessageEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			uint uint_ = class18_0.PopWiredUInt();
			Phoenix.GetGame().GetQuestManager().method_7(uint_, class16_0);
		}
	}
}
