using System;
using Phoenix.HabboHotel.Misc;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Util;
using Phoenix.Messages;
using Phoenix.HabboHotel.Rooms;
using Phoenix.Storage;
namespace Phoenix.Communication.Messages.Rooms.Chat
{
	internal sealed class WhisperMessageEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			Room @class = Phoenix.GetGame().GetRoomManager().GetRoom(class16_0.GetHabbo().CurrentRoomId);
			if (@class != null && class16_0 != null)
			{
				if (class16_0.GetHabbo().bool_3)
				{
					class16_0.SendNotif(PhoenixEnvironment.GetExternalText("error_muted"));
				}
				else
				{
					if (class16_0.GetHabbo().HasFuse("ignore_roommute") || !@class.bool_4)
					{
						string text = Phoenix.smethod_7(class18_0.PopFixedString());
						string text2 = text.Split(new char[]
						{
							' '
						})[0];
						string text3 = text.Substring(text2.Length + 1);
						text3 = ChatCommandHandler.smethod_4(text3);
						Class33 class2 = @class.method_53(class16_0.GetHabbo().Id);
						Class33 class3 = @class.method_56(text2);
						if (class16_0.GetHabbo().method_4() > 0)
						{
							TimeSpan timeSpan = DateTime.Now - class16_0.GetHabbo().dateTime_0;
							if (timeSpan.Seconds > 4)
							{
								class16_0.GetHabbo().int_23 = 0;
							}
							if (timeSpan.Seconds < 4 && class16_0.GetHabbo().int_23 > 5 && !class2.Boolean_4)
							{
								ServerMessage gClass = new ServerMessage(27u);
								gClass.AppendInt32(class16_0.GetHabbo().method_4());
								class16_0.method_14(gClass);
								class16_0.GetHabbo().bool_3 = true;
								class16_0.GetHabbo().int_4 = class16_0.GetHabbo().method_4();
								return;
							}
							class16_0.GetHabbo().dateTime_0 = DateTime.Now;
							class16_0.GetHabbo().int_23++;
						}
						ServerMessage gClass2 = new ServerMessage(25u);
						gClass2.AppendInt32(class2.int_0);
						gClass2.AppendStringWithBreak(text3);
						gClass2.AppendBoolean(false);
						if (class2 != null && !class2.Boolean_4)
						{
							class2.method_16().method_14(gClass2);
						}
						class2.method_0();
						if (class3 != null && !class3.Boolean_4 && (class3.method_16().GetHabbo().list_2.Count <= 0 || !class3.method_16().GetHabbo().list_2.Contains(class16_0.GetHabbo().Id)))
						{
							class3.method_16().method_14(gClass2);
							if (Config.Boolean_4 && !class16_0.GetHabbo().bool_0)
							{
								using (DatabaseClient class4 = Phoenix.GetDatabase().GetClient())
								{
									class4.AddParamWithValue("message", "<Whisper to " + class3.method_16().GetHabbo().Username + ">: " + text3);
									class4.ExecuteQuery(string.Concat(new object[]
									{
										"INSERT INTO chatlogs (user_id,room_id,hour,minute,timestamp,message,user_name,full_date) VALUES ('",
										class16_0.GetHabbo().Id,
										"','",
										@class.Id,
										"','",
										DateTime.Now.Hour,
										"','",
										DateTime.Now.Minute,
										"',UNIX_TIMESTAMP(),@message,'",
										class16_0.GetHabbo().Username,
										"','",
										DateTime.Now.ToLongDateString(),
										"')"
									}));
								}
							}
						}
					}
				}
			}
		}
	}
}
