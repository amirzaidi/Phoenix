using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Messages;
namespace Phoenix.Communication.Messages.Inventory.Badges
{
	internal sealed class GetBadgePointLimitsEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			ServerMessage gClass = new ServerMessage(443u);
			gClass.AppendInt32(class16_0.GetHabbo().int_13);
			gClass.AppendStringWithBreak("");
			class16_0.method_14(gClass);
		}
	}
}
