using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Messages;
using Phoenix.HabboHotel.Users.Badges;
using Phoenix.HabboHotel.Rooms;
namespace Phoenix.Communication.Messages.Users
{
	internal sealed class GetSelectedBadgesMessageEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			if (class16_0 != null && class16_0.GetHabbo() != null)
			{
				Room @class = Phoenix.GetGame().GetRoomManager().GetRoom(class16_0.GetHabbo().CurrentRoomId);
				if (@class != null)
				{
					Class33 class2 = @class.method_53(class18_0.PopWiredUInt());
					if (class2 != null && !class2.Boolean_4 && class2.method_16() != null)
					{
						ServerMessage gClass = new ServerMessage(228u);
						gClass.AppendUInt(class2.method_16().GetHabbo().Id);
						gClass.AppendInt32(class2.method_16().GetHabbo().method_22().Int32_1);
						using (TimedLock.Lock(class2.method_16().GetHabbo().method_22().List_0))
						{
							foreach (UserBadge current in class2.method_16().GetHabbo().method_22().List_0)
							{
								if (current.Slot > 0)
								{
									gClass.AppendInt32(current.Slot);
									gClass.AppendStringWithBreak(current.Code);
								}
							}
						}
						class16_0.method_14(gClass);
					}
				}
			}
		}
	}
}
