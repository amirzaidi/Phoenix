using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Messages;
using Phoenix.HabboHotel.Items;
using Phoenix.HabboHotel.Rooms;
namespace Phoenix.Communication.Messages.Rooms.Engine
{
	internal sealed class SetItemDataMessageEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			Room @class = Phoenix.GetGame().GetRoomManager().GetRoom(class16_0.GetHabbo().CurrentRoomId);
			if (@class != null)
			{
				UserItemData class2 = @class.method_28(class18_0.PopWiredUInt());
				if (class2 != null && !(class2.GetBaseItem().InteractionType.ToLower() != "postit"))
				{
					string text = class18_0.PopFixedString();
					string text2 = text.Split(new char[]
					{
						' '
					})[0];
					string str = Phoenix.smethod_8(text.Substring(text2.Length + 1), true, true);
					if (@class.method_26(class16_0) || text.StartsWith(class2.string_0))
					{
						string text3 = text2;
						if (text3 != null && (text3 == "FFFF33" || text3 == "FF9CFF" || text3 == "9CCEFF" || text3 == "9CFF9C"))
						{
							class2.string_0 = text2 + " " + str;
							class2.method_5(true, true);
						}
					}
				}
			}
		}
	}
}
