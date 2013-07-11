using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Messages;
using Phoenix.HabboHotel.Items;
using Phoenix.HabboHotel.Rooms;
namespace Phoenix.Communication.Messages.Rooms.Engine
{
	internal sealed class RemoveItemMessageEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			Room @class = Phoenix.GetGame().GetRoomManager().GetRoom(class16_0.GetHabbo().CurrentRoomId);
			if (@class != null && @class.method_27(class16_0, true))
			{
				UserItemData class2 = @class.method_28(class18_0.PopWiredUInt());
				if (class2 != null && !(class2.GetBaseItem().InteractionType.ToLower() != "postit"))
				{
					@class.method_29(class16_0, class2.uint_0, true, true);
				}
			}
		}
	}
}
