using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Messages;
using Phoenix.HabboHotel.Items;
using Phoenix.HabboHotel.Rooms;
namespace Phoenix.Communication.Messages.Rooms.Engine
{
	internal sealed class PickupObjectMessageEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			class18_0.PopWiredInt32();
			Room @class = Phoenix.GetGame().GetRoomManager().GetRoom(class16_0.GetHabbo().CurrentRoomId);
			if (@class != null && @class.method_27(class16_0, true))
			{
				UserItemData class2 = @class.method_28(class18_0.PopWiredUInt());
				if (class2 != null)
				{
					string text = class2.GetBaseItem().InteractionType.ToLower();
					if (text == null || !(text == "postit"))
					{
						@class.method_29(class16_0, class2.uint_0, false, true);
						class16_0.GetHabbo().method_23().method_11(class2.uint_0, class2.uint_2, class2.string_0, false);
						class16_0.GetHabbo().method_23().method_9(true);
						if (class16_0.GetHabbo().CurrentQuestId == 10u)
						{
							Phoenix.GetGame().GetQuestManager().method_1(10u, class16_0);
						}
					}
				}
			}
		}
	}
}
