using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Messages;
using Phoenix.HabboHotel.Rooms;
using Phoenix.HabboHotel.Pathfinding;
namespace Phoenix.Communication.Messages.Rooms.Avatar
{
	internal sealed class LookToMessageEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			Room @class = Phoenix.GetGame().GetRoomManager().GetRoom(class16_0.GetHabbo().CurrentRoomId);
			if (@class != null)
			{
				Class33 class2 = @class.method_53(class16_0.GetHabbo().Id);
				if (class2 != null)
				{
					class2.method_0();
					int num = class18_0.PopWiredInt32();
					int num2 = class18_0.PopWiredInt32();
					if (num != class2.int_3 || num2 != class2.int_4)
					{
						int int_ = Class107.smethod_0(class2.int_3, class2.int_4, num, num2);
						class2.method_9(int_);
						if (class2.class34_1 != null && class2.class33_0 != null)
						{
							class2.class33_0.method_9(int_);
						}
					}
				}
			}
		}
	}
}
