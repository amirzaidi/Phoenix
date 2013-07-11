using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Messages;
namespace Phoenix.Communication.Messages.Navigator
{
	internal sealed class LatestEventsSearchMessageEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			int int_ = int.Parse(class18_0.PopFixedString());
			class16_0.method_14(Phoenix.GetGame().GetNavigator().method_8(class16_0, int_));
		}
	}
}
