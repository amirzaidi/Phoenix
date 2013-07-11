using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Messages;
namespace Phoenix.Communication.Messages.Help
{
	internal sealed class GetRoomVisitsMessageEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			if (class16_0.GetHabbo().HasFuse("acc_supporttool"))
			{
				uint uint_ = class18_0.PopWiredUInt();
				class16_0.method_14(Phoenix.GetGame().GetModerationTool().method_19(uint_));
			}
		}
	}
}
