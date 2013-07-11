using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Messages;
using Phoenix.HabboHotel.Rooms;
namespace Phoenix.Communication.Messages.Rooms.Action
{
	internal sealed class KickUserMessageEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			Room @class = Phoenix.GetGame().GetRoomManager().GetRoom(class16_0.GetHabbo().CurrentRoomId);
			if (@class != null && @class.method_26(class16_0))
			{
				uint uint_ = class18_0.PopWiredUInt();
				Class33 class2 = @class.method_53(uint_);
				if (class2 != null && !class2.Boolean_4 && (!@class.method_27(class2.method_16(), true) && !class2.method_16().GetHabbo().HasFuse("acc_unkickable")))
				{
					@class.method_78(class16_0.GetHabbo().Id);
					@class.method_47(class2.method_16(), true, true);
				}
			}
		}
	}
}
