using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Messages;
namespace Phoenix.Communication.Messages.Help
{
	internal sealed class ModKickMessageEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			if (class16_0.GetHabbo().HasFuse("acc_supporttool"))
			{
				uint num = class18_0.PopWiredUInt();
				string text = class18_0.PopFixedString();
				string string_ = string.Concat(new object[]
				{
					"User: ",
					num,
					", Message: ",
					text
				});
				Phoenix.GetGame().GetClientManager().method_31(class16_0, "ModTool - Kick User", string_);
				Phoenix.GetGame().GetModerationTool().method_15(class16_0, num, text, false);
			}
		}
	}
}
