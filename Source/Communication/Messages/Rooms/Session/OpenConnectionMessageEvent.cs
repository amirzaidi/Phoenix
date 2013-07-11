using System;
using Phoenix.Core;
using Phoenix.HabboHotel.GameClients;
using Phoenix.HabboHotel.Rooms;
using Phoenix.Messages;
namespace Phoenix.Communication.Messages.Rooms.Session
{
	internal sealed class OpenConnectionMessageEvent : Interface
	{
		public void imethod_0(GameClient class16_0, ClientMessage class18_0)
		{
			class18_0.PopWiredInt32();
			uint num = class18_0.PopWiredUInt();
			class18_0.PopWiredInt32();
			if (Phoenix.GetConfig().data["emu.messages.roommgr"] == "1")
			{
				Logging.WriteLine("[RoomMgr] Requesting Public Room [ID: " + num + "]");
			}
            RoomData @class = Phoenix.GetGame().GetRoomManager().method_12(num);
			if (@class != null && !(@class.Type != "public"))
			{
				class16_0.method_1().method_5(num, "");
			}
		}
	}
}
