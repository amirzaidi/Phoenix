using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.HabboHotel.Rooms;
using Phoenix.Messages;
namespace Phoenix.Communication.Messages.Navigator
{
	internal sealed class GetGuestRoomMessageEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			uint uint_ = class18_0.PopWiredUInt();
			bool bool_ = class18_0.PopWiredBoolean();
			bool flag = class18_0.PopWiredBoolean();
            RoomData @class = Phoenix.GetGame().GetRoomManager().method_12(uint_);
			if (@class != null)
			{
				ServerMessage gClass = new ServerMessage(454u);
				gClass.AppendBoolean(bool_);
				@class.method_3(gClass, false, flag);
				gClass.AppendBoolean(flag);
				gClass.AppendBoolean(bool_);
				class16_0.method_14(gClass);
			}
		}
	}
}
