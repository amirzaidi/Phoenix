using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Messages;
namespace Phoenix.Communication.Messages.Help
{
	internal sealed class GetRoomChatlogMessageEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			if (class16_0.GetHabbo().HasFuse("acc_chatlogs"))
			{
				class18_0.PopWiredInt32();
				uint uint_ = class18_0.PopWiredUInt();
				if (Phoenix.GetGame().GetRoomManager().GetRoom(uint_) != null)
				{
					class16_0.method_14(Phoenix.GetGame().GetModerationTool().method_22(uint_));
				}
			}
		}
	}
}
