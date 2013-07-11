using System;
using System.Collections.Generic;
using Phoenix.HabboHotel.GameClients;
using Phoenix.HabboHotel.Rooms;
using Phoenix.Messages;
namespace Phoenix.Communication.Messages.Navigator
{
	internal sealed class CreateEventMessageEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			Room @class = Phoenix.GetGame().GetRoomManager().GetRoom(class16_0.GetHabbo().CurrentRoomId);
			if (@class != null && @class.method_27(class16_0, true) && @class.Event == null && @class.State == 0)
			{
				int int_ = class18_0.PopWiredInt32();
				string text = Phoenix.smethod_7(class18_0.PopFixedString());
				string string_ = Phoenix.smethod_7(class18_0.PopFixedString());
				int num = class18_0.PopWiredInt32();
				if (text.Length >= 1)
				{
					@class.Event = new RoomEvent(@class.Id, text, string_, int_, null);
					@class.Event.Tags = new List<string>();
					for (int i = 0; i < num; i++)
					{
						@class.Event.Tags.Add(Phoenix.smethod_7(class18_0.PopFixedString()));
					}
					@class.SendMessage(@class.Event.Serialize(class16_0), null);
				}
			}
		}
	}
}
