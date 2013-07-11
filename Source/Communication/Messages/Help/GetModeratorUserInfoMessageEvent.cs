using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Messages;
namespace Phoenix.Communication.Messages.Help
{
	internal sealed class GetModeratorUserInfoMessageEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			if (class16_0.GetHabbo().HasFuse("acc_supporttool"))
			{
				uint uint_ = class18_0.PopWiredUInt();
				if (Phoenix.GetGame().GetClientManager().GetNameById(uint_) != "Unknown User")
				{
					class16_0.method_14(Phoenix.GetGame().GetModerationTool().method_18(uint_));
				}
				else
				{
					class16_0.SendNotif("Could not load user info, invalid user.");
				}
			}
		}
	}
}
