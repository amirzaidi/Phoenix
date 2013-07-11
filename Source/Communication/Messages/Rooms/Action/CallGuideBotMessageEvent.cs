using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Messages;
using Phoenix.HabboHotel.RoomBots;
using Phoenix.HabboHotel.Rooms;
using Phoenix.HabboHotel.Pathfinding;
namespace Phoenix.Communication.Messages.Rooms.Action
{
	internal sealed class CallGuideBotMessageEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			Room @class = Phoenix.GetGame().GetRoomManager().GetRoom(class16_0.GetHabbo().CurrentRoomId);
			if (@class != null && @class.method_27(class16_0, true))
			{
				for (int i = 0; i < @class.class33_0.Length; i++)
				{
					Class33 class2 = @class.class33_0[i];
					if (class2 != null && (class2.Boolean_4 && class2.class34_0.enum2_0 == Enum2.const_1))
					{
						ServerMessage gClass = new ServerMessage(33u);
						gClass.AppendInt32(4009);
						class16_0.method_14(gClass);
						return;
					}
				}
				if (class16_0.GetHabbo().bool_10)
				{
					ServerMessage gClass = new ServerMessage(33u);
					gClass.AppendInt32(4010);
					class16_0.method_14(gClass);
				}
				else
				{
					Class33 class3 = @class.method_3(Phoenix.GetGame().GetBotManager().method_3(2u));
					class3.method_7(@class.Class28_0.int_0, @class.Class28_0.int_1, @class.Class28_0.double_0);
					class3.bool_7 = true;
					Class33 class4 = @class.method_56(@class.Owner);
					if (class4 != null)
					{
						class3.method_4(class4.GStruct1_0);
						class3.method_9(Class107.smethod_0(class3.int_3, class3.int_4, class4.int_3, class4.int_4));
					}
					Phoenix.GetGame().GetAchievementManager().method_3(class16_0, 6u, 1);
					class16_0.GetHabbo().bool_10 = true;
				}
			}
		}
	}
}
