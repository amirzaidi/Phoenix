using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Messages;
using Phoenix.HabboHotel.Rooms;
using Phoenix.Storage;
namespace Phoenix.Communication.Messages.Register
{
	internal sealed class UpdateFigureDataMessageEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			string text = class18_0.PopFixedString().ToUpper();
			string text2 = Phoenix.smethod_7(class18_0.PopFixedString());
			//if (class16_0.method_2().Boolean_0 && Class98.smethod_0(text2, text))
			{
				Room class14_ = class16_0.GetHabbo().Class14_0;
				if (class14_ != null)
				{
					Class33 @class = class14_.method_53(class16_0.GetHabbo().Id);
					if (@class != null)
					{
						@class.string_0 = "";
						if (class16_0.GetHabbo().method_4() > 0)
						{
							TimeSpan timeSpan = DateTime.Now - class16_0.GetHabbo().dateTime_0;
							if (timeSpan.Seconds > 4)
							{
								class16_0.GetHabbo().int_23 = 0;
							}
							if (timeSpan.Seconds < 4 && class16_0.GetHabbo().int_23 > 5)
							{
								ServerMessage gClass = new ServerMessage(27u);
								gClass.AppendInt32(class16_0.GetHabbo().method_4());
								class16_0.method_14(gClass);
								return;
							}
							class16_0.GetHabbo().dateTime_0 = DateTime.Now;
							class16_0.GetHabbo().int_23++;
						}
						if (class16_0.GetHabbo().CurrentQuestId == 2u)
						{
							Phoenix.GetGame().GetQuestManager().method_1(2u, class16_0);
						}
						class16_0.GetHabbo().string_5 = text2;
						class16_0.GetHabbo().string_6 = text.ToLower();
						using (DatabaseClient class2 = Phoenix.GetDatabase().GetClient())
						{
							class2.AddParamWithValue("look", text2);
							class2.AddParamWithValue("gender", text);
							class2.ExecuteQuery("UPDATE users SET look = @look, gender = @gender WHERE id = '" + class16_0.GetHabbo().Id + "' LIMIT 1;");
						}
						ServerMessage gClass2 = new ServerMessage(266u);
						gClass2.AppendInt32(-1);
						gClass2.AppendStringWithBreak(class16_0.GetHabbo().string_5);
						gClass2.AppendStringWithBreak(class16_0.GetHabbo().string_6.ToLower());
						gClass2.AppendStringWithBreak(class16_0.GetHabbo().string_4);
						gClass2.AppendInt32(class16_0.GetHabbo().int_13);
						gClass2.AppendStringWithBreak("");
						class16_0.method_14(gClass2);
						ServerMessage gClass3 = new ServerMessage(266u);
						gClass3.AppendInt32(@class.int_0);
						gClass3.AppendStringWithBreak(class16_0.GetHabbo().string_5);
						gClass3.AppendStringWithBreak(class16_0.GetHabbo().string_6.ToLower());
						gClass3.AppendStringWithBreak(class16_0.GetHabbo().string_4);
						gClass3.AppendInt32(class16_0.GetHabbo().int_13);
						gClass3.AppendStringWithBreak("");
						class14_.SendMessage(gClass3, null);
						Phoenix.GetGame().GetAchievementManager().method_3(class16_0, 1u, 1);
					}
				}
			}
		}
	}
}
