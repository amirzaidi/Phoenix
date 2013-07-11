using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.HabboHotel.Support;
using Phoenix.HabboHotel.Rooms;
using Phoenix.Messages;
namespace Phoenix.Communication.Messages.Help
{
	internal sealed class GetCfhChatlogMessageEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			if (class16_0.GetHabbo().HasFuse("acc_supporttool"))
			{
				SupportTicket @class = Phoenix.GetGame().GetModerationTool().method_5(class18_0.PopWiredUInt());
				if (@class != null)
				{
                    RoomData class2 = Phoenix.GetGame().GetRoomManager().method_11(@class.RoomId);
					if (class2 != null)
					{
                        class16_0.method_14(Phoenix.GetGame().GetModerationTool().method_21(@class, class2, @class.Timestamp));
					}
				}
			}
		}
	}
}
