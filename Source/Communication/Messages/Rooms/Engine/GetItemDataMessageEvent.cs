using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Messages;
using Phoenix.HabboHotel.Items;
using Phoenix.HabboHotel.Rooms;
namespace Phoenix.Communication.Messages.Rooms.Engine
{
	internal sealed class GetItemDataMessageEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			Room @class = Phoenix.GetGame().GetRoomManager().GetRoom(class16_0.GetHabbo().CurrentRoomId);
			if (@class != null)
			{
				UserItemData class2 = @class.method_28(class18_0.PopWiredUInt());
				if (class2 != null && !(class2.GetBaseItem().InteractionType.ToLower() != "postit"))
				{
					ServerMessage gClass = new ServerMessage(48u);
					gClass.AppendStringWithBreak(class2.uint_0.ToString());
					gClass.AppendStringWithBreak(class2.string_0);
					class16_0.method_14(gClass);
				}
			}
		}
	}
}
