using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Messages;
using Phoenix.HabboHotel.Rooms;
namespace Phoenix.Communication.Messages.Users
{
	internal sealed class GetHabboGroupBadgesMessageEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			if (class16_0 != null && class16_0.GetHabbo() != null && class16_0.GetHabbo().uint_2 > 0u)
			{
				Room @class = Phoenix.GetGame().GetRoomManager().GetRoom(class16_0.GetHabbo().uint_2);
				if (@class != null && class16_0.GetHabbo().int_0 > 0)
				{
					GroupsManager class2 = Groups.smethod_2(class16_0.GetHabbo().int_0);
					if (class2 != null && !@class.list_17.Contains(class2))
					{
						@class.list_17.Add(class2);
						ServerMessage gClass = new ServerMessage(309u);
						gClass.AppendInt32(@class.list_17.Count);
						foreach (GroupsManager current in @class.list_17)
						{
							gClass.AppendInt32(current.int_0);
							gClass.AppendStringWithBreak(current.string_2);
						}
						@class.SendMessage(gClass, null);
					}
					else
					{
						foreach (GroupsManager current2 in @class.list_17)
						{
							if (current2 == class2 && current2.string_2 != class2.string_2)
							{
								ServerMessage gClass = new ServerMessage(309u);
								gClass.AppendInt32(@class.list_17.Count);
								foreach (GroupsManager current in @class.list_17)
								{
									gClass.AppendInt32(current.int_0);
									gClass.AppendStringWithBreak(current.string_2);
								}
								@class.SendMessage(gClass, null);
							}
						}
					}
				}
				if (@class != null && @class.list_17.Count > 0)
				{
					ServerMessage gClass = new ServerMessage(309u);
					gClass.AppendInt32(@class.list_17.Count);
					foreach (GroupsManager current in @class.list_17)
					{
						gClass.AppendInt32(current.int_0);
						gClass.AppendStringWithBreak(current.string_2);
					}
					class16_0.method_14(gClass);
				}
			}
		}
	}
}
