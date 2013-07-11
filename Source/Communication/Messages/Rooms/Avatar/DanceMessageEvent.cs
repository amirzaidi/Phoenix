using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Messages;
using Phoenix.HabboHotel.Rooms;
namespace Phoenix.Communication.Messages.Rooms.Avatar
{
	internal sealed class DanceMessageEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			Room @class = Phoenix.GetGame().GetRoomManager().GetRoom(class16_0.GetHabbo().CurrentRoomId);
			//if (@class != null)
			{
				Class33 class2 = @class.method_53(class16_0.GetHabbo().Id);
				//if (class2 != null)
				{
				    class2.method_0();
					int num = class18_0.PopWiredInt32();

					if (num < 0 || num > 4 || (!class16_0.GetHabbo().method_20().method_2("habbo_club") && num > 1))
					{
						num = 0;
					}
					if (num > 0 && class2.int_5 > 0)
					{
						class2.method_8(0);
					}
					class2.int_15 = num;
					ServerMessage gClass = new ServerMessage(480u);
					gClass.AppendInt32(class2.int_0);
					gClass.AppendInt32(num);
					@class.SendMessage(gClass, null);
					
                    if (class16_0.GetHabbo().CurrentQuestId == 6u)
					{
						Phoenix.GetGame().GetQuestManager().method_1(6u, class16_0);
					}
				}
			}
		}
	}
}
