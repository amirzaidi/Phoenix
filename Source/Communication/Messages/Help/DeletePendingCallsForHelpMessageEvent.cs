using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Messages;
namespace Phoenix.Communication.Messages.Help
{
	internal sealed class DeletePendingCallsForHelpMessageEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			if (Phoenix.GetGame().GetModerationTool().method_9(class16_0.GetHabbo().Id))
			{
				Phoenix.GetGame().GetModerationTool().method_10(class16_0.GetHabbo().Id);
				ServerMessage gclass5_ = new ServerMessage(320u);
				class16_0.method_14(gclass5_);
			}
		}
	}
}
