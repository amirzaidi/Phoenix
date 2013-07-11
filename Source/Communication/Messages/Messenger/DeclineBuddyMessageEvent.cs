using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Messages;
namespace Phoenix.Communication.Messages.Messenger
{
	internal sealed class DeclineBuddyMessageEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			if (class16_0.GetHabbo().method_21() != null)
			{
				int num = class18_0.PopWiredInt32();
				int num2 = class18_0.PopWiredInt32();
				if (num == 0 && num2 == 1)
				{
					uint uint_ = class18_0.PopWiredUInt();
					class16_0.GetHabbo().method_21().method_11(uint_);
				}
				else
				{
					if (num == 1)
					{
						class16_0.GetHabbo().method_21().method_10();
					}
				}
			}
		}
	}
}
