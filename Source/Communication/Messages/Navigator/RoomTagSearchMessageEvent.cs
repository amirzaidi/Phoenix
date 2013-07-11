using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Messages;
namespace Phoenix.Communication.Messages.Navigator
{
	internal sealed class RoomTagSearchMessageEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			class18_0.PopWiredInt32();
			class16_0.method_14(Phoenix.GetGame().GetNavigator().method_10(class18_0.PopFixedString()));
		}
	}
}
