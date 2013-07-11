using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Messages;
namespace Phoenix.Communication.Messages.Help
{
	internal sealed class ReleaseIssuesMessageEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			if (class16_0.GetHabbo().HasFuse("acc_supporttool"))
			{
				int num = class18_0.PopWiredInt32();
				for (int i = 0; i < num; i++)
				{
					uint uint_ = class18_0.PopWiredUInt();
					Phoenix.GetGame().GetModerationTool().method_7(class16_0, uint_);
				}
			}
		}
	}
}
