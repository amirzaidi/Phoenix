using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Messages;
using Phoenix.HabboHotel.Rooms;
namespace Phoenix.Communication.Messages.Navigator
{
	internal sealed class CanCreateEventMessageEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			Room @class = Phoenix.GetGame().GetRoomManager().GetRoom(class16_0.GetHabbo().CurrentRoomId);
			if (@class != null && @class.method_27(class16_0, true))
			{
				bool bool_ = true;
				int int_ = 0;
				if (@class.State != 0)
				{
					bool_ = false;
					int_ = 3;
				}
				ServerMessage gClass = new ServerMessage(367u);
				gClass.AppendBoolean(bool_);
				gClass.AppendInt32(int_);
				class16_0.method_14(gClass);
			}
		}
	}
}
