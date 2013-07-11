using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Messages;
using Phoenix.HabboHotel.Items;
using Phoenix.HabboHotel.Rooms;
namespace Phoenix.Communication.Messages.Rooms.Furniture
{
	internal sealed class RoomDimmerSavePresetMessageEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			try
			{
				Room @class = Phoenix.GetGame().GetRoomManager().GetRoom(class16_0.GetHabbo().CurrentRoomId);
				if (@class != null && @class.method_27(class16_0, true) && @class.class67_0 != null)
				{
					UserItemData class2 = null;
					foreach (UserItemData class3 in @class.Hashtable_1.Values)
					{
						if (class3.GetBaseItem().InteractionType.ToLower() == "dimmer")
						{
							class2 = class3;
							break;
						}
					}
					if (class2 != null)
					{
						int num = class18_0.PopWiredInt32();
						int num2 = class18_0.PopWiredInt32();
						string string_ = class18_0.PopFixedString();
						int int_ = class18_0.PopWiredInt32();
						bool bool_ = false;
						if (num2 >= 2)
						{
							bool_ = true;
						}
						@class.class67_0.Enabled = true;
						@class.class67_0.CurrentPreset = num;
						@class.class67_0.method_2(num, string_, int_, bool_);
						class2.string_0 = @class.class67_0.method_7();
						class2.method_4();
					}
				}
			}
			catch
			{
			}
		}
	}
}
