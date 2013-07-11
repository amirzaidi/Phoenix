using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.HabboHotel.Items;
using Phoenix.Messages;
using Phoenix.HabboHotel.Rooms;
namespace Phoenix.Communication.Messages.Rooms.Furniture
{
	internal sealed class RoomDimmerGetPresetsMessageEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			try
			{
				Room @class = Phoenix.GetGame().GetRoomManager().GetRoom(class16_0.GetHabbo().CurrentRoomId);
				if (@class != null && @class.method_27(class16_0, true) && @class.class67_0 != null)
				{
					ServerMessage gClass = new ServerMessage(365u);
					gClass.AppendInt32(@class.class67_0.Presets.Count);
					gClass.AppendInt32(@class.class67_0.CurrentPreset);
					int num = 0;
					foreach (MoodlightPreset current in @class.class67_0.Presets)
					{
						num++;
						gClass.AppendInt32(num);
						gClass.AppendInt32(int.Parse(Phoenix.smethod_4(current.BackgroundOnly)) + 1);
						gClass.AppendStringWithBreak(current.ColorCode);
						gClass.AppendInt32(current.ColorIntensity);
					}
					class16_0.method_14(gClass);
				}
			}
			catch
			{
			}
		}
	}
}
