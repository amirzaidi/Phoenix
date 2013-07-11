using System;
using Phoenix.HabboHotel.GameClients;
using Phoenix.Messages;
using Phoenix.HabboHotel.Rooms;
namespace Phoenix.Communication.Messages.Rooms.Action
{
	internal sealed class LetUserInMessageEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			Room @class = Phoenix.GetGame().GetRoomManager().GetRoom(class16_0.GetHabbo().CurrentRoomId);
			if (@class != null && @class.method_26(class16_0))
			{
				string string_ = class18_0.PopFixedString();
				byte[] array = class18_0.ReadBytes(1);
				GameClient class2 = Phoenix.GetGame().GetClientManager().GetClientByHabbo(string_);
				if (class2 != null && class2.GetHabbo().bool_6 && class2.GetHabbo().uint_2 == class16_0.GetHabbo().CurrentRoomId)
				{
					if (array[0] == Convert.ToByte(65))
					{
						class2.GetHabbo().bool_5 = true;
						class2.method_14(new ServerMessage(41u));
					}
					else
					{
						class2.method_14(new ServerMessage(131u));
					}
				}
			}
		}
	}
}
