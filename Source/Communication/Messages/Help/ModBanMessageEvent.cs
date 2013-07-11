using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Messages;
namespace Phoenix.Communication.Messages.Help
{
	internal sealed class ModBanMessageEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			if (class16_0.GetHabbo().HasFuse("acc_supporttool"))
			{
				uint uint_ = class18_0.PopWiredUInt();
				string string_ = class18_0.PopFixedString();
				int int_ = class18_0.PopWiredInt32() * 3600;
				Phoenix.GetGame().GetModerationTool().method_17(class16_0, uint_, int_, string_);
			}
		}
	}
}
