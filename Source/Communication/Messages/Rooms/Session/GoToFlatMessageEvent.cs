using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Messages;
namespace Phoenix.Communication.Messages.Rooms.Session
{
	internal sealed class GoToFlatMessageEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			class16_0.GetHabbo().uint_2 = class18_0.PopWiredUInt();
			class16_0.method_1().method_6();
		}
	}
}
