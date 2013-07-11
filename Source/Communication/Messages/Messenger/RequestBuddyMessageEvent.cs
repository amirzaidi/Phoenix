using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Messages;
namespace Phoenix.Communication.Messages.Messenger
{
	internal sealed class RequestBuddyMessageEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			if (class16_0.GetHabbo().method_21() != null)
			{
				if (class16_0.GetHabbo().CurrentQuestId == 4u)
				{
					Phoenix.GetGame().GetQuestManager().method_1(4u, class16_0);
				}
				class16_0.GetHabbo().method_21().method_16(class18_0.PopFixedString());
			}
		}
	}
}
