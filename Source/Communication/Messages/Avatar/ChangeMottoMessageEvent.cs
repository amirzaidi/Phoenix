using System;
using Phoenix.HabboHotel.Misc;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Messages;
using Phoenix.HabboHotel.Rooms;
using Phoenix.Storage;
namespace Phoenix.Communication.Messages.Avatar
{
	internal sealed class ChangeMottoMessageEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			string text = Phoenix.smethod_7(class18_0.PopFixedString());
			if (text.Length <= 50 && !(text != ChatCommandHandler.smethod_4(text)) && !(text == class16_0.GetHabbo().string_4))
			{
				class16_0.GetHabbo().string_4 = text;
				using (DatabaseClient @class = Phoenix.GetDatabase().GetClient())
				{
					@class.AddParamWithValue("motto", text);
					@class.ExecuteQuery("UPDATE users SET motto = @motto WHERE id = '" + class16_0.GetHabbo().Id + "' LIMIT 1");
				}
				if (class16_0.GetHabbo().CurrentQuestId == 17u)
				{
					Phoenix.GetGame().GetQuestManager().method_1(17u, class16_0);
				}
				ServerMessage gClass = new ServerMessage(484u);
				gClass.AppendInt32(-1);
				gClass.AppendStringWithBreak(class16_0.GetHabbo().string_4);
				class16_0.method_14(gClass);
				if (class16_0.GetHabbo().Boolean_0)
				{
					Room class14_ = class16_0.GetHabbo().Class14_0;
					if (class14_ == null)
					{
						return;
					}
					Class33 class2 = class14_.method_53(class16_0.GetHabbo().Id);
					if (class2 == null)
					{
						return;
					}
					ServerMessage gClass2 = new ServerMessage(266u);
					gClass2.AppendInt32(class2.int_0);
					gClass2.AppendStringWithBreak(class16_0.GetHabbo().string_5);
					gClass2.AppendStringWithBreak(class16_0.GetHabbo().string_6.ToLower());
					gClass2.AppendStringWithBreak(class16_0.GetHabbo().string_4);
					gClass2.AppendInt32(class16_0.GetHabbo().int_13);
					gClass2.AppendStringWithBreak("");
					class14_.SendMessage(gClass2, null);
				}
				Phoenix.GetGame().GetAchievementManager().method_3(class16_0, 5u, 1);
			}
		}
	}
}
