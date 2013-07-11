using System;
using System.Collections.Generic;
using System.Text;
using Phoenix.HabboHotel.Misc;
using Phoenix.HabboHotel.GameClients;
using Phoenix.HabboHotel.Rooms;
using Phoenix.Messages;
using Phoenix.HabboHotel.Navigators;
using Phoenix.Storage;
namespace Phoenix.Communication.Messages.Rooms.Settings
{
	internal sealed class SaveRoomSettingsMessageEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			Room @class = Phoenix.GetGame().GetRoomManager().GetRoom(class16_0.GetHabbo().CurrentRoomId);
			if (@class != null && @class.method_27(class16_0, true))
			{
				class18_0.PopWiredInt32();
				string text = Phoenix.smethod_7(class18_0.PopFixedString());
				string text2 = Phoenix.smethod_7(class18_0.PopFixedString());
				if (text2.Length > 255)
				{
					text2 = text2.Substring(0, 255);
				}
				int num = class18_0.PopWiredInt32();
				string text3 = Phoenix.smethod_7(class18_0.PopFixedString());
				int num2 = class18_0.PopWiredInt32();
				int num3 = class18_0.PopWiredInt32();
				int num4 = class18_0.PopWiredInt32();
				List<string> list = new List<string>();
				StringBuilder stringBuilder = new StringBuilder();
				for (int i = 0; i < num4; i++)
				{
					if (i > 0)
					{
						stringBuilder.Append(",");
					}
					string text4 = Phoenix.smethod_7(class18_0.PopFixedString().ToLower());
					if (text4 == ChatCommandHandler.smethod_4(text4))
					{
						list.Add(text4);
						stringBuilder.Append(text4);
					}
				}
				if (stringBuilder.Length > 100)
				{
					stringBuilder.Clear();
					stringBuilder.Append("");
				}
				int num5 = 0;
				int num6 = 0;
				int num7 = 0;
				int num8 = 0;
				string a = class18_0.PlainReadBytes(1)[0].ToString();
				class18_0.AdvancePointer(1);
				string a2 = class18_0.PlainReadBytes(1)[0].ToString();
				class18_0.AdvancePointer(1);
				string a3 = class18_0.PlainReadBytes(1)[0].ToString();
				class18_0.AdvancePointer(1);
				string a4 = class18_0.PlainReadBytes(1)[0].ToString();
				class18_0.AdvancePointer(1);
				int num9 = class18_0.PopWiredInt32();
				int num10 = class18_0.PopWiredInt32();
				if (!(text != ChatCommandHandler.smethod_4(text)) && !(text2 != ChatCommandHandler.smethod_4(text2)) && text.Length >= 1 && (num9 >= -2 && num9 <= 1 && num10 >= -2 && num10 <= 1))
				{
					@class.Wallthick = num9;
					@class.Floorthick = num10;
					if (num >= 0 && num <= 2 && (num2 == 10 || num2 == 15 || num2 == 20 || num2 == 25 || num2 == 30 || num2 == 35 || num2 == 40 || num2 == 45 || num2 == 50 || num2 == 55 || num2 == 60 || num2 == 65 || num2 == 70 || num2 == 75 || num2 == 80 || num2 == 85 || num2 == 90 || num2 == 95 || num2 == 100))
					{
						NavigatorFlatcats class2 = Phoenix.GetGame().GetNavigator().method_2(num3);
						if (class2 != null)
						{
							if ((long)class2.MinRank > (long)((ulong)class16_0.GetHabbo().uint_1))
							{
								class16_0.SendNotif("You are not allowed to use this category. Your room has been moved to no category instead.");
								num3 = 0;
							}
							if (num4 <= 2)
							{
								if (a == "65")
								{
									num5 = 1;
									@class.AllowPet = true;
								}
								else
								{
									@class.AllowPet = false;
								}
								if (a2 == "65")
								{
									num6 = 1;
									@class.AllowPetsEating = true;
								}
								else
								{
									@class.AllowPetsEating = false;
								}
								if (a3 == "65")
								{
									num7 = 1;
									@class.AllowWalkthrough = true;
								}
								else
								{
									@class.AllowWalkthrough = false;
								}
								@class.method_22();
								if (a4 == "65")
								{
									num8 = 1;
									@class.Hidewall = true;
								}
								else
								{
									@class.Hidewall = false;
								}
								@class.Name = text;
								@class.State = num;
								@class.Description = text2;
								@class.Category = num3;
								if (text3 != "")
								{
									@class.Password = text3;
								}
								@class.Tags = list;
								@class.UsersMax = num2;
								string text5 = "open";
								if (@class.State == 1)
								{
									text5 = "locked";
								}
								else
								{
									if (@class.State > 1)
									{
										text5 = "password";
									}
								}
								using (DatabaseClient class3 = Phoenix.GetDatabase().GetClient())
								{
									class3.AddParamWithValue("caption", @class.Name);
									class3.AddParamWithValue("description", @class.Description);
									class3.AddParamWithValue("password", @class.Password);
									class3.AddParamWithValue("tags", stringBuilder.ToString());
									class3.ExecuteQuery(string.Concat(new object[]
									{
										"UPDATE rooms SET caption = @caption, description = @description, password = @password, category = '",
										num3,
										"', state = '",
										text5,
										"', tags = @tags, users_max = '",
										num2,
										"', allow_pets = '",
										num5,
										"', allow_pets_eat = '",
										num6,
										"', allow_walkthrough = '",
										num7,
										"', allow_hidewall = '",
										num8,
										"', wallthick = '",
										num9,
										"', floorthick = '",
										num10,
										"'  WHERE id = '",
										@class.Id,
										"' LIMIT 1;"
									}));
								}
								ServerMessage gClass = new ServerMessage(467u);
								gClass.AppendUInt(@class.Id);
								class16_0.method_14(gClass);
								ServerMessage gClass2 = new ServerMessage(456u);
								gClass2.AppendUInt(@class.Id);
								class16_0.method_14(gClass2);
								ServerMessage gClass3 = new ServerMessage(472u);
								gClass3.AppendBoolean(@class.Hidewall);
								gClass3.AppendInt32(@class.Wallthick);
								gClass3.AppendInt32(@class.Floorthick);
								@class.SendMessage(gClass3, null);
								ServerMessage gClass4 = new ServerMessage(473u);
								gClass4.AppendBoolean(true);
								gClass4.AppendBoolean(true);
								@class.SendMessage(gClass4, null);
                                RoomData class27_ = @class.Class27_0;
								ServerMessage gClass5 = new ServerMessage(454u);
								gClass5.AppendBoolean(false);
								class27_.method_3(gClass5, false, false);
								class16_0.method_14(gClass5);
							}
						}
					}
				}
			}
		}
	}
}
