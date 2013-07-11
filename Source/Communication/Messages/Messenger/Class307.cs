using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Messages;
namespace Phoenix.Communication.Messages.Messenger
{
	internal sealed class Class307 : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			if (class16_0.GetHabbo().method_21() != null)
			{
				class16_0.method_14(class16_0.GetHabbo().method_21().method_22());
			}
		}
	}
}
