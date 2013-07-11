using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Messages;
namespace Phoenix.Communication.Messages.Help
{
	internal sealed class ModerateRoomMessageEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			if (class16_0.GetHabbo().HasFuse("acc_supporttool"))
			{
				uint uint_ = class18_0.PopWiredUInt();
				bool flag = class18_0.PopWiredBoolean();
				bool flag2 = class18_0.PopWiredBoolean();
				bool flag3 = class18_0.PopWiredBoolean();
				string text = "";
				if (flag)
				{
					text += "Apply Doorbell";
				}
				if (flag2)
				{
					text += " Change Name";
				}
				if (flag3)
				{
					text += " Kick Users";
				}
				Phoenix.GetGame().GetClientManager().method_31(class16_0, "ModTool - Room Action", text);
				Phoenix.GetGame().GetModerationTool().method_12(class16_0, uint_, flag3, flag, flag2);
			}
		}
	}
}
