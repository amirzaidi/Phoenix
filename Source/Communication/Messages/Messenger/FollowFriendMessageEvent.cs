using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Messages;
using Phoenix.HabboHotel.Rooms;
namespace Phoenix.Communication.Messages.Messenger
{
	internal sealed class FollowFriendMessageEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			uint uint_ = class18_0.PopWiredUInt();
			GameClient @class = Phoenix.GetGame().GetClientManager().method_2(uint_);
			if (@class != null && @class.GetHabbo() != null && @class.GetHabbo().Boolean_0)
			{
				Room class2 = Phoenix.GetGame().GetRoomManager().GetRoom(@class.GetHabbo().CurrentRoomId);
				if (class2 != null && class2 != class16_0.GetHabbo().Class14_0)
				{
					ServerMessage gClass = new ServerMessage(286u);
					gClass.AppendBoolean(class2.Boolean_3);
					gClass.AppendUInt(class2.Id);
					class16_0.method_14(gClass);
				}
			}
		}
	}
}
