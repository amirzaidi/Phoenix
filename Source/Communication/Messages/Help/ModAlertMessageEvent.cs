using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Messages;
namespace Phoenix.Communication.Messages.Help
{
	internal sealed class ModAlertMessageEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			if (class16_0.GetHabbo().HasFuse("acc_supporttool"))
			{
				uint uint_ = class18_0.PopWiredUInt();
				string string_ = class18_0.PopFixedString();
				Phoenix.GetGame().GetModerationTool().method_16(class16_0, uint_, string_, true);
			}
		}
	}
}
