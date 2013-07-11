using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Messages;
namespace Phoenix.Communication.Messages.Help
{
	internal sealed class ModeratorActionMessageEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			if (class16_0.GetHabbo().HasFuse("acc_supporttool"))
			{
				class18_0.PopWiredInt32();
				int num = class18_0.PopWiredInt32();
				string text = class18_0.PopFixedString();
				string text2 = "";
				if (num.Equals(3))
				{
					text2 += "Room Cautioned.";
				}
				text2 = text2 + " Message: " + text;
				Phoenix.GetGame().GetClientManager().method_31(class16_0, "ModTool - Room Alert", text2);
				Phoenix.GetGame().GetModerationTool().method_13(class16_0.GetHabbo().CurrentRoomId, !num.Equals(3), text);
			}
		}
	}
}
