using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Messages;
using Phoenix.HabboHotel.Items;
using Phoenix.HabboHotel.Rooms;
namespace Phoenix.Communication.Messages.Rooms.Engine
{
	internal sealed class MoveWallItemMessageEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			Room @class = Phoenix.GetGame().GetRoomManager().GetRoom(class16_0.GetHabbo().CurrentRoomId);
			if (@class != null && @class.method_26(class16_0))
			{
				UserItemData class2 = @class.method_28(class18_0.PopWiredUInt());
				if (class2 != null)
				{
					string string_ = class18_0.PopFixedString();
					@class.method_82(class16_0, class2, false, string_);
				}
			}
		}
	}
}
