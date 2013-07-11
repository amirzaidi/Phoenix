using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Messages;
using Phoenix.HabboHotel.Users.Messenger;
namespace Phoenix.Communication.Messages.Messenger
{
	internal sealed class AcceptBuddyMessageEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			if (class16_0.GetHabbo().method_21() != null)
			{
				int num = class18_0.PopWiredInt32();
				for (int i = 0; i < num; i++)
				{
					uint uint_ = class18_0.PopWiredUInt();
					FriendRequest @class = class16_0.GetHabbo().method_21().method_4(uint_);
					if (@class != null)
					{
						if (@class.UInt32_1 != class16_0.GetHabbo().Id)
						{
							break;
						}
						if (!class16_0.GetHabbo().method_21().method_9(@class.UInt32_1, @class.UInt32_2))
						{
							class16_0.GetHabbo().method_21().method_12(@class.UInt32_2);
						}
						class16_0.GetHabbo().method_21().method_11(uint_);
					}
				}
			}
		}
	}
}
