using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Messages;
namespace Phoenix.Communication.Messages.Inventory.Badges
{
	internal sealed class GetBadgesEvent : Interface
	{
        public void imethod_0(GameClient class16_0, ClientMessage class18_0)
        {
            class16_0.method_14(class16_0.GetHabbo().method_22().method_7());
        }
	}
}
