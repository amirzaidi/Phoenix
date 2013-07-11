using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Messages;
namespace Phoenix.Communication.Messages.Rooms.Engine
{
	internal sealed class GetFurnitureAliasesMessageEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			if (class16_0.GetHabbo().uint_2 > 0u)
			{
				ServerMessage gClass = new ServerMessage(297u);
				gClass.AppendInt32(0);
				class16_0.method_14(gClass);
			}
		}
	}
}
