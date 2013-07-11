using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Messages;
namespace Phoenix.Communication.Messages.Users
{
	internal sealed class ScrGetUserInfoMessageEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			string text = class18_0.PopFixedString();
			ServerMessage gClass = new ServerMessage(7u);
			gClass.AppendStringWithBreak(text.ToLower());
			if (class16_0.GetHabbo().method_20().method_2("habbo_vip"))
			{
				double num = (double)class16_0.GetHabbo().method_20().method_1("habbo_vip").Int32_0;
				double num2 = num - Phoenix.GetUnixTimestamp();
				int num3 = (int)Math.Ceiling(num2 / 86400.0);
				int num4 = num3 / 31;
				if (num4 >= 1)
				{
					num4--;
				}
				gClass.AppendInt32(num3 - num4 * 31);
				gClass.AppendBoolean(true);
				gClass.AppendInt32(num4);
				gClass.AppendBoolean(true);
				gClass.AppendBoolean(true);
				gClass.AppendBoolean(class16_0.GetHabbo().bool_14);
				gClass.AppendInt32(0);
				gClass.AppendInt32(0);
			}
			else
			{
				if (class16_0.GetHabbo().method_20().method_2(text))
				{
					double num = (double)class16_0.GetHabbo().method_20().method_1(text).Int32_0;
					double num2 = num - Phoenix.GetUnixTimestamp();
					int num3 = (int)Math.Ceiling(num2 / 86400.0);
					int num4 = num3 / 31;
					if (num4 >= 1)
					{
						num4--;
					}
					gClass.AppendInt32(num3 - num4 * 31);
					gClass.AppendBoolean(true);
					gClass.AppendInt32(num4);
					if (class16_0.GetHabbo().uint_1 >= 2u)
					{
						gClass.AppendInt32(1);
						gClass.AppendInt32(1);
						gClass.AppendInt32(2);
					}
					else
					{
						gClass.AppendInt32(1);
					}
				}
				else
				{
					for (int i = 0; i < 3; i++)
					{
						gClass.AppendInt32(0);
					}
				}
			}
			class16_0.method_14(gClass);
		}
	}
}
