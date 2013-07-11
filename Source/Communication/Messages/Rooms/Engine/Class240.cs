using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.HabboHotel.Items;
using Phoenix.Messages;
using Phoenix.Storage;
using Phoenix.HabboHotel.Rooms;
namespace Phoenix.Communication.Messages.Rooms.Engine
{
	internal sealed class Class240 : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			Room @class = Phoenix.GetGame().GetRoomManager().GetRoom(class16_0.GetHabbo().CurrentRoomId);
			if (@class != null && @class.method_27(class16_0, true))
			{
				Class39 class2 = class16_0.GetHabbo().method_23().method_10(class18_0.PopWiredUInt());
				if (class2 != null)
				{
					string text = "floor";
					if (class2.method_1().string_1.ToLower().Contains("wallpaper"))
					{
						text = "wallpaper";
					}
					else
					{
						if (class2.method_1().string_1.ToLower().Contains("landscape"))
						{
							text = "landscape";
						}
					}
					string text2 = text;
					if (text2 != null)
					{
						if (!(text2 == "floor"))
						{
							if (!(text2 == "wallpaper"))
							{
								if (text2 == "landscape")
								{
									@class.Landscape = class2.string_0;
								}
							}
							else
							{
								@class.Wallpaper = class2.string_0;
								if (class16_0.GetHabbo().CurrentQuestId == 11u)
								{
									Phoenix.GetGame().GetQuestManager().method_1(11u, class16_0);
								}
							}
						}
						else
						{
							@class.Floor = class2.string_0;
							if (class16_0.GetHabbo().CurrentQuestId == 13u)
							{
								Phoenix.GetGame().GetQuestManager().method_1(13u, class16_0);
							}
						}
					}
					using (DatabaseClient class3 = Phoenix.GetDatabase().GetClient())
					{
						class3.AddParamWithValue("extradata", class2.string_0);
						class3.ExecuteQuery(string.Concat(new object[]
						{
							"UPDATE rooms SET ",
							text,
							" = @extradata WHERE id = '",
							@class.Id,
							"' LIMIT 1"
						}));
					}
					class16_0.GetHabbo().method_23().method_12(class2.uint_0, 0u, false);
					ServerMessage gClass = new ServerMessage(46u);
					gClass.AppendStringWithBreak(text);
					gClass.AppendStringWithBreak(class2.string_0);
					@class.SendMessage(gClass, null);
					Phoenix.GetGame().GetRoomManager().method_18(@class.Id);
				}
			}
		}
	}
}
