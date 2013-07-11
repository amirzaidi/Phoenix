using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Messages;
namespace Phoenix.Communication.Messages.Messenger
{
	internal sealed class SendMsgMessageEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			uint num = class18_0.PopWiredUInt();
			string text = Phoenix.smethod_7(class18_0.PopFixedString());
			if (class16_0.GetHabbo().method_21() != null)
			{
				if (num == 0u && class16_0.GetHabbo().HasFuse("cmd_sa"))
				{
					ServerMessage gClass = new ServerMessage(134u);
					gClass.AppendUInt(0u);
					gClass.AppendString(class16_0.GetHabbo().Username + ": " + text);
					Phoenix.GetGame().GetClientManager().method_17(class16_0, gClass);
				}
				else
				{
					if (num == 0u)
					{
						ServerMessage gClass2 = new ServerMessage(261u);
						gClass2.AppendInt32(4);
						gClass2.AppendUInt(0u);
						class16_0.method_14(gClass2);
					}
					else
					{
						class16_0.GetHabbo().method_21().method_18(num, text);
					}
				}
			}
		}
	}
}
