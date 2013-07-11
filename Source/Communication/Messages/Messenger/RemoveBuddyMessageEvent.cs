using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Messages;
namespace Phoenix.Communication.Messages.Messenger
{
	internal sealed class RemoveBuddyMessageEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			if (class16_0.GetHabbo().method_21() != null)
			{
				int num = class18_0.PopWiredInt32();
				for (int i = 0; i < num; i++)
				{
					class16_0.GetHabbo().method_21().method_13(class18_0.PopWiredUInt());
				}
			}
		}
	}
}
