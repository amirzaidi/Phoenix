using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.HabboHotel.Rooms;
using Phoenix.Messages;
namespace Phoenix.Communication.Messages.Help
{
	internal sealed class GetModeratorRoomInfoMessageEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			if (class16_0.GetHabbo().HasFuse("acc_supporttool"))
			{
				uint uint_ = class18_0.PopWiredUInt();
                RoomData class27_ = Phoenix.GetGame().GetRoomManager().method_11(uint_);
				class16_0.method_14(Phoenix.GetGame().GetModerationTool().method_14(class27_));
			}
		}
	}
}
