using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Messages;
namespace Phoenix.Communication.Messages.Help
{
	internal sealed class CallForHelpMessageEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			bool flag = false;
			if (Phoenix.GetGame().GetModerationTool().method_9(class16_0.GetHabbo().Id))
			{
				flag = true;
			}
			if (!flag)
			{
				string string_ = Phoenix.smethod_7(class18_0.PopFixedString());
				class18_0.PopWiredInt32();
				int int_ = class18_0.PopWiredInt32();
				uint uint_ = class18_0.PopWiredUInt();
				Phoenix.GetGame().GetModerationTool().method_3(class16_0, int_, uint_, string_);
			}
			ServerMessage gClass = new ServerMessage(321u);
			gClass.AppendBoolean(flag);
			class16_0.method_14(gClass);
		}
	}
}
