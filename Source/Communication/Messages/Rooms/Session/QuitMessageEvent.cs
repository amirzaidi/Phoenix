using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Messages;
namespace Phoenix.Communication.Messages.Rooms.Session
{
	internal sealed class QuitMessageEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			try
			{
				if (class16_0 != null && class16_0.GetHabbo() != null && class16_0.GetHabbo().Boolean_0)
				{
					Phoenix.GetGame().GetRoomManager().GetRoom(class16_0.GetHabbo().CurrentRoomId).method_47(class16_0, true, false);
				}
			}
			catch
			{
			}
		}
	}
}
