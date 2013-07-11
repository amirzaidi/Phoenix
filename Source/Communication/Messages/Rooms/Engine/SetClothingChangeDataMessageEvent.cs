using System;
using System.Linq;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Messages;
using Phoenix.HabboHotel.Items;
using Phoenix.HabboHotel.Rooms;
namespace Phoenix.Communication.Messages.Rooms.Engine
{
	internal sealed class SetClothingChangeDataMessageEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			Room @class = Phoenix.GetGame().GetRoomManager().GetRoom(class16_0.GetHabbo().CurrentRoomId);
			if (@class != null && @class.method_26(class16_0))
			{
				uint num = class18_0.PopWiredUInt();
				string a = class18_0.PopFixedString().ToUpper();
				string text = Phoenix.smethod_7(class18_0.PopFixedString());
				text = text.Replace("hd-99999-99999", "");
				text += ".";
				UserItemData class2 = @class.Hashtable_0[num] as UserItemData;
				if (class2.string_0.Contains(','))
				{
					class2.string_2 = class2.string_0.Split(new char[]
					{
						','
					})[0];
					class2.string_3 = class2.string_0.Split(new char[]
					{
						','
					})[1];
				}
				if (a == "M")
				{
					class2.string_2 = text;
				}
				else
				{
					class2.string_3 = text;
				}
				class2.string_0 = class2.string_2 + "," + class2.string_3;
				class2.method_5(true, true);
			}
		}
	}
}
