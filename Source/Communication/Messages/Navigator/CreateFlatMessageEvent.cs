using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.HabboHotel.Rooms;
using Phoenix.Util;
using Phoenix.Messages;
namespace Phoenix.Communication.Messages.Navigator
{
	internal sealed class CreateFlatMessageEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			if (class16_0.GetHabbo().list_6.Count <= Config.Int32_4)
			{
				string string_ = Phoenix.smethod_7(class18_0.PopFixedString());
				string string_2 = class18_0.PopFixedString();
				class18_0.PopFixedString();
                RoomData @class = Phoenix.GetGame().GetRoomManager().method_20(class16_0, string_, string_2);
				if (@class != null)
				{
					ServerMessage gClass = new ServerMessage(59u);
					gClass.AppendUInt(@class.Id);
					gClass.AppendStringWithBreak(@class.Name);
					class16_0.method_14(gClass);
				}
			}
		}
	}
}
