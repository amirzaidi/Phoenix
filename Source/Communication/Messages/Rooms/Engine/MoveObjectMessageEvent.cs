using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Messages;
using Phoenix.HabboHotel.Items;
using Phoenix.HabboHotel.Rooms;
namespace Phoenix.Communication.Messages.Rooms.Engine
{
	internal sealed class MoveObjectMessageEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			Room @class = Phoenix.GetGame().GetRoomManager().GetRoom(class16_0.GetHabbo().CurrentRoomId);
			if (@class != null && @class.method_26(class16_0))
			{
				UserItemData class2 = @class.method_28(class18_0.PopWiredUInt());
				if (class2 != null)
				{
					int num = class18_0.PopWiredInt32();
					int num2 = class18_0.PopWiredInt32();
					int num3 = class18_0.PopWiredInt32();
					class18_0.PopWiredInt32();
					if (class16_0.GetHabbo().CurrentQuestId == 1u && (num != class2.Int32_0 || num2 != class2.Int32_1))
					{
						Phoenix.GetGame().GetQuestManager().method_1(1u, class16_0);
					}
					else
					{
						if (class16_0.GetHabbo().CurrentQuestId == 7u && num3 != class2.int_3)
						{
							Phoenix.GetGame().GetQuestManager().method_1(7u, class16_0);
						}
						else
						{
							if (class16_0.GetHabbo().CurrentQuestId == 9u && class2.Double_0 >= 0.1)
							{
								Phoenix.GetGame().GetQuestManager().method_1(9u, class16_0);
							}
						}
					}
					bool flag = false;
					string text = class2.GetBaseItem().InteractionType.ToLower();
					if (text != null && text == "teleport")
					{
						flag = true;
					}
					@class.method_79(class16_0, class2, num, num2, num3, false, false, false);
					if (flag)
					{
						@class.method_64();
					}
				}
			}
		}
	}
}
