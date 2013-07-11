using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Messages;
using Phoenix.Storage;
using Phoenix.HabboHotel.Rooms;
namespace Phoenix.Communication.Messages.Rooms.Engine
{
	internal sealed class SetObjectDataMessageEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			Room @class = Phoenix.GetGame().GetRoomManager().GetRoom(class16_0.GetHabbo().CurrentRoomId);
			if (@class != null && @class.method_26(class16_0))
			{
				int num = class18_0.PopWiredInt32();
				int num2 = class18_0.PopWiredInt32();
				string text = class18_0.PopFixedString();
				string text2 = class18_0.PopFixedString();
				string text3 = class18_0.PopFixedString();
				string text4 = class18_0.PopFixedString();
				string text5 = class18_0.PopFixedString();
				string text6 = class18_0.PopFixedString();
				string text7 = class18_0.PopFixedString();
				string text8 = class18_0.PopFixedString();
				string text9 = class18_0.PopFixedString();
				string text10 = class18_0.PopFixedString();
				string text11 = "";
				if (num2 == 10 || num2 == 8)
				{
					text11 = string.Concat(new object[]
					{
						text,
						"=",
						text2,
						Convert.ToChar(9),
						text3,
						"=",
						text4,
						Convert.ToChar(9),
						text5,
						"=",
						text6,
						Convert.ToChar(9),
						text7,
						"=",
						text8
					});
					if (text9 != "")
					{
						text11 = string.Concat(new object[]
						{
							text11,
							Convert.ToChar(9),
							text9,
							"=",
							text10
						});
					}
					using (DatabaseClient class2 = Phoenix.GetDatabase().GetClient())
					{
						class2.AddParamWithValue("extradata", text11);
						class2.ExecuteQuery("UPDATE items SET extra_data = @extradata WHERE id = '" + num + "' LIMIT 1");
					}
					ServerMessage gClass = new ServerMessage(88u);
					gClass.AppendStringWithBreak(num.ToString());
					gClass.AppendStringWithBreak(text11);
					@class.SendMessage(gClass, null);
					@class.method_28((uint)num).string_0 = text11;
					@class.method_28((uint)num).method_5(true, false);
				}
			}
		}
	}
}
