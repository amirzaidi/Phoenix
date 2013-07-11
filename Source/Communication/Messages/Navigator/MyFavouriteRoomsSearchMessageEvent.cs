using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Messages;
namespace Phoenix.Communication.Messages.Navigator
{
	internal sealed class MyFavouriteRoomsSearchMessageEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			class16_0.method_14(Phoenix.GetGame().GetNavigator().method_6(class16_0));
		}
	}
}
